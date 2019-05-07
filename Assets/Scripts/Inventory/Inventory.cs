using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryType //物品类型
{
    Equip,
    Drug,
    Box
}

public enum EquipType   //装备类型
{
    Helm,  
    Cloth,
    Weapon,
    Shoes,
    Necklace,
    Bracelet,
    Ring,
    Wing

}
public class Inventory
{

    private int id;//id
    private string name;//名称
    private string icon;//在图集中的名称
    private InventoryType inventoryType;//物品类型
    private EquipType equipType;//装备类型
    private int price = 0;//物品价格
    private int startLevel = 1;//星级
    private int quality = 1;//品质
    private int damage = 0;//伤害
    private int hp = 0;//生命
    private int defense = 0;//防御
    private int power = 0;//战斗力
    private InfoType infoType;//作用类型，表示作用在哪个属性之上
    private int appleValue;//作用值
    private string describe;//描述
    #region 属性getSet方法
    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    public InventoryType InventoryType
    {
        get
        {
            return inventoryType;
        }

        set
        {
            inventoryType = value;
        }
    }

    public EquipType EquipType
    {
        get
        {
            return equipType;
        }

        set
        {
            equipType = value;
        }
    }

   
  

    public int Price
    {
        get
        {
            return price;
        }

        set
        {
            price = value;
        }
    }

    public int StartLevel
    {
        get
        {
            return startLevel;
        }

        set
        {
            startLevel = value;
        }
    }

    public int Quality
    {
        get
        {
            return quality;
        }

        set
        {
            quality = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    public int Defense
    {
        get
        {
            return defense;
        }

        set
        {
            defense = value;
        }
    }

    public int Power
    {
        get
        {
            return power;
        }

        set
        {
            power = value;
        }
    }

    public InfoType InfoType
    {
        get
        {
            return infoType;
        }

        set
        {
            infoType = value;
        }
    }

    public int AppleValue
    {
        get
        {
            return appleValue;
        }

        set
        {
            appleValue = value;
        }
    }

    public string Describe
    {
        get
        {
            return describe;
        }

        set
        {
            describe = value;
        }
    }
    #endregion

    public override string ToString()
    {
        return string.Format("Id: {0}, Name: {1}, Icon: {2}, InventoryType: {3}, EquipType: {4}, Price: {5}, StartLevel: {6}, Quality: {7}, Damage: {8}, Hp: {9}, Defense: {10}, Power: {11}, InfoType: {12}, AppleValue: {13}, Describe: {14}", id, name, icon, inventoryType, equipType, price, startLevel, quality, damage, hp, defense, power, infoType, appleValue, describe);
    }
}
