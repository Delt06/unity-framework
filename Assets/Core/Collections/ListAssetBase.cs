using UnityEngine;

namespace Core.Collections
{
    public abstract class ListAssetBase : ScriptableObject
    {
        internal const string BuiltInPath = CollectionsAssets.Path + "List/Built-in/";
        protected internal const string CustomPath = CollectionsAssets.Path + "Array/Custom/";
    }
}