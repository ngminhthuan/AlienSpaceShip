using UnityEngine;

public class PlayerDataManager : APlayerComponent
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerData PlayerData;

    public void InitPlayerData(string playerName)
    {
        PlayerData = new PlayerData();
        PlayerData.PlayerName = playerName;
        PlayerData.HP = PlayerDataConst.MAXHP;
        PlayerData.survivalTime = 0;
    }

    public void UpdatePlayerSurvivalTime(float timeDelta)
    {
        PlayerData.survivalTime += timeDelta;
        UIManager.Instance.GetPopupByName(PopupName.GamePlayPopup).GetComponent<GamePlayPopup>().SetTimeSurvival(PlayerData.survivalTime);  
    }
}
