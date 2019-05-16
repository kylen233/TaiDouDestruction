using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBar : MonoBehaviour
{

    public Text DiamondText;
    public Text CoinText;
    public Button DiamondPulsButton;
    public Button CoinPulsButton;
    void Awake()
    {
        PlayerInfo._instance.PlayerInfoChangeEvent += TopBarInfoChange;
    }
    void Start ()
	{
	   
	    DiamondPulsButton.onClick.AddListener(DiamondPulsOnClick);
	    CoinPulsButton.onClick.AddListener(CoinPulsOnClick);

    }

    void OnDestroy()
    {
        PlayerInfo._instance.PlayerInfoChangeEvent -= TopBarInfoChange;
    }
    /// <summary>
    /// 钻石增加
    /// </summary>
    public void DiamondPulsOnClick()  
    {

    }
    /// <summary>
    /// 金币增加
    /// </summary>
    public void CoinPulsOnClick()
    {

    }
    private void TopBarInfoChange(InfoType infoType)
    {
        PlayerInfo _instancePlayerInfo = PlayerInfo._instance;
        if (infoType==InfoType.All)
        {
            DiamondText.text = _instancePlayerInfo.Diamond.ToString();
            CoinText.text = _instancePlayerInfo.Coin.ToString();
            return;
        }
        switch (infoType)
        {
            case InfoType.Diamond:
                DiamondText.text = _instancePlayerInfo.Diamond.ToString();
                break;
            case InfoType.Coin:
                CoinText.text = _instancePlayerInfo.Coin.ToString();
                break;
           
        }
    }
	void Update () {
		
	}
}
