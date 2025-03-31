using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
public class StartGamePopup : UIPopup
{
    [SerializeField] Button _StartGameBtn;
    [SerializeField] Button _SettingBtn;
    [SerializeField] Button _ExitGameBtn;

    public override void OnShown(object parament = null)
    {
        base.OnShown(parament);
        this.RegisterButtonEvents();
    }
    void RegisterButtonEvents()
    {
        _StartGameBtn.onClick.AddListener(() =>
        {
            this.OnHide();
            GameManager.Instance.StartGame();
            UIManager.Instance.ShowPopup(PopupName.GamePlayPopup);
        });

        _SettingBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPopup(PopupName.SettingPopup);
        });

        _ExitGameBtn.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
                    Application.Quit();
#endif
        });
    }
}
