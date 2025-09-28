using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>  </summary>
    [SerializeField]private bool dontDestroyOnLoad = true;
    [SerializeField]private CinemachineCamera introCam;
    
    //Rand INIT implementation of Singleton pattern for GameManager assinging Instance as a property. free to modify as needed.
    void Awake()
    {
        ImplementSingletonPattern();
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        if (introCam != null)
        {
            introCam.enabled = true;
            introCam.gameObject.SetActive(true);
        }
    }

    private bool ImplementSingletonPattern()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return false;
        }
        else
        {
            Instance = this;
            return true;
        }
    }

    public static GameManager Instance { get; private set; }
    public GameState CurrentGameState { get; private set; } = GameState.OutOfCombat;

    public void SetGameState(GameState newState)
    {
        CurrentGameState = newState;
    }

    public void SetGameState(int newStateIndex)
    {
        CurrentGameState = (GameState)(int)newStateIndex;
    }
}

public enum GameState
{
    OutOfCombat = 0,
    InCombat = 1,
    GameOver = 2,
}