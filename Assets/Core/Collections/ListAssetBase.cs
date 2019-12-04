using UnityEngine;

namespace Core.Collections
{
    public abstract class ListAssetBase : ScriptableObject
    {
        internal const string BuiltInPath = CollectionsAssets.Path + "List/";
        protected internal const string CustomPath = BuiltInPath + "Custom/";
    }
}