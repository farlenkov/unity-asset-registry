using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAssetRegistry
{
    [Serializable]
    public class SpriteRef : AssetRef 
    {
#if UNITY_2017_1_OR_NEWER

        public Sprite GetAsset() 
            => SpriteIndex.Current.GetAsset(Guid);

        public bool TryGetAsset(out Sprite asset) 
            => SpriteIndex.Current.TryGetAsset(Guid, out asset);

#endif

#if UNITY_EDITOR

        public Sprite GetAssetInEditor()
            => SpriteIndex.GetAssetInEditor(Guid);

        public bool TryGetAssetInEditor(out Sprite asset) 
            => SpriteIndex.TryGetAssetInEditor(Guid, out asset);

#endif
    }
}
