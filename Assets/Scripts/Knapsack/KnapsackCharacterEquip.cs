using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnapsackCharacterEquip : MonoBehaviour
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

    void Start () {
		
	}
	
	
	void Update () {
		
	}

    public void SetEquipImage(string equipName)//更换装备图片
    {
       Sprite equipSprite=  Resources.Load<Sprite>(equipName);
        if (equipSprite==null)
        {
            Debug.Log("查找装备图片失败");
        }
        else
        {
           EquipImage.sprite = equipSprite;
        }
    }
}
