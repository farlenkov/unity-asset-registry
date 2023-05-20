using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAssetRegistry
{
    [Serializable]
    public class AudioClipRef : AssetRef 
    {
#if UNITY_2017_1_OR_NEWER

        public AudioClip GetAsset() 
            => AudioClipIndex.Current.GetAsset(Guid);

        public bool TryGetAsset(out AudioClip asset) 
            => AudioClipIndex.Current.TryGetAsset(Guid, out asset);

#endif

#if UNITY_EDITOR

        public AudioClip GetAssetInEditor()
            => AudioClipIndex.GetAssetInEditor(Guid);

        public bool TryGetAssetInEditor(out AudioClip asset) 
            => AudioClipIndex.TryGetAssetInEditor(Guid, out asset);

#endif
    }
}
