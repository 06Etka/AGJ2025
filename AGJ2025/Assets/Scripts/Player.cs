using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IDamageable
{
    FightController fightController;

    [SerializeField] int maxHealth;

    int health;
    int defense;

    public List<AbilitySO> abilities = new List<AbilitySO>();

    public UnityEvent<int, int> OnStatsChange;
    public UnityEvent OnDeath;

    private void Start()
    {
        fightController = FightController.Instance;
        health = maxHealth;
    }

    public int GetAbilityCount(AbilitySO abilitySO)
    {
        return abilities.FindAll(a => a == abilitySO).Count;
    }

    public void ApplyDefense(int amount)
    {
        defense += amount;
        OnStatsChange?.Invoke(health, defense);
    }

    public void TakeDamage(int damage)
    {
        if (defense > 0)
        {
            if (damage >= defense)
            {
                damage -= defense;
                defense = 0;
            }
            else
            {
                defense -= damage;
                damage = 0;
            }
        }
        health -= damage;
        OnStatsChange?.Invoke(health, defense);

        if(health <= 0)
        {
            fightController.EndFight(false);
            OnDeath?.Invoke();
        }
    }
}
