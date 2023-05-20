using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityAssetRegistry
{
    [CustomPropertyDrawer(typeof(AudioClipRef))]
    public class AudioClipRefEditor : AssetRefEditor<AudioClip>
    {

    }
}
