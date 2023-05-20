using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityAssetRegistry
{
    public static class AssetRegistryLoader
    {
        public static bool IsLoaded { get; private set; }

        public static void InitIndex()
        {
            var indexes = Resources.LoadAll<AssetRegistryIndex>(string.Empty);

            foreach (var index in indexes)
                index.Init();
        }

        public static IEnumerator LoadIndex()
        {
            if (IsLoaded)
                yield break;

            var indexes = Resources.LoadAll<AssetRegistryIndex>(string.Empty);

            foreach (var index in indexes)
                yield return index.Load();

            IsLoaded = true;
        }

#if UNITY_EDITOR

        [MenuItem("Assets/Asset Registry > Refresh")]
        public static void RefreshAll()
        {
            var indexes = Resources.LoadAll<AssetRegistryIndex>(string.Empty);

            foreach (var index in indexes)
            {
                index.Refresh();
                EditorUtility.SetDirty(index);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

#endif
    }
}
