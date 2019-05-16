using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayBar : MonoBehaviour
{
    #region//UI控件

    public Image HeadSprite; //男0 女1
    public Text NameText;
    public Text LevelText;
    public Text ToughenText;  //历练
    public Text EnergyText;   //体力
    public Slider ToughenSlider;
    public Slider EnergSlider;
    public Button EnergPlusButton;
    public Button ToughenPlusButton;
    public Button HeadSpiteButton;
    #endregion

    void Awake()
    {

        PlayerInfo._instance.PlayerInfoChangeEvent += PlayerBarInfoChange;
    }
    
    void Start ()
    {

     
        HeadSpiteButton.onClick.AddListener(delegate () { PlayerStatus.ShowOrHidePlayStatus(DotweenDir.forward); });
    }

    void OnDestroy()
    {
        PlayerInfo._instance.PlayerInfoChangeEvent -= PlayerBarInfoChange;
    }

/// <summary>
/// 响应注册事件
/// </summary>
/// <param name="infoType"></param>
 private   void PlayerBarInfoChange(InfoType infoType)
    {

        PlayerInfo instance=PlayerInfo._instance;
        if (infoType==InfoType.All)
        {
            //TouXiangTODO
            NameText.text = instance.Name;
            LevelText.text = instance.Level.ToString();
            EnergyText.text = instance.Energy.ToString() + "/100";
            EnergSlider.value = instance.Energy / 100f;
            ToughenText.text = instance.Toughen.ToString() + "/50";
            ToughenSlider.value = instance.Toughen / 50f;
            return;
        }
        switch (infoType)
        {
            case InfoType.HeadSprite:
                 //TODO
                break;
            case InfoType.Name:
                NameText.text = instance.Name;
                break;
            case InfoType.Level:
                LevelText.text = instance.Level.ToString();
                break;
            case InfoType.Energy:
                EnergyText.text = instance.Energy.ToString()+"/100";
                EnergSlider.value = instance.Energy / 100f;
                break;
            case InfoType.Toughen:
                ToughenText.text = instance.Toughen.ToString()+"/50";
                ToughenSlider.value = instance.Toughen / 50f;
                break;
        }
    }
/// <summary>
/// 显示隐藏人物状态面板
/// </summary>
/// <param name="dotweenDir"></param>
 

}
