using System.Collections;
using System.Collections.Generic;
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
    #endregion

    void Awake()
    {


    }
    void Start ()
    {
        //  PlayerInfo._instance.PlayerInfoChangeEvent += PlayerInfoChange;
            Debug.Log(111);
            PlayerInfo._instance.PlayerInfoChangeEvent +=Test;
      
    }

    void Test(int i)
    {
        Debug.Log(i);
    }
    void OnEnable()
    {
       
    }

    //void Init()
    //{
    //    NameText.text = PlayerInfo._instance.Name;
    //    LevelText.text = PlayerInfo._instance.Level.ToString();
    //}

    void PlayerInfoChange(InfoType infoType)
    {
        Debug.Log(11);
        PlayerInfo instance=PlayerInfo._instance;
        if (infoType==InfoType.All)
        {
          
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
   
    // Update is called once per frame
    void Update () {
	  
    }
}
