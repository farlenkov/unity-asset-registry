using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityAssetRegistry
{
    [CustomPropertyDrawer(typeof(Texture2DRef))]
    public class Texture2DRefEditor : AssetRefEditor<Texture2D>
    {

    }
}
