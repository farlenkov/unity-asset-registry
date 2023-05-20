using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAssetRegistry
{
    [Serializable]
    public class AnimationClipRef : AssetRef
    {
#if UNITY_2017_1_OR_NEWER

        public AnimationClip GetAsset() 
            => AnimationClipIndex.Current.GetAsset(Guid);

        public bool TryGetAsset(out AnimationClip asset) 
            => AnimationClipIndex.Current.TryGetAsset(Guid, out asset);

#endif

#if UNITY_EDITOR

        public AnimationClip GetAssetInEditor()
            => AnimationClipIndex.GetAssetInEditor(Guid);

        public bool TryGetAssetInEditor(out AnimationClip asset) 
            => AnimationClipIndex.TryGetAssetInEditor(Guid, out asset);

#endif
    }
}
