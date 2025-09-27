using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager Instance { get; private set; }

    [SerializeField] GameObject fightMenu;

    [SerializeField] Transform abilityHolder;
    [SerializeField] AbilityItem abilityItem;

    [SerializeField] List<Ability> abilities = new List<Ability>();
    List<AbilityItem> abilityItems = new List<AbilityItem>();

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        if(abilities.Count <= 0)
        {
            Debug.LogError($"There are no abilities!", this);
        }

        if (fightMenu.activeInHierarchy)
            ToggleFightMenu(false);

        InstantiateAbilities();
    }

    void InstantiateAbilities()
    {
        foreach (var ability in abilities)
        {
            AbilityItem newAbilityItem = Instantiate(abilityItem, abilityHolder);
            newAbilityItem.SetAbilityItem(ability);
            abilityItems.Add(newAbilityItem);
        }
    }

    public void CheckTurn(FightController.CurrentTurn currentTurn)
    {
        foreach (var abilityItem in abilityItems)
        {
            abilityItem.ToggleAbilityButton(currentTurn == FightController.CurrentTurn.Player && abilityItem.CanUse());
        }
    }

    public void ToggleFightMenu(bool isActive)
    {
        fightMenu.SetActive(isActive);
    }

    public Ability GetAbility(AbilitySO abilitySO)
    {
        return abilities.Find(a => a.abilitySO == abilitySO);
    }

    public int GetAbilityCount(AbilitySO ability)
    {
        return abilities.FindAll(a => a.abilitySO == ability).Count;
    }
}
