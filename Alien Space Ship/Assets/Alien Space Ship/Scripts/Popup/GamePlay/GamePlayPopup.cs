using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GamePlayPopup : UIPopup
{
    [SerializeField] Joystick joystick;
    [SerializeField] Button ShootBtn;
    [SerializeField] Button SettingBtn;
    [SerializeField] PlayerInfoUI playerInfoUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void OnShown(object parament = null)
    {
        base.OnShown(parament);
        this.RegisterActions();
        this.UpdatePlayerHP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RegisterActions()
    {
        this.ShootBtn.onClick.AddListener(() => {
            PlayerManager.Instance.Shoot();
        });
        
        this.SettingBtn.onClick.AddListener(() => {
            UIManager.Instance.ShowPopup(PopupName.PausePopup);
            GameManager.Instance.CurrentState = GameState.Pause;
        });
    }

    void UpdatePlayerHP()
    {
        this.playerInfoUI.SetPlayerDataUI(PlayerManager.Instance.PlayerDataManager.PlayerData);
    }

    public void SetTimeSurvival(float time)
    {
        this.playerInfoUI.SetTimeSurvival(time);
    }
}
