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
    public InventoryItemUI currentItUI;
    public Text equipButtonText;
    void Awake()
    {
        _instance = this;
    }
	void Start () {
		
	}

    public void UpgradeEquip()
    {
        int needCoin = (currentIt.Level + 1) * currentIt.Inventory.Price;
        if (PlayerInfo._instance.GetCoin(needCoin))
        {
            currentIt.Level++;
            LevelText.text = "等级" + "     " + currentIt.Level.ToString();
            Debug.Log("装备升级成功");
            return;
        }
        Debug.Log("升级失败");
    }
    public  void OnEquipClick(InventoryItem it,bool isLeft,InventoryItemUI itui,KnapsackCharacterEquip kcep)//当装备被点击是弹出装备信息
    {
        if (it == null||it.Inventory.InventoryType!=InventoryType.Equip) return;
        Vector3 tempPos = EquipPopupGo.transform.localPosition;
        currentIt = it;
        currentItUI = itui;
        if (!isLeft)
        { 
            equipButtonText.text = "装备";
        }
        else
        {
            EquipCharacterPopupGo.SetActive(true);
            EquipCharacterPopup._instance.UpdateShow(it,itui,kcep);
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

    public void OnCloseClick()//关闭窗口
    {
        currentIt = null;
        EquipPopupGo.SetActive(false);
    }
    public void OnDresseEquip()//穿上装备
    {
        EquipPopupGo.SetActive(false);
        PlayerInfo._instance.DressEquip(currentIt);
        currentItUI.Clear();
        currentIt = null; 
      
    }

   

}
