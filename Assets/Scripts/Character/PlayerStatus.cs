using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    public Button CloseButton;
    public static PlayerStatus _instance;
   

    void Awake()
    {
        _instance = this;
        PlayerInfo._instance.PlayerInfoChangeEvent += PlayerStatusInfoChange;
        CloseButton.onClick.AddListener(delegate() { ShowOrHidePlayStatus(DotweenDir.back);});
    }
	void Start () {
		
	}
	

	void Update () {
	 
	}
  /// <summary>
  /// 响应注册事件
  /// </summary>
  /// <param name="infoType"></param>
    private void PlayerStatusInfoChange(InfoType infoType)

    {
        PlayerInfo _instancePlayerInfo = PlayerInfo._instance;
        if (infoType==InfoType.All)
        {
            //touxiangTODO
            LvText.text = _instancePlayerInfo.Level.ToString();
            NameText.text = _instancePlayerInfo.Name;
            PowerText.text = _instancePlayerInfo.Power.ToString();
            ExpText.text = _instancePlayerInfo.Exp.ToString() + "/" + MyTool.GetExpValue(_instancePlayerInfo.Level);
            ExpSlider.value = (float)_instancePlayerInfo.Exp / MyTool.GetExpValue(_instancePlayerInfo.Level);
            DimondText.text = _instancePlayerInfo.Diamond.ToString();
            CoinText.text = _instancePlayerInfo.Coin.ToString();
            SparText.text = _instancePlayerInfo.Spar.ToString();
            SideriText.text = _instancePlayerInfo.Siderite.ToString();   
            return;
        }
        switch (infoType)
        {
            case InfoType.Energy:
                UptateEnergyAndToughen();
                break;
            case InfoType.Toughen:
                UptateEnergyAndToughen();
                break;
        }

    }
 /// <summary>
 /// 更新体力和历练
 /// </summary>
    void UptateEnergyAndToughen()   
    {
        PlayerInfo _instancePlayerInfo = PlayerInfo._instance;
        EnergyText.text = _instancePlayerInfo.Energy.ToString() + "/100";
        ToughenText.text = _instancePlayerInfo.Toughen.ToString() + "/50";
        if (_instancePlayerInfo.Energy>=100)
        {
            EnergyRecoverText.text = "00 : 00 : 00";
            EnergyAllRecoverText.text = "00 : 00 : 00";
        }
        else
        {

            int remainTime = 60 - (int)_instancePlayerInfo.energyTimer;
            string str = remainTime > 9 ? remainTime.ToString() : "0" + remainTime.ToString();
            EnergyRecoverText.text = "00 : 00 : " + str;
            int remainEnergy = 99 - _instancePlayerInfo.Energy;
            int hour = remainEnergy / 60;
            int minute = remainEnergy % 60;
            string str3 = hour > 0 ? "0" + hour.ToString() + " : " : "00 :";

            string str2 = minute> 9 ? minute.ToString() : "0" + minute.ToString();
            EnergyAllRecoverText.text = str3 + str2 + " : " + str;

        }
        if (_instancePlayerInfo.Toughen >=50)
        {
            ToughenRecoverText.text = "00 : 00 : 00";
            TouchenAllRecoverText.text = " 00 : 00 : 00";
        }
        else
        {
            int remainTime = 60 - (int)_instancePlayerInfo.toughenTimer;
            string str = remainTime > 9 ? remainTime.ToString() : "0" + remainTime.ToString();
            ToughenRecoverText.text = "00 : 00 : " + str;
            int remainToughen = 49 - _instancePlayerInfo.Toughen;
            string str2 = remainToughen > 9 ? remainToughen.ToString() : "0" + remainToughen;
            TouchenAllRecoverText.text = "00 : " + str2 + " : " + str;
        }


    }
    /// <summary>
   /// 显示或隐藏人物状态面板
   /// </summary>
   /// <param name="dotweenDir"></param>
    public static void ShowOrHidePlayStatus(DotweenDir dotweenDir)
    {
        DOTweenAnimation _doTween = GameObject.Find("PlayerStatus").GetComponent<DOTweenAnimation>();
        if (_doTween == null)
        {
            Debug.Log("animation is null");
            return;
        }
        if (dotweenDir == DotweenDir.forward)
        {
            _doTween.DOPlayForward();
        
        }
        else
        {
            _doTween.DOPlayBackwards();
            
        }
    }

}
 