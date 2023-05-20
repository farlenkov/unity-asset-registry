using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAssetRegistry
{
    [CreateAssetMenu(fileName = "AnimationClipIndex", menuName = "AssetRegistry/AnimationClip", order = 1)]
    public class AnimationClipIndex : AssetRegistryIndex<AnimationClip, AnimationClipIndexItem>
    {

    }
}
