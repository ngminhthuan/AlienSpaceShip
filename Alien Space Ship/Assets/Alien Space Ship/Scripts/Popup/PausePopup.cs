using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
public class PausePopup : UIPopup
{
    [SerializeField] private Button settingButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button backButton;


    public override void OnShown(object parament = null)
    {
        base.OnShown(parament);
        this.RegisterEvents();
    }

    public override void OnHide()
    {
        base.OnHide();
        GameManager.Instance.CurrentState = GameState.Playing;
    }
    void RegisterEvents()
    {

        settingButton.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPopup(PopupName.SettingPopup);
        });
        menuButton.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePopup(PopupName.PausePopup);
            UIManager.Instance.HidePopup(PopupName.GamePlayPopup);
            UIManager.Instance.ShowPopup(PopupName.StartGamePopup);
            GameManager.Instance.StopGame();
        });

        backButton.onClick.AddListener(() => { this.OnHide(); });
    }
}
