using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAssetRegistry
{
    [CreateAssetMenu(fileName = "MaterialIndex", menuName = "AssetRegistry/Material", order = 1)]
    public class MaterialIndex : AssetRegistryIndex<Material, MaterialIndexItem>
    {

    }
}
