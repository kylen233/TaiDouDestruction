using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class KnapsackCharacter : MonoBehaviour
{
    public KnapsackCharacterEquip helmImage;
    public KnapsackCharacterEquip weaponImage;
    public KnapsackCharacterEquip wingImage;
    public KnapsackCharacterEquip ShoesImage;
    public KnapsackCharacterEquip clothImage;
    public KnapsackCharacterEquip braceletImage;
    public KnapsackCharacterEquip necklaceImage;
    public KnapsackCharacterEquip ringImage;
    public Text hpText;
    public Text damageText;
    public Text expText;
    public Slider expSlider;

    void Awake()
    {
        PlayerInfo._instance.PlayerInfoChangeEvent += KnapsackCharacterInfoChange;
    }
    void Start()
    {
     
    }

    void OnDestroy()
    {
        PlayerInfo._instance.PlayerInfoChangeEvent -= KnapsackCharacterInfoChange;
    }
	void Update () {
		
	}

    public void KnapsackCharacterInfoChange(InfoType infoType)
    {
       
        if (infoType==InfoType.All||infoType == InfoType.Hp||infoType==InfoType.Exp||infoType==InfoType.Damage||infoType == InfoType.Equip)
        {
            Debug.Log("更新了");
            UpdateShow();
        }
    }

    void UpdateShow()
    {
        PlayerInfo _playerInfo=PlayerInfo._instance;
        helmImage.SetInventoryItem(_playerInfo.HelmInventoryItem);
        weaponImage.SetInventoryItem(_playerInfo.WeaponInventoryItem);
        wingImage.SetInventoryItem(_playerInfo.WingInventoryItem);
        ShoesImage.SetInventoryItem(_playerInfo.ShoesInventoryItem);
        clothImage.SetInventoryItem(_playerInfo.ClothInventoryItem);
        braceletImage.SetInventoryItem(_playerInfo.BraceletInventoryItem);
        necklaceImage.SetInventoryItem(_playerInfo.NecklaceInventoryItem);
        ringImage.SetInventoryItem(_playerInfo.RingInventoryItem);
        hpText.text = _playerInfo.Hp.ToString();
        expText.text = _playerInfo.Exp.ToString() + "/" + MyTool.GetExpValue(_playerInfo.Level + 1);
        expSlider.value = (float)_playerInfo.Exp / MyTool.GetExpValue(_playerInfo.Level + 1);
        damageText.text = _playerInfo.Damage.ToString();
    }

   

   

}
