using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityUtility;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityAssetRegistry
{
    public abstract class AssetRegistryIndex : ScriptableObject
    {
        [SerializeField] 
        protected string IndexPath;

        [SerializeField] 
        protected string[] AssetsPath;
        
        [ReadOnly]
        [SerializeField] 
        protected List<string> Guids;

        internal abstract void Init();
        internal abstract IEnumerator Load();
        protected string GetResourcesPath() => IndexPath.Split("/Resources/")[1];

#if UNITY_EDITOR

        internal abstract void Refresh();

        protected void CheckFolder(string type)
        {
            if (!Directory.Exists(IndexPath))
                Directory.CreateDirectory(IndexPath);
        }

#endif
    }

    public abstract class AssetRegistryIndex<ASSET, REGISTRY> : AssetRegistryIndex
        where ASSET : UnityEngine.Object
        where REGISTRY : AssetRegistryItem<ASSET>
    {
        // STATIC

        internal static AssetRegistryIndex<ASSET, REGISTRY> Current { get; private set; }

        // OBJECT

        [NonSerialized]
        protected Dictionary<string, ASSET> Index;

        internal override void Init()
        {
            Current = this;
            Index = new Dictionary<string, ASSET>();
        }

        internal override IEnumerator Load()
        {
            var resourcesPath = GetResourcesPath();
            var count = Guids.Count;
            var yield_counter = 0;

            Index.Clear();

            for (var i = 0; i < count; i++)
            {
                var guid = Guids[i];

                if (!Index.ContainsKey(guid))
                {
                    var res = Resources.Load<REGISTRY>($"{resourcesPath}/{guid}");

                    if (res == null)
                        Log.ErrorEditor("[AssetRegistryIndex] not found ({0}) {1}/{2}", this.GetType().Name, resourcesPath, guid);

                    Index.Add(guid, res?.Asset);
                    yield_counter++;
                }

                if (yield_counter == 10)
                {
                    // skip frame every 10 assets
                    yield_counter = 0;
                    yield return null;
                }
            }
        }

        internal bool TryGetAsset(string guid, out ASSET asset)
        {
            asset = GetAsset(guid);
            return asset != null;
        }

        internal ASSET GetAsset(string guid)
        {
            if (string.IsNullOrEmpty(guid))
                return null;

            if (Index == null) // for local tests without preload
                return null;

            if (Index.TryGetValue(guid, out ASSET asset))
                return asset;

            var type = typeof(ASSET).Name;
            var resourcesPath = GetResourcesPath();
            var resource = Resources.Load<REGISTRY>($"{resourcesPath}/{guid}");

            if (resource != null)
            {
                Index.Add(guid, resource.Asset);
                return resource.Asset;
            }
            else
            {
                Index.Add(guid, null);
                return null;
            }
        }

#if UNITY_EDITOR

        internal static bool TryGetAssetInEditor(string guid, out ASSET asset)
        {
            asset = GetAssetInEditor(guid);
            return asset != null;
        }

        internal static ASSET GetAssetInEditor(string guid)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            Log.InfoEditor("[GetAssetInEditor] {0} | {1} | {2}", typeof(ASSET).Name, guid, path);
            var asset = (ASSET)AssetDatabase.LoadAssetAtPath(path, typeof(ASSET));
            return asset;
        }

        internal override void Refresh()
        {
            Guids.Clear();

            // REMOVE BROKEN ASSETS

            var indexPathParts = IndexPath.Split("/Resources/");

            if (indexPathParts.Length < 2)
            {
                Log.Error("[AssetRegistryIndex: Refresh] IndexPath for '{0}' not in Resources: '{1}'", name, IndexPath);
                return;
            }

            var indexPath = indexPathParts[1];
            var resources = Resources.LoadAll<REGISTRY>(indexPath);

            foreach (var resource in resources)
                if (resource.Asset == null)
                    AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(resource));

            // CREATE NEW & UPDATE EXISTING ASSETS

            var type = typeof(ASSET).Name;
            var guids = AssetDatabase.FindAssets($"t:{type}", AssetsPath);

            for (var i = 0; i < guids.Length; i++)
            {
                var uid = guids[i];
                var path = AssetDatabase.GUIDToAssetPath(uid);
                var asset = (ASSET)AssetDatabase.LoadAssetAtPath(path, typeof(ASSET));
                var res_name = $"{indexPath}/{uid}";
                var resource = Resources.Load<REGISTRY>(res_name);

                Guids.Add(uid);

                if (resource == null)
                {
                    resource = ScriptableObject.CreateInstance<REGISTRY>();
                    resource.name = uid;
                    resource.Asset = asset;

                    CheckFolder(type);
                    AssetDatabase.CreateAsset(resource, IndexPath + $"/{uid}.asset");
                }
                else
                {
                    if (resource.Asset != asset)
                    {
                        resource.Asset = asset;
                        EditorUtility.SetDirty(resource);
                    }
                }
            }
        }

#endif
    }
}
