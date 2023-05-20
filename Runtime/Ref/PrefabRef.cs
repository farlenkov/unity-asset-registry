using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAssetRegistry
{
    [Serializable]
    public class PrefabRef : AssetRef 
    {
#if UNITY_2017_1_OR_NEWER

        public GameObject GetAsset() 
            => PrefabIndex.Current.GetAsset(Guid);

        public bool TryGetAsset(out GameObject asset) 
            => PrefabIndex.Current.TryGetAsset(Guid, out asset);

#endif

#if UNITY_EDITOR

        public GameObject GetAssetInEditor()
            => PrefabIndex.GetAssetInEditor(Guid);

        public bool TryGetAssetInEditor(out GameObject asset) 
            => PrefabIndex.TryGetAssetInEditor(Guid, out asset);

#endif
    }
}
