using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipCharacterPopup : MonoBehaviour {
    public Image equipImage;
    public Text equipNameText;
    public Text qualityText;
    public Text hpText;
    public Text LevelText;
    public Text describeText;
    public Text powerText;
    public GameObject EquipCharacterPopupGo;
    private InventoryItem currentIt;
    private InventoryItemUI currentItUI;
    public static EquipCharacterPopup _instance;
    private KnapsackCharacterEquip kcep;
    void Awake()
    {
        _instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpgradeEquip()//升级装备
    {
        int needCoin = (currentIt.Level + 1) * currentIt.Inventory.Price;
        if (PlayerInfo._instance.GetCoin(needCoin))
        {
            currentIt.Level++;
            LevelText.text = "等级" + "     "+ currentIt.Level.ToString();
            Debug.Log("装备升级成功");
            return;
        }
        Debug.Log("升级失败");
    }
    public void UpdateShow(InventoryItem it,InventoryItemUI itui,KnapsackCharacterEquip kcep)//更新身上的装备图标
    {
        currentIt = it;
        this.kcep = kcep;
        Sprite temp = Resources.Load<Sprite>(it.Inventory.Icon);
        equipImage.sprite = temp;
        equipImage.sprite = temp;
        equipNameText.text = it.Inventory.Name;
        qualityText.text = "品质" + "     " + it.Inventory.Quality;
        hpText.text = "生命" + "     " + it.Inventory.Hp;
        LevelText.text = "等级" + "     " + it.Level;
        describeText.text = it.Inventory.Describe;
        powerText.text = "战斗力" + "  " + it.Inventory.Power;
    }

    public void PutoffEquip()//脱下装备
    {
        
      
        PlayerInfo._instance.PutoffEquip(currentIt);
        kcep.Clear();
        currentIt = null;
        EquipCharacterPopupGo.SetActive(false);

    }
    public void OnCloseClick()//关闭弹窗
    {
        EquipCharacterPopupGo.SetActive(false);
    }
}
