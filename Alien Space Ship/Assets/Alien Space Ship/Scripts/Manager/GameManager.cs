using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState = GameState.Start;

    public EnemyManager EnemyManager;

    void Awake()
    {
        Init();
        CurrentState = GameState.Start;
        this.SetFPSandVsync();
    }
    void Init()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetFPSandVsync()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    public void StartGame()
    {
        CurrentState = GameState.Playing;
        EnemyManager.DeactiveEnemy();
        PlayerManager.Instance.ResetPlayerData();
    }

    public void StopGame()
    {
        CurrentState = GameState.Start;
        EnemyManager.DeactiveEnemy();
    }
}

public enum GameState
{
    Start,
    Playing,
    Pause,
    End,
    
}