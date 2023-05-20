using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityAssetRegistry
{
    [CustomPropertyDrawer(typeof(MaterialRef))]
    public class MaterialRefEditor : AssetRefEditor<Material>
    {

    }
}
