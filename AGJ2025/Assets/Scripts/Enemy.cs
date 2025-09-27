using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth;
    int health;

    [Tooltip("T1 = Amount of damage taken, T2 = HP left after the damage")]
    public UnityEvent<int, int> OnTakeDamage;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        OnTakeDamage?.Invoke(damage, health);
    }

    public void EventDebug(int damage, int health)
    {
        Debug.Log($"Took {damage} damage and {health} health left");
    }
}
