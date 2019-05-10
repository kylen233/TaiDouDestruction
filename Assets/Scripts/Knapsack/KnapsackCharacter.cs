using System.Collections;
using System.Collections.Generic;
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
	
	void Update () {
		
	}

    public void KnapsackCharacterInfoChange(InfoType infoType)
    {
        if (infoType==InfoType.All||infoType == InfoType.Hp||infoType==InfoType.Exp||infoType==InfoType.Damage)
        {
            UpdateShow();
        }
    }

    void UpdateShow()
    {
        PlayerInfo _playerInfo=PlayerInfo._instance;
        helmImage.SetEquipImage(GetEquipName(_playerInfo.HelmID));
        weaponImage.SetEquipImage(GetEquipName(_playerInfo.WeaponID));
        wingImage.SetEquipImage(GetEquipName(_playerInfo.WingID));
        ShoesImage.SetEquipImage(GetEquipName(_playerInfo.ShoesID));
        clothImage.SetEquipImage(GetEquipName(_playerInfo.ClothID));
        braceletImage.SetEquipImage(GetEquipName(_playerInfo.BraceletID));
        necklaceImage.SetEquipImage(GetEquipName(_playerInfo.NecklaceID));
        ringImage.SetEquipImage(GetEquipName(_playerInfo.RingID));
        hpText.text = _playerInfo.Hp.ToString();
        expText.text = _playerInfo.Exp.ToString() + "/" + MyTool.GetExpValue(_playerInfo.Level + 1);
        expSlider.value = (float) _playerInfo.Exp / MyTool.GetExpValue(_playerInfo.Level + 1);
        damageText.text = _playerInfo.Damage.ToString();
    }

    string GetEquipName(int id)
    {
        Inventory _inventory = null;
        bool isExit = InventoryManager._instance.inventoryDic.TryGetValue(id, out _inventory);
        if (isExit)
        {
            return _inventory.Icon;
        }
        else
        {
            return null;
        }
    }
}
