using System;
using UnityEditor;
using UnityEngine;
namespace KuFramework.EditorTools
{
    [InitializeOnLoad]
    public class EditorHierarchyManager
    {
        private static IEditorHierarchyTool mEditorHierarchyStrengthen;
        /// <summary>
        /// 虽然是静态构造方法，但是每次运行时都会调用一次
        /// </summary>
        static EditorHierarchyManager()
        {
            //EditorApplication.update += Update;
            mEditorHierarchyStrengthen = new EditorHierarchyTool();
            AddMethod(!EditorPrefs.GetBool("mToolSwitch"));
        }

        [MenuItem("GameObject/Tools/HierarchyStrengthen/Switch",false,1)]
        private static void HierarchyToolSwitch()
        {
            EditorPrefs.SetBool("mToolSwitch", !AddMethod(EditorPrefs.GetBool("mToolSwitch")));
            EditorUtility.DisplayDialog("Tips","\n\tPlease wait for a moment\n\tWait for Editor GUI update...","ok");
        }
        private static void InitSwitch()
        {
            EditorPrefs.SetBool("mToolSwitch",true);
        }
        private static bool AddMethod(bool isOn)
        {
            if(isOn)
                EditorApplication.hierarchyWindowItemOnGUI -= DrawHierarchyIcon;
            else
            {
                EditorApplication.hierarchyWindowItemOnGUI -= DrawHierarchyIcon;
                EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon;
            }
            return isOn;
        }
        private static void DrawHierarchyIcon(int instanceId, Rect selectionRect) => mEditorHierarchyStrengthen.ShowHierarchyIcon(instanceId, selectionRect);

    }

}