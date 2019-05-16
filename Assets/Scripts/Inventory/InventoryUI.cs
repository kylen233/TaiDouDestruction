using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public List<InventoryItemUI> InventoryItemUIList;
    public static InventoryUI _instance;
    void Awake()
    {
        _instance = this;
        InventoryManager._instance.OnInventoryItemChangeEvent += OnInvnetoryChange;
    }

    void OnDestroy()
    {
        InventoryManager._instance.OnInventoryItemChangeEvent -= OnInvnetoryChange;
    }
    void OnInvnetoryChange()
    {
        UpdateShow();
    }

    void UpdateShow()//更新物品信息
    {
       
        for (int i = 0; i < InventoryManager._instance.inventoryItemList.Count; i++)
        {
            InventoryItemUIList[i].SetInventoryItem(InventoryManager._instance.inventoryItemList[i]);
        }

        for (int i = InventoryManager._instance.inventoryItemList.Count; i < InventoryItemUIList.Count; i++)
        {
            InventoryItemUIList[i].Clear();
        }
    }

   public void AddInventoryItem(InventoryItem it)
    {

        foreach (InventoryItemUI itUI in InventoryItemUIList)
        {
            if (itUI.inventoryItem==null)
            {
                itUI.SetInventoryItem(it);
                break;  
            }
        }
    }

}
