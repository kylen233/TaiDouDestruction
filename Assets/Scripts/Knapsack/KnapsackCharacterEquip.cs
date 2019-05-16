using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KnapsackCharacterEquip : MonoBehaviour,IPointerClickHandler
{
    private Image equipImage;

    public Image EquipImage
    {
        get
        {
            if (equipImage==null)
            {
                equipImage = gameObject.GetComponent<Image>();
            }
             return equipImage;
           
        }

        set
        {
            equipImage = value;
        }
    }

    private InventoryItem it;
    void Start () {
		
	}
	
	
	void Update () {
		
	}

    //public void SetEquipImage(InventoryItem inventoryItem)//更换装备图片
    //{
    //   Sprite equipSprite=  Resources.Load<Sprite>(inventoryItem.Inventory.Icon);
    //    if (equipSprite==null)
    //    {
    //        Debug.Log("查找装备图片失败");
    //    }
    //    else
    //    {
    //       EquipImage.sprite = equipSprite;
    //    }
    //}
    public void SetInventoryItem(InventoryItem _inventoryItem)
    {
        if (_inventoryItem==null)return;
        it = _inventoryItem;
        Sprite equipSprite = Resources.Load<Sprite>(it.Inventory.Icon);
        EquipImage.sprite = equipSprite;

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        EquipPopup._instance.OnEquipClick(it, true,null);
    }
}
