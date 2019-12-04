#if UNITY_EDITOR

using UnityEditor;

namespace Framework.Core.Collections.Editor
{
    [CustomEditor(typeof(ListAssetBase), true)]
    internal sealed class ListAssetCustomEditor : ReorderableListCustomEditor 
    {
        
    }
}

#endif