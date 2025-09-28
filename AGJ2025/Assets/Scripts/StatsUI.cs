using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] Slider defenseSlider;

    public void UpdateStats(int health, int defense)
    {
        healthSlider.value = health;
        defenseSlider.value = defense;
    }
}
