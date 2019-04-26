using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Image HeadPortrait; //头像
    public Text LvText;    //等级
    public Text NameText;  //角色名
    public Text PowerText; //战斗力
    public Text ExpText;   //经验值
    public Slider ExpSlider; //经验条
    public Text DimondText;  //钻石
    public Text CoinText;    //金币
    public Text SparText;    //晶石
    public Text SideriText;  //陨铁
    public Text EnergyText;   //体力
    public Text ToughenText;  //历练
    public Text EnergyRecoverText;//体力恢复时间
    public Text EnergyAllRecoverText;//体力全部恢复时间
    public Text ToughenRecoverText; //历练恢复时间
    public Text TouchenAllRecoverText; //历练全部恢复时间

    void Awake()
    {
        PlayerInfo._instance.PlayerInfoChangeEvent += PlayerStatusInfoChange;
    }
	void Start () {
		
	}
	

	void Update () {
	     
	}

    private void PlayerStatusInfoChange(InfoType infoType)
    {
        PlayerInfo _instancePlayerInfo = PlayerInfo._instance;
        if (infoType==InfoType.All)
        {
            //touxiangTODO
            LvText.text = _instancePlayerInfo.Level.ToString();
            NameText.text = _instancePlayerInfo.Name;
            PowerText.text = _instancePlayerInfo.Power.ToString();
            ExpText.text = _instancePlayerInfo.Exp.ToString() + "/500";
            ExpSlider.value = _instancePlayerInfo.Exp / 500f;
            DimondText.text = _instancePlayerInfo.Diamond.ToString();
            CoinText.text = _instancePlayerInfo.Coin.ToString();
            SparText.text = _instancePlayerInfo.Spar.ToString();
            SideriText.text = _instancePlayerInfo.Siderite.ToString();
            EnergyText.text = _instancePlayerInfo.Energy.ToString() + "/100";
            ToughenText.text = _instancePlayerInfo.Toughen.ToString() + "/50";
            
        }
    }
}
