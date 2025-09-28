using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Events;

public class FightController : MonoBehaviour
{
    public static FightController Instance { get; private set; }

    GameManager gameManager;

    public Enemy currentEnemy;
    public Player player;

    public GameObject[] Words;

    public UnityEvent OnFightStart;
    public UnityEvent<bool> OnFightEnd;
    public UnityEvent<CurrentTurn> OnTurnEnd;
    public GameObject wordSpawnLocation;

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

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void StartFight()
    {
        gameManager.SetGameState(GameState.InCombat);
        OnFightStart?.Invoke();
    }

    public void EndTurn()
    {
        currentTurn = currentTurn == CurrentTurn.Player ? CurrentTurn.Enemy : CurrentTurn.Player;
        OnTurnEnd?.Invoke(currentTurn);
        SpawnRandomWord();
    }

    void SpawnRandomWord()
    {
        int randomIndex = Random.Range(0, Words.Length);
        GameObject tmpWord = Instantiate(Words[randomIndex], wordSpawnLocation.transform.position, Quaternion.identity);
    }

    public void EndFight(bool isWinForPlayer)
    {
        gameManager.SetGameState(GameState.GameOver);
        OnFightEnd?.Invoke(isWinForPlayer);
    }
}
