using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InventoryManager : MonoBehaviour
{

    private TextAsset inventoryInfoList;
    public Dictionary<int, Inventory> inventoryDic=new Dictionary<int, Inventory>();
  //  private Dictionary<int,InventoryItem> inventoryItemDic=new Dictionary<int, InventoryItem>();
    public List<InventoryItem> inventoryItemList = new List<InventoryItem>();
    public static InventoryManager _instance;
    public delegate void OnInvetoryItemChange();
    public event OnInvetoryItemChange OnInventoryItemChangeEvent;

    void Awake()
    {
        _instance = this;
        ReadInventoryInfo();
        ReadInventoryItemInfo();
    }
	

    void ReadInventoryInfo()//初始化物品信息
    {
        inventoryInfoList = Resources.Load<TextAsset>("InventoryInfoList");
        if (inventoryInfoList == null)
        {
            Debug.LogWarning("读取物品信息失败");
            return;
        }
        else
        {

            string[] inventoryInfoArray = inventoryInfoList.ToString().Split('\n');
            foreach (string inventoryItem in inventoryInfoArray)
            {
                string[] inventoryAttribute = inventoryItem.Split('|');
                Inventory _inventoryTemp = new Inventory();
                _inventoryTemp.Id = Int32.Parse(inventoryAttribute[0]);
                _inventoryTemp.Name = inventoryAttribute[1];
                _inventoryTemp.Icon = inventoryAttribute[2];
                switch (inventoryAttribute[3])
                {
                    case "Drug":
                        _inventoryTemp.InventoryType = InventoryType.Drug;
                        break;
                    case "Equip":
                        _inventoryTemp.InventoryType = InventoryType.Equip;
                        break;
                    case "Box":
                        _inventoryTemp.InventoryType = InventoryType.Box;
                        break;

                }

                if (_inventoryTemp.InventoryType == InventoryType.Equip)
                {
                    switch (inventoryAttribute[4])
                    {
                        case "Helm":
                            _inventoryTemp.EquipType = EquipType.Helm;
                            break;
                        case "Cloth":
                            _inventoryTemp.EquipType = EquipType.Cloth;
                            break;
                        case "Weapon":
                            _inventoryTemp.EquipType = EquipType.Weapon;
                            break;
                        case "Shoes":
                            _inventoryTemp.EquipType = EquipType.Shoes;
                            break;
                        case "Necklace":
                            _inventoryTemp.EquipType = EquipType.Necklace;
                            break;
                        case "Bracelet":
                            _inventoryTemp.EquipType = EquipType.Bracelet;
                            break;
                        case "Ring":
                            _inventoryTemp.EquipType = EquipType.Ring;
                            break;
                        case "Wing":
                            _inventoryTemp.EquipType = EquipType.Wing;
                            break;

                    }

                    _inventoryTemp.Price = Int32.Parse(inventoryAttribute[5]);
                    _inventoryTemp.StartLevel = Int32.Parse(inventoryAttribute[6]);
                    _inventoryTemp.Quality = Int32.Parse(inventoryAttribute[7]);
                    _inventoryTemp.Damage = Int32.Parse(inventoryAttribute[8]);
                    _inventoryTemp.Hp = Int32.Parse(inventoryAttribute[9]);
                    _inventoryTemp.Power = Int32.Parse(inventoryAttribute[10]);
                    _inventoryTemp.Describe = inventoryAttribute[13];
                    inventoryDic.Add(_inventoryTemp.Id, _inventoryTemp);
                    continue;

                }
                else if (_inventoryTemp.InventoryType == InventoryType.Drug)
                {
                    _inventoryTemp.Price = Int32.Parse(inventoryAttribute[4]);
                    switch (inventoryAttribute[11])
                    {
                        case "Energy":
                            _inventoryTemp.InfoType = InfoType.Energy;
                            break;

                    }

                    _inventoryTemp.AppleValue = Int32.Parse(inventoryAttribute[12]);
                    _inventoryTemp.Describe = inventoryAttribute[13];
                    inventoryDic.Add(_inventoryTemp.Id, _inventoryTemp);
                    continue;

                }
                else if (_inventoryTemp.InventoryType == InventoryType.Box)
                {
                    _inventoryTemp.Price = Int32.Parse(inventoryAttribute[4]);
                    _inventoryTemp.Describe = inventoryAttribute[13];
                    inventoryDic.Add(_inventoryTemp.Id, _inventoryTemp);
                     continue;
                  
                }

            }
        }
    } 

    void ReadInventoryItemInfo()//初始化角色拥有的物品数量
    {
        //需要连接服务器，或者角色拥有的物品数量TODO
        //下面随机生成物品测试一下背包
        for (int i = 0; i < 20; i++)
        {
            int id = Random.Range(1001, 1020);
            Inventory temp = null;
            inventoryDic.TryGetValue(id, out temp);
            if (temp.InventoryType==InventoryType.Equip)
            {
                InventoryItem it=new InventoryItem();
                it.Inventory = temp;
                it.Count = 1;
                it.Level = Random.Range(0, 10);
                inventoryItemList.Add(it);
            }
            else
            {
                bool isExit = false;
                foreach (InventoryItem inventoryItem in inventoryItemList)
                {
                    if (inventoryItem.Inventory.Id == id)
                    {
                        isExit = true;
                        inventoryItem.Count++;
                        break;
                    }
                }
                if (!isExit)
                {
                    InventoryItem it = new InventoryItem();
                    it.Inventory = temp;
                    it.Count = 1;
                    inventoryItemList.Add(it);
                }
            }
        }
        StartCoroutine(OnInventoryItemChange());
    }

    IEnumerator OnInventoryItemChange() //防止调用时事件未被注册上
    {
        if (OnInventoryItemChangeEvent==null)
        {
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(OnInventoryItemChange());
        }
        else
        {
            OnInventoryItemChangeEvent();
        }
    }
}
