using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text timeSurval;
    [SerializeField] private Slider HPSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }

    public void SetPlayerDataUI(PlayerData playerData)
    {
        this.playerName.text = playerData.PlayerName;
        this.SetHP(playerData.HP, PlayerDataConst.MAXHP);
        this.timeSurval.text = "0";

    }
    public void SetHP(float currentHP, float maxHP)
    {
        HPSlider.maxValue = maxHP;
        HPSlider.value = currentHP;
    }

    public void SetTimeSurvival(float time)
    {
        this.timeSurval.text = time.ToString();
    }
}
