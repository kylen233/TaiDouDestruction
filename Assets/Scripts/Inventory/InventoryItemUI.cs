using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class InventoryItemUI : MonoBehaviour,IPointerClickHandler
{

    private Image invenroyImage;
    private Text  inventoryNumberText;
    public InventoryItem inventoryItem;
    public bool isDress = false;

    public Image InvenroyImage
    {
        get
        {
            if (invenroyImage==null)
            {
                invenroyImage = gameObject.GetComponent<Image>();
            }

            return invenroyImage;
        }

        set
        {
            invenroyImage = value;
        }
    }

    public Text InventoryNumberText
    {
        get
        {
            if (inventoryNumberText==null)
            {
                inventoryNumberText = transform.Find("Text").GetComponent<Text>();
               
            }
            return inventoryNumberText;
        }

        set
        {
            inventoryNumberText = value;
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeCount(int count)
    {
        inventoryItem.Count--;
        if (inventoryItem.Count<=0)
        {
            Clear();
            return;
        }  
        if (inventoryItem.Count==1)
        {
            InventoryNumberText.text = "";
            return;
        }
        else
        {
            InventoryNumberText.text = inventoryItem.Count.ToString();

        }
    }
    public void SetInventoryItem(InventoryItem inventoryItem)//设置物品
    {
        if (inventoryItem==null)
        {
            return;
        }
        string imageName = inventoryItem.Inventory.Icon;
        Sprite temp= Resources.Load<Sprite>(imageName);
        InvenroyImage.sprite = temp;
        int number = inventoryItem.Count;
        if (number<=1)
        {
            InventoryNumberText.text = "";
        }
        else
        {
            InventoryNumberText.text = number.ToString();
        }
        this.inventoryItem = inventoryItem;
    }

    public void Clear()//清除信息
    {
        Sprite temp = Resources.Load<Sprite>("bg_道具");
        InvenroyImage.sprite = temp;
        InventoryNumberText.text = "";
        inventoryItem = null;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        EquipPopup._instance.OnEquipClick(inventoryItem,false,this,null);
        InventoryPopup._instance.OnInventoryClick(inventoryItem,this);
    }

  
}
