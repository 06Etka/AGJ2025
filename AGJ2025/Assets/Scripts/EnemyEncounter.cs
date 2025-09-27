using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class EnemyEncounter : MonoBehaviour
{

    [Header("Encounter Settings")]
    [Tooltip("Radius within which the enemy can encounter the player")]
    [SerializeField] private float encounterRadius = 5f;

    private SphereCollider encounterCollider;

    public UnityEvent encounterStarted;

    void Awake()
    {
        encounterCollider = GetComponent<SphereCollider>();
        encounterCollider.isTrigger = true;
        encounterCollider.radius = encounterRadius;

        if (encounterStarted == null)
        {
            encounterStarted = new UnityEvent();
        }

        //rather noth do this. brain clocked out at 5am leavingit here for reference
        //encounterStarted.AddListener(() => GameManager.Instance.SetGameState(GameState.InCombat));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            encounterStarted?.Invoke();
            Debug.Log("Encounter Started");
        }
    }

    private void OnValidate()
    {
        if (encounterCollider != null)
        {
            encounterCollider.radius = encounterRadius;
        }
    }
}
