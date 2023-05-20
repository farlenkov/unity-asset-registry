using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAssetRegistry
{
    [Serializable]
    public class Texture2DRef : AssetRef 
    {
#if UNITY_2017_1_OR_NEWER

        public Texture2D GetAsset() 
            => Texture2DIndex.Current.GetAsset(Guid);

        public bool TryGetAsset(out Texture2D asset) 
            => Texture2DIndex.Current.TryGetAsset(Guid, out asset);

#endif

#if UNITY_EDITOR

        public Texture2D GetAssetInEditor()
            => Texture2DIndex.GetAssetInEditor(Guid);

        public bool TryGetAssetInEditor(out Texture2D asset) 
            => Texture2DIndex.TryGetAssetInEditor(Guid, out asset);

#endif
    }
}
