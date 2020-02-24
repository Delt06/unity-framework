#if UNITY_EDITOR

using Framework.Core.Collections;
using UnityEditor;

namespace Framework.Core.Editor.Collections
{
    [CustomEditor(typeof(ListAssetBase), true)]
    internal sealed class ListAssetCustomEditor : ReorderableListCustomEditor
    {

    }
}

#endif