using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAssetRegistry
{
    [CreateAssetMenu(fileName = "SpriteIndex", menuName = "AssetRegistry/Sprite", order = 1)]
    public class SpriteIndex : AssetRegistryIndex<Sprite, SpriteIndexItem>
    {

    }
}
