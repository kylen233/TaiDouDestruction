using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPopup : MonoBehaviour
{
    public Text inventoryName;
    public Text inventoryDescribe;
    public Image inventoryImage;
    public GameObject inventoryGo;
    private InventoryItem currentItem;
    private InventoryItemUI currentItemUI;
    public static InventoryPopup _instance;

    void Awake()
    {
        _instance = this;
    }
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    public void OnUse()
    {
        currentItemUI.ChangeCount(1);
        PlayerInfo._instance.UseInventory(currentItem);
    }
    public void OnUseBatching()
    {
        currentItemUI.ChangeCount(currentItem.Count);
    }
    public void OnInventoryClick(InventoryItem it,InventoryItemUI itUi)//物品被点击
    {
        if (it==null||it.Inventory.InventoryType==InventoryType.Equip)
        {
            return;
        }
        currentItem = it;
        currentItemUI = itUi;
        inventoryGo.SetActive(true);
        inventoryName.text = it.Inventory.Name;
        inventoryDescribe.text = it.Inventory.Describe;
        Sprite temp = Resources.Load<Sprite>(it.Inventory.Icon);
        inventoryImage.sprite = temp;        
    }

    public void Clear()
    {
        currentItem = null;
        currentItemUI = null;
    }
    public void OnCloseButton()
    {
        Clear();
        inventoryGo.SetActive(false);
    }
}
