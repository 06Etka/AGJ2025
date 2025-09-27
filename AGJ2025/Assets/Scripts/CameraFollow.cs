using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Game Object To Follow")]
    [Tooltip("Target Game Object To Follow")]
    [SerializeField] private GameObject followTarget;

    [Header("Camera Offset And Rotation")]
    [Tooltip("Cameras follow distance")]
    [SerializeField] private Vector3 cameraFollowOffset = new Vector3(0, 5, -13);
    [Tooltip("Camera's Rotation on the X axis")]
    [SerializeField] private float cameraRotationX = 25f;

    void Start()
    {
        // If target is not assigned, find the player by tag
        if (followTarget == null)
        {
            followTarget = GameObject.FindGameObjectWithTag("Player");
            Debug.LogWarning($"The GameObject Target was null, Assigned Player tag instead.");
        }
        else
        {
            Debug.LogWarning("Camera Follow Target is not assigned.");
        }

        SetCameraTramsform();
    }

    /// <summary>Method sets the position and rotation of the camera</summary>
    /// <remarks>The rotation is set to handle rotation updates in the future></remarks>
    void SetCameraTramsform ()
    {
        transform.position = followTarget.transform.position + cameraFollowOffset;
        transform.rotation = Quaternion.Euler(cameraRotationX, 0, 0);
    }

    void LateUpdate()
    {
        SetCameraTramsform();
    }
}
