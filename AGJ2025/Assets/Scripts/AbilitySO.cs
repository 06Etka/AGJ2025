using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AbilitySO", menuName = "Scriptable Objects/AbilitySO")]
public class AbilitySO : ScriptableObject
{
    public string abilityName;
    [Tooltip("Amount of attack")]
    public int attack;
    [Tooltip("Amount of defense")]
    public int defense;
    [Tooltip("Use Random Audio Container!!!")]
    public AudioResource abilitySfx;

}
