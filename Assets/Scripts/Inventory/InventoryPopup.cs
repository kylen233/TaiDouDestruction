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
    public static InventoryPopup _instance;

    void Awake()
    {
        _instance = this;
    }
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    public void OnInventoryClick(InventoryItem it)
    {
        if (it==null||it.Inventory.InventoryType==InventoryType.Equip)
        {
            return;
        }
        inventoryGo.SetActive(true);
        inventoryName.text = it.Inventory.Name;
        inventoryDescribe.text = it.Inventory.Describe;
        Sprite temp = Resources.Load<Sprite>(it.Inventory.Icon);
        inventoryImage.sprite = temp;        
    }

    public void OnCloseButton()
    {
        inventoryGo.SetActive(false);
    }
}
