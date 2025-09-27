using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    FightController fightController;

    [SerializeField] int maxHealth;
    int health;
    int defense;

    [SerializeField] List<AbilitySO> abilities = new List<AbilitySO>();

    public UnityEvent<float> OnTakeDamage;
    public UnityEvent OnDeath;

    void Start()
    {
        fightController = FightController.Instance;
        health = maxHealth;
    }

    void ApplyDefense(int amount)
    {
        defense += amount;
    }

    public void TakeDamage(int damage)
    {
        if (defense > 0)
        {
            if(damage >= defense)
            {
                damage -= defense;
                defense = 0;
            } else
            {
                defense -= damage;
                damage = 0;
            }
        }
        health -= damage;

        if (health <= 0)
        {
            fightController.EndFight(true);
            OnDeath?.Invoke();
        }
        OnTakeDamage?.Invoke(health);
    }

    public void CheckTurn(FightController.CurrentTurn currentTurn)
    {
        if(currentTurn == FightController.CurrentTurn.Enemy)
        {
            Invoke(nameof(PlayAbility), Random.Range(2.0f, 5.0f));
        }
    }

    public void PlayAbility()
    {
        // for now enemy will choose random ability
        print($"Enemy playing an ability");
        AbilitySO abilityToPlay = abilities[Random.Range(0, abilities.Count)];
        FightController.Instance.player.TakeDamage(abilityToPlay.attack);
        ApplyDefense(abilityToPlay.defense);
        FightController.Instance.EndTurn();
    }
}
