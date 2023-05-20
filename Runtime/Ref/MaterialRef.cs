using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAssetRegistry
{
    [Serializable]
    public class MaterialRef : AssetRef 
    {
#if UNITY_2017_1_OR_NEWER

        public Material GetAsset() 
            => MaterialIndex.Current.GetAsset(Guid);

        public bool TryGetAsset(out Material asset) 
            => MaterialIndex.Current.TryGetAsset(Guid, out asset);

#endif

#if UNITY_EDITOR

        public Material GetAssetInEditor()
            => MaterialIndex.GetAssetInEditor(Guid);

        public bool TryGetAssetInEditor(out Material asset) 
            => MaterialIndex.TryGetAssetInEditor(Guid, out asset);

#endif
    }
}
