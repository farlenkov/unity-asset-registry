using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAssetRegistry
{
    [CreateAssetMenu(fileName = "Texture2DIndex", menuName = "AssetRegistry/Texture2D", order = 1)]
    public class Texture2DIndex : AssetRegistryIndex<Texture2D, Texture2DIndexItem>
    {

    }
}
