using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /// <summary> Constant Float representing 0f to eliminate magic numbers </summary>
    private const float fZero = 0f;

    [Header("Target Game Object To Follow")]
    [Tooltip("Target Game Object To Follow")]
    [SerializeField] private GameObject followTarget;

    [Header("Camera Offset And Rotation")]
    [Tooltip("Cameras follow distance")]
    [SerializeField] private Vector3 cameraFollowOffset = new Vector3(fZero, 5, -13);
    [Tooltip("Camera's Rotation on the X axis")]
    [SerializeField] private float cameraRotationX = 25f;

    void Start()
    {
        //Ensures the follow target is assigned to the player if it was not set in the inspector
        if (followTarget == null)
        {
            followTarget = GameObject.FindGameObjectWithTag("Player");
        }
        Debug.Log($"Camera Follow Target Refrenced On Awake: {followTarget?.name ?? "Follow Target Was Null On Start"}");

        SetCameraTramsform();
    }

    /// <summary>Method sets the position and rotation of the camera</summary>
    /// <remarks>The rotation is set to handle rotation updates in the future></remarks>
    void SetCameraTramsform ()
    {
        transform.position = followTarget.transform.position + cameraFollowOffset;
        transform.rotation = Quaternion.Euler(cameraRotationX, fZero, fZero);
    }

    void LateUpdate()
    {
        SetCameraTramsform();
    }
}
