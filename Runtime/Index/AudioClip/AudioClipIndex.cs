using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAssetRegistry
{
    [CreateAssetMenu(fileName = "AudioClipIndex", menuName = "AssetRegistry/AudioClip", order = 1)]
    public class AudioClipIndex : AssetRegistryIndex<AudioClip, AudioClipIndexItem>
    {

    }
}
