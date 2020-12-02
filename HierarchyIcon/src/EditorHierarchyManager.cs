using UnityEditor;
using UnityEngine;
namespace KuFramework.EditorTools
{
    [InitializeOnLoad]
    public class EditorHierarchyManager
    {
        private static IEditorHierarchyTool mEditorHierarchyStrengthen;
        private static bool mToolSwitch;
        static EditorHierarchyManager()
        {
            //EditorApplication.update += Update;
            mEditorHierarchyStrengthen = new EditorHierarchyTool();
            InitSwitch();
            AddMethod();
        }

        [MenuItem("GameObject/Tools/HierarchyStrengthen/Switch",false,1)]
        private static void HierarchyToolSwitch()
        {
            if(mToolSwitch)
            {
                RemoveMethod();
            }
            else
            {
                AddMethod();
            }
            mToolSwitch = !mToolSwitch;
            EditorUtility.DisplayDialog("Tips","\n\tPlease wait for a moment\n\tWait for Editor GUI update...","ok");
        }
        private static void InitSwitch()
        {
            mToolSwitch = true;
        }
        private static void AddMethod()
        {
            RemoveMethod();
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon;
        }
        private static void RemoveMethod()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= DrawHierarchyIcon;
        }
        private static void DrawHierarchyIcon(int instanceId, Rect selectionRect) => mEditorHierarchyStrengthen.ShowHierarchyIcon(instanceId, selectionRect);

    }

}