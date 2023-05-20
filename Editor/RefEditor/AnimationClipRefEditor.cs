using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityAssetRegistry
{
    [CustomPropertyDrawer(typeof(AnimationClipRef))]
    public class AnimationClipRefEditor : AssetRefEditor<AnimationClip>
    {

    }
}
