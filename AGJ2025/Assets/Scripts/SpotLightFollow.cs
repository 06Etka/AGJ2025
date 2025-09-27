using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Light))]
public class SpotLightFollow : MonoBehaviour
{
    [Header("Set SpotLight Follow Settings")]
    [Tooltip("The target for the spotlight to follow")]
    [SerializeField] private Transform target;
    [Tooltip("The speed at which the spotlight follows the target")]
    [SerializeField] private float followSpeed;

    // Potetially have this activate on a trigger or event instead
    void Start()
    {
        if (target == null)
        {
            this.enabled = false;
            Debug.LogWarning("Target not assigned. Please assign a target for the spotlight to follow.");
        }
    }

    /// <summary> Makes the spotlight follow the target smoothly.</summary>
    void FollowTarget()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, followSpeed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowTarget();
    }

}
