using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{

    private Inventory inventory;//物品基本属性类
    private int count;//物品数量
    private int level;//物品等级



    #region getSet方法

    public Inventory Inventory
    {
        get
        {
            return inventory;
        }

        set
        {
            inventory = value;
        }
    }

    public int Count
    {
        get
        {
            return count;
        }

        set
        {
            count = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    #endregion

}
