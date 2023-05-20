using System;

namespace UnityAssetRegistry
{
    [Serializable] 
    public abstract class AssetRef 
    {
        public string Guid { get; private set; }

#if UNITY_EDITOR

        public void SetGuid(string guid) => Guid = guid;

#endif
    }
}