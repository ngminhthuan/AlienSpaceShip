using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [SerializeField] private PlayerMovement _playerMovement;
    public PlayerMovement PlayerMovement => _playerMovement;

    [SerializeField] private PlayerDataManager _PlayerDataManager;
    public PlayerDataManager PlayerDataManager => _PlayerDataManager;

    [SerializeField] private PlayerShootManager _PlayerShootManager;
    public PlayerShootManager PlayerShootManager => _PlayerShootManager;

   
    void Awake()
    {
        this.Init();
        this.SetPlayerManager();
       

    }
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (GameManager.Instance)
        {
            if (GameManager.Instance.CurrentState == GameState.Playing)
            {
                this._PlayerDataManager.UpdatePlayerSurvivalTime(Time.fixedDeltaTime);
            }

        }
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

    void SetPlayerManager()
    {
        this._playerMovement.SetPlayerManager(this);
        this._PlayerDataManager.SetPlayerManager(this);
    }

    public void Shoot()
    {
        _PlayerShootManager.Shoot();
    }

    public void ResetPlayerData()
    {
        this.PlayerDataManager.InitPlayerData("Test");
    }
}
