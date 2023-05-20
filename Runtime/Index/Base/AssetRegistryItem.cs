using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

namespace UnityAssetRegistry
{
    public class AssetRegistryItem : ScriptableObject
    {

    }

    public class AssetRegistryItem<T> : AssetRegistryItem
    {
        [ReadOnly] public T Asset;
    }
}
