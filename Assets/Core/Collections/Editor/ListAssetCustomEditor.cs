#if UNITY_EDITOR

using UnityEditor;

namespace Core.Collections.Editor
{
    [CustomEditor(typeof(ListAssetBase), true)]
    internal sealed class ListAssetCustomEditor : ReorderableListCustomEditor 
    {
        
    }
}

#endif