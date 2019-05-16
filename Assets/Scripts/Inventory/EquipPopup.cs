using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipPopup : MonoBehaviour
{

    public Image equipImage;
    public Text equipNameText;
    public Text qualityText;
    public Text hpText;
    public Text LevelText;
    public Text describeText;
    public Text powerText;
    public static EquipPopup _instance;
    public GameObject EquipPopupGo;
    public GameObject EquipCharacterPopupGo;
    private InventoryItem currentIt;
    private InventoryItemUI currentItUI;
    public Text equipButtonText;
    void Awake()
    {
        _instance = this;
    }
	void Start () {
		
	}

    public  void OnEquipClick(InventoryItem it,bool isLeft,InventoryItemUI itui)//当装备被点击是弹出装备信息
    {
        if (it == null||it.Inventory.InventoryType!=InventoryType.Equip) return;
        Vector3 tempPos = EquipPopupGo.transform.localPosition;
        if (!isLeft)
        {
            
            currentIt = it;
            currentItUI = itui;
            equipButtonText.text = "装备";
        }
        else
        {
            EquipCharacterPopupGo.SetActive(true);
            EquipCharacterPopup._instance.UpdateShow(it);
            return;
        }
        EquipPopupGo.SetActive(true);
        Sprite temp = Resources.Load<Sprite>(it.Inventory.Icon);
        equipImage.sprite = temp;
        equipNameText.text = it.Inventory.Name;
        qualityText.text = "品质" + "     " + it.Inventory.Quality;
        hpText.text = "生命" + "     " + it.Inventory.Hp;
        describeText.text = it.Inventory.Describe;
        powerText.text = "战斗力" + "  " + it.Inventory.Power;
        LevelText.text = "等级" + "     " + it.Level;
    }

    public void OnCloseClick()
    {
        currentIt = null;
        EquipPopupGo.SetActive(false);
    }
    public void OnDresseEquip()
    {
        EquipPopupGo.SetActive(false);
        PlayerInfo._instance.DressEquip(currentIt);
        currentItUI.Clear();
        currentIt = null; 
        currentItUI = null;
       
    }

}
