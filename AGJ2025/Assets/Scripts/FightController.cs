using UnityEngine;
using UnityEngine.Events;

public class FightController : MonoBehaviour
{
    public static FightController Instance { get; private set; }

    public Enemy currentEnemy;

    public UnityEvent OnFightStart;
    public UnityEvent<CurrentTurn> OnTurnEnd;

    public CurrentTurn currentTurn;
    public enum CurrentTurn
    {
        Player,
        Enemy
    }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    public void StartFight()
    {
        // GameManager.Instance.SetGameState(GameState.InCombat);
        OnFightStart?.Invoke();
    }

    [ContextMenu("End Turn")]
    public void EndTurn()
    {
        currentTurn = currentTurn == CurrentTurn.Player ? CurrentTurn.Enemy : CurrentTurn.Player;
        OnTurnEnd?.Invoke(currentTurn);
    }
}
