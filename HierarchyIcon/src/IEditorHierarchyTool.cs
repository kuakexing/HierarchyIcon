using UnityEngine;
namespace KuFramework.EditorTools
{
    public interface IEditorHierarchyTool
    {
        /// <summary>
        /// 绘制icon方法
        /// </summary>
        /// <param name="instanceID"></param>
        /// <param name="selectionRect"></param>
        void ShowHierarchyIcon(int instanceID, Rect selectionRect);
        /// <summary>
        /// 显示Hierarchy选中的GameObject的InstanceID
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="selectionRect"></param>
        void ShowInstanceID(int instanceId, Rect selectionRect);
    }
}