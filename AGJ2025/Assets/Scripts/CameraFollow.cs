using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class CameraFollow : MonoBehaviour
{
    /// <summary> Constant Float representing 0f to eliminate magic numbers </summary>
    private const float fZero = 0f;

    [Header("Target Game Object To Follow")]
    [Tooltip("Target Game Object To Follow")]
    [SerializeField] private GameObject followTarget;
    private GameObject originalTarget;
    [Tooltip("Tags Accepted As Follow Target")]
    [SerializeField] private string[] acceptedTags;


[Header("Camera Offset And Rotation")]
    [Tooltip("Cameras follow distance")]
    [SerializeField] private Vector3 cameraFollowOffset = new Vector3(fZero, 5, -13);
    [Tooltip("Camera's Rotation on the X axis")]
    [SerializeField] private float cameraRotationX = 25f;

    void Start()
    {
        if(acceptedTags.Length < 1)
        {
            acceptedTags = new string[] { "Player" };
        }

        EnsureTargetIsAssigned();
        SetCameraTramsform();
    }

    /// <summary> Ensures that the <c>followTarget</c> is assigned to a valid GameObject with an accepted tag. </summary>
    /// <remarks>If <c>followTarget</c> is null or its tag is not in the list of accepted tags, the method
    /// searches  for the first GameObject in the scene with an accepted tag and assigns it to <c>followTarget</c>.  If
    /// no such GameObject is found, <c>followTarget</c> remains null.</remarks>
    private void EnsureTargetIsAssigned()
    {
        //Method does not use LINQ to find the first object with an accepted tag to avoid unnecessary overhead in the update loop
        if (followTarget == null || !IsTagAccepted(followTarget.gameObject.tag))
        {
            for (int i = 0; i < acceptedTags.Length; i++)
            {
                GameObject foundObject = GameObject.FindGameObjectWithTag(acceptedTags[i]);
                if (foundObject != null)
                {
                    followTarget = foundObject;
                    originalTarget = followTarget;
                    break;
                }
            }
        }
        Debug.Log($"Camera Follow Target Refrenced On Awake: {followTarget?.name ?? "Follow Target Was Null On Start"}");
    }

    private bool IsTagAccepted(string objectTag)
    {
        //Method uses LINQ due to mainly checking System.String values
        return acceptedTags.Contains(objectTag);
    }

    /// <summary>Method sets the position and rotation of the camera</summary>
    /// <remarks>The rotation is set to handle rotation updates in the future></remarks>
    void SetCameraTramsform ()
    {
        transform.position = followTarget.transform.position + cameraFollowOffset;
        transform.rotation = Quaternion.Euler(cameraRotationX, fZero, fZero);
    }

    public void SetTarget(GameObject target)
    {
        followTarget = target;
    }

    public void ClearTarget()
    {
        followTarget = originalTarget;
    }

    void LateUpdate()
    {
        SetCameraTramsform();
    }
}
