using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityItem : MonoBehaviour
{
    FightController fightController;

    Ability ability;
    AbilitySO abilitySO;

    [SerializeField] AudioSource audioSource;

    [SerializeField] Button abilityButton;
    [SerializeField] TMP_Text abilityNameText;
    [SerializeField] TMP_Text abilityCountText;

    private void Start()
    {
        fightController = FightController.Instance;
    }

    public void SetAbilityItem(Ability ability)
    {
        this.ability = ability;
        abilitySO = ability.abilitySO;
        abilityNameText.text = abilitySO.abilityName;
        UpdateItemCount(ability.count);
    }

    public void UseAbility()
    {
        fightController.currentEnemy.TakeDamage(abilitySO.attack);
        fightController.player.ApplyDefense(abilitySO.defense);

        audioSource.PlayOneShot(abilitySO.abilitySfx);

        ability.count--;
        UpdateItemCount(ability.count);
        fightController.EndTurn();
    }

    void UpdateItemCount(int count)
    {
        abilityCountText.text = $"{count}x";
        if (count <= 0)
        {
            ToggleAbilityButton(false);
        }
    }

    public bool CanUse()
    {
        return ability.count > 0;
    }

    public void ToggleAbilityButton(bool isActive)
    {
        abilityButton.interactable = isActive;
    }
}
