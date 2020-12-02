using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace KuFramework.EditorTools
{
    public class EditorHierarchyTool : IEditorHierarchyTool
    {
        private GUIStyle mStyle;
        private int mIndex = 0;
        private List<string> mComponentNameList;
        private GameObject mHierarchyItem;
        private Rect mHierarchyItemRect;
        public EditorHierarchyTool()
        {
            InitStyle();
            InitData();
        }
        private void InitStyle()
        {
            mStyle = new GUIStyle();
            mStyle.alignment = TextAnchor.MiddleRight;
            mStyle.normal.textColor = Color.gray;
            mStyle.hover.textColor = Color.yellow;
            mStyle.onHover.textColor = Color.blue;
        }
        private void InitData()
        {
            mComponentNameList = new List<string>(ComponentNameData.mComponentList);
        }
        public void AddToComponentList(string componentName)
        {
            if (!mComponentNameList.Contains(componentName))
                mComponentNameList.Add(componentName);
        }
        public void AddToComponentList(List<string> componentNameList)
        {
            for (int i = 0; i < componentNameList.Count; i++)
            {
                if (!mComponentNameList.Contains(componentNameList[i]))
                    mComponentNameList.Add(componentNameList[i]);
            }
        }
        public void RemoveInComponentList(string componentName)
        {
            if (mComponentNameList.Contains(componentName))
                mComponentNameList.Remove(componentName);
        }
        public void RemoveInComponentList(List<string> componentNameList)
        {
            for (int i = 0; i < componentNameList.Count; i++)
            {
                if (mComponentNameList.Contains(componentNameList[i]))
                    mComponentNameList.Remove(componentNameList[i]);
            }
        }
        public void ShowHierarchyIcon(int instanceID, Rect selectionRect)
        {
            mHierarchyItemRect = GetRect(selectionRect, 0);
            //Rect rectCheck = new Rect(25, selectionRect.y, selectionRect.width, selectionRect.height);
            mIndex = 0;
            mHierarchyItem = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (mHierarchyItem == null)
                return;
            SetItemActive();
            for (int i = 0; i < mComponentNameList.Count; i++)
            {
                ShowRectIcon(selectionRect, mComponentNameList[i]);
            }
            ShowStaticIcon(selectionRect);
        }
        public void ShowInstanceID(int instanceId, Rect selectionRect)
        {
            if (instanceId == Selection.activeInstanceID)
            {
                Rect rect = new Rect(selectionRect);
                rect.x += selectionRect.width - 100;
                rect.width = 50;
                DrawLabel(instanceId, rect);
            }
        }
        private void SetItemActive()
        {
            mHierarchyItem.SetActive(GUI.Toggle(mHierarchyItemRect, mHierarchyItem.activeSelf, string.Empty));
        }
        private void ShowStaticIcon(Rect selectionRect)
        {
            if (mHierarchyItem.isStatic)
            {
                mIndex += 1;
                Rect rectIcon = GetRect(selectionRect, mIndex);
                GUI.Label(rectIcon, "S");
            }
        }
        public void DrawLabel(int instanceId, Rect rect)
        {
            GUI.Label(rect, instanceId.ToString(), mStyle);
        }

        /// <summary>
        /// 显示文字信息,随物体激活显隐
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="selectionRect"></param>
        private void ShowTextInfo(GameObject obj, Rect selectionRect)
        {
            string info = "";
            if (mStyle != null && obj.activeInHierarchy)
            {
                //style.normal.textColor = Color.black;
                GUI.Label(selectionRect, info, mStyle);
            }
        }
        private void ShowRectIcon(Rect selectionRect, string componentName)
        {
            Component component = mHierarchyItem.GetComponent(componentName);
            if (component != null)
            {
                mIndex += 1;
                mHierarchyItemRect = GetRect(selectionRect, mIndex);
                DrawIcon(component, componentName);
            }
        }
        private Rect GetRect(Rect selectionRect, int index)
        {
            Rect rect = new Rect(selectionRect);
            rect.x += rect.width - 20 - (20 * index);
            rect.width = 20;
            return rect;
        }
        private void DrawIcon(Component component, string componentName)
        {
            Texture icon = EditorGUIUtility.ObjectContent(null, component.GetType()).image;
            GUI.Label(mHierarchyItemRect, icon);
        }
        /// <summary>
        /// 自定义贴图方法
        /// </summary>
        /// <param name="selectionRect"></param>
        /// <param name="texture"></param>
        private void DrawRectIcon(Rect selectionRect, Texture2D texture)
        {
            mIndex += 1;
            var rect = GetRect(selectionRect, mIndex);
            GUI.Label(rect, texture);
        }
    }
}