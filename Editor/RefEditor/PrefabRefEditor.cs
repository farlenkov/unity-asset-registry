using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityAssetRegistry
{
    [CustomPropertyDrawer(typeof(PrefabRef))]
    public class PrefabRefEditor : AssetRefEditor<GameObject>
    {

    }
}