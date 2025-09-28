using UnityEngine;
using Unity.Cinemachine;
public class IntroAnimationHandle : MonoBehaviour
{
    [SerializeField] CinemachineCamera mainCamera;


    private void OnTriggerEnter(Collider other)
    {
        mainCamera.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

}