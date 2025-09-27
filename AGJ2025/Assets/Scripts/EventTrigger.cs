using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public bool triggerOnEnter = false;
    public bool triggerOnExit = false;

    public string[] triggerTags;

    public UnityEvent enterEvent;
    public UnityEvent exitEvent;

    private void Start()
    {
        Collider collider = GetComponent<Collider>();
        if(collider == null)
        {
            Debug.LogError("Collider is null!");
            return;
        }

        if (collider.isTrigger)
            return;

        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggerOnEnter)
            return;

        if (!CheckTags(other.tag))
            return;

        enterEvent?.Invoke();
        gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!triggerOnExit)
            return;

        if (!CheckTags(other.tag))
            return;

        exitEvent?.Invoke();
        gameObject.SetActive(false);
    }

    bool CheckTags(string colliderTag)
    {
        if (triggerTags.Length <= 0)
        {
            Debug.Log("There are no tags assigned!", this);
            return false;
        }

        foreach (var triggerTag in triggerTags)
        {
            if (colliderTag == triggerTag)
            {
                return true;
            }
        }
        return false;
    }
}
