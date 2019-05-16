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

    public void UpdateShow(InventoryItem it)
    {
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
    public void OnCloseClick()
    {
        EquipCharacterPopupGo.SetActive(false);
    }
}
