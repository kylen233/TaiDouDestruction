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

    public  InventoryItem it;
    public static KnapsackCharacterEquip _instance;

    void Awake()
    {
        _instance = this;
    }
    void Start () {
		
	}
	
	
	void Update () {
		
	}


    public void SetInventoryItem(InventoryItem _inventoryItem)
    {
        if (_inventoryItem==null)return;
        it = _inventoryItem;
        Sprite equipSprite = Resources.Load<Sprite>(it.Inventory.Icon);
        EquipImage.sprite = equipSprite;

    }

    public void Clear()
    {
        Sprite temp = Resources.Load<Sprite>("bg_道具");
        equipImage.sprite = temp;
        it = null;
        

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        EquipPopup._instance.OnEquipClick(it, true,null,this);
    }
}
