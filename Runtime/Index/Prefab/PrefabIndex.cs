using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAssetRegistry
{
    [CreateAssetMenu(fileName = "PrefabIndex", menuName = "AssetRegistry/Prefab", order = 1)]
    public class PrefabIndex : AssetRegistryIndex<GameObject, PrefabIndexItem>
    {

    }
}
