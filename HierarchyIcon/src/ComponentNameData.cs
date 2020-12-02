using System.Collections.Generic;

public class ComponentNameData
{
    public static List<string> mComponentList = new List<string>()
    {         
    #region UI
        //"RectTransform",
        "Image",
        "RawImage",
        "Text",
        "InputField",
        "Button",
        "ScrollRect",
        "ScrollBar",
        "Dropdown",
        "Slider",
        "Mask",
	#endregion

	#region physics
        "BoxCollider",
        "SphereCollider",
        "CapsuleCollider",
        "MeshCollider",
        "CharacterController",
        "Rigidbody",
	#endregion

    #region layout
        "Canvas",
        "CanvasGroup",
        "VerticalLayoutGroup",
        "HorizontalLayoutGroup",
        "GridLayoutGroup",
        "CanvasScaler",
        "ContentSizeFitter",
        "AspectRatioFitter",
        "LayoutElement",
    #endregion

	#region audio
        "AudioSource",
        "AudioReverbZone",
	#endregion

	#region effect
        "ParticleSystem",
        "LineRenderer",
        "TrailRenderer",
        "Projector",
	#endregion

	#region Mesh
        "MeshRenderer",
        "SkinnedMeshRenderer",
	#endregion

	#region miscellaneous
        "Animator",
        "Animation",
	#endregion

	#region navagation
        "NavMeshAgent",
        "NavMeshObstacle",
        "OffMeshLink",
	#endregion

	#region network
        "NetworkIdentity",
        "NetworkAnimator",
        "NetworkTransform",
        "NetworkBehaviour",
        "NetworkManager",
	#endregion

	#region physics2d
        "BoxCollider2D",
        "CircleCollider2D",
        "CapsuleCollider2D",
	#endregion

	#region rendering
        "SpriteRenderer",
        "Light",
        "Camera",
        //"CanvasRenderer",
	#endregion

	#region video
        "VideoPlayer",
	#endregion
	#region event
        "EventSystem"
	#endregion
    };
}
