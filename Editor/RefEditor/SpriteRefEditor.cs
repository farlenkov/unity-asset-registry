using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityAssetRegistry
{
    [CustomPropertyDrawer(typeof(SpriteRef))]
    public class SpriteRefEditor : AssetRefEditor<Sprite>
    {

    }
}
