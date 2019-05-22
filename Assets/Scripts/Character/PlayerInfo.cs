using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia.SharpZipLib.Core;

public  enum InfoType  //角色信息更新枚举
{
    HeadSprite,
    Name,
    Level,
    Toughen,
    Energy,
    All,
    Diamond,
    Coin,
    Hp,
    Damage,
    Exp,
    Equip
}

public enum DotweenDir//动画播放方向
{
    forward,
    back
}

public class PlayerInfo : MonoBehaviour {

    #region   人物属性
    private string _name;//玩家姓名
    private string _headPortrait;//头像
    private int _level = 1;//等级
    private int _power = 1;//战斗
    private int _exp = 0;//经验
    private int _diamond;//钻石
    private int _coin;//金币
    private int _energy;//体力
    private int _toughen;//历练
    private int _spar;//晶石
    private int _siderite;//y陨铁
    private int _damage;//伤害
    private int _hp;//血量
    private InventoryItem helmInventoryItem;
    private InventoryItem clothInventoryItem;
    private InventoryItem weaponInventoryItem;
    private InventoryItem shoesInventoryItem;
    private InventoryItem necklaceInventoryItem;
    private InventoryItem braceletInventoryItem;
    private InventoryItem ringInventoryItem;
    private InventoryItem wingInventoryItem;
    #endregion
    #region   //属性方法
    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public string HeadPortrait
    {
        get
        {
            return _headPortrait;
        }

        set
        {
            _headPortrait = value;
        }
    }

    public int Level
    {
        get
        {
            return _level;
        }

        set
        {
            _level = value;
        }
    }

    public int Power
    {
        get
        {
            return _power;
        }

        set
        {
            _power = value;
        }
    }

    public int Exp
    {
        get
        {
            return _exp;
        }

        set
        {
            _exp = value;
        }
    }

    public int Diamond
    {
        get
        {
            return _diamond;
        }

        set
        {
            _diamond = value;
        }
    }

    public int Coin
    {
        get
        {
            return _coin;
        }

        set
        {
            _coin = value;
        }
    }

    public int Energy
    {
        get
        {
            return _energy;
        }

        set
        {
            _energy = value;
        }
    }

    public int Toughen
    {
        get
        {
            return _toughen;
        }

        set
        {
            _toughen = value;
        }
    }

    public int Spar
    {
        get
        {
            return _spar;
        }

        set
        {
            _spar = value;
        }
    }

    public int Siderite
    {
        get
        {
            return _siderite;
        }

        set
        {
            _siderite = value;
        }
    }

    public int Damage
    {
        get
        {
            return _damage;
        }

        set
        {
            _damage = value;
        }
    }

    public int Hp
    {
        get
        {
            return _hp;
        }

        set
        {
            _hp = value;
        }
    }

    public InventoryItem HelmInventoryItem
    {
        get
        {
            return helmInventoryItem;
        }

        set
        {
            helmInventoryItem = value;
        }
    }

    public InventoryItem ClothInventoryItem
    {
        get
        {
            return clothInventoryItem;
        }

        set
        {
            clothInventoryItem = value;
        }
    }

    public InventoryItem WeaponInventoryItem
    {
        get
        {
            return weaponInventoryItem;
        }

        set
        {
            weaponInventoryItem = value;
        }
    }

    public InventoryItem ShoesInventoryItem
    {
        get
        {
            return shoesInventoryItem;
        }

        set
        {
            shoesInventoryItem = value;
        }
    }

    public InventoryItem NecklaceInventoryItem
    {
        get
        {
            return necklaceInventoryItem;
        }

        set
        {
            necklaceInventoryItem = value;
        }
    }

    public InventoryItem BraceletInventoryItem
    {
        get
        {
            return braceletInventoryItem;
        }

        set
        {
            braceletInventoryItem = value;
        }
    }

    public InventoryItem RingInventoryItem
    {
        get
        {
            return ringInventoryItem;
        }

        set
        {
            ringInventoryItem = value;
        }
    }

    public InventoryItem WingInventoryItem
    {
        get
        {
            return wingInventoryItem;
        }

        set
        {
            wingInventoryItem = value;
        }
    }


    #endregion
    public static PlayerInfo _instance;
    [HideInInspector]
    public float energyTimer=0;
    [HideInInspector]
    public float toughenTimer = 0;
    public delegate void PlayerInfoChangeDelegate(InfoType infoType);
    public event PlayerInfoChangeDelegate PlayerInfoChangeEvent;

    void Awake()//初始化单例
    {
        _instance = this;
      
    }
    
    void Start ()
    {
        Init();
    }
    
    void Init() //初始化人物信息
    {
        _name = "Kylen233";
        _headPortrait = "头像底板女性";
        _level = 10;
        _power = 4396;
        _exp = 200;
        _diamond = 231;
        _coin = 54000;
        _energy = 37;
        _toughen = 14;
        _spar = 1;
        _siderite = 0;
        //穿上几件装备测试
        //this.BraceletID = 1001;
        //this.WingID = 1002;
        //this.RingID = 1003;
        //this.ClothID = 1004;
        //this.HelmID = 1005;
        //this.WeaponID = 1006;
        //this.NecklaceID = 1007;
        //this.ShoesID = 1008;
        InitHpDamagePower();
        PlayerInfoChangeEvent(InfoType.All);
       
    }

    void InitHpDamagePower()//初始化人物血量伤害战斗力
    {
        this.Hp = Level * 100;
        this.Damage = Damage * 50;
        this.Power = this.Hp + this.Damage;
    }
    public void UseInventory(InventoryItem it)
    {
        if (it.Count<=0)
        {
            InventoryManager._instance.inventoryItemList.Remove(it);
            Debug.Log("物品已经移除");
        }
    }
   public bool GetCoin(int needCoin)
    {
        if (this.Coin-needCoin>0)
        {
            this.Coin -= needCoin;
            Debug.Log("消耗了"+needCoin+"个金币");
            PlayerInfoChangeEvent(InfoType.Coin);
            MessageManager._instance.ShowMessage("升级成功", 0.2f);
            return true;
        }
        MessageManager._instance.ShowMessage("金币不足",0.2f);
        Debug.Log("金币不足");
        return false;
    }

   public void DressEquip(InventoryItem it)//穿上装备
    { 
        //是直接穿上，否卸下当前装备穿上新装备
     
        it.isDress = true;
        //当前是否已经穿了装备
        bool isDress = false;
        InventoryItem currentInventoryItem = null;
        switch (it.Inventory.EquipType)
        {
            case EquipType.Bracelet:
                if (BraceletInventoryItem!=null)
                {
                    currentInventoryItem = BraceletInventoryItem;

                    isDress = true;
                }

                BraceletInventoryItem = it;
                break;
            case EquipType.Cloth:
                if (ClothInventoryItem != null)
                {
                    currentInventoryItem = ClothInventoryItem;
                    isDress = true;
                }
                ClothInventoryItem = it;
                break;
            case EquipType.Helm:
                if (HelmInventoryItem != null)
                {
                    currentInventoryItem = HelmInventoryItem;
                    isDress = true;
                    
                }
                HelmInventoryItem = it;
                break;
            case EquipType.Necklace:
                if (NecklaceInventoryItem != null)
                {
                    currentInventoryItem = NecklaceInventoryItem;
                    isDress = true;
                }
                NecklaceInventoryItem = it;
                break;
            case EquipType.Ring:
                if (RingInventoryItem != null)
                {
                    currentInventoryItem = RingInventoryItem;
                  
                    isDress = true;
                }
                RingInventoryItem = it;
                break;
            case EquipType.Shoes:
                if (ShoesInventoryItem != null)
                {
                    currentInventoryItem = ShoesInventoryItem;
                   
                    isDress = true;
                }
                ShoesInventoryItem = it;
                break;
            case EquipType.Weapon:
                if (WeaponInventoryItem != null)
                {
                    currentInventoryItem = WeaponInventoryItem;
                  
                    isDress = true;
                }
                WeaponInventoryItem = it;
                break;
            case EquipType.Wing:
                if (WingInventoryItem != null)
                {
                    currentInventoryItem = WingInventoryItem; 
                    isDress = true;
                }
                WingInventoryItem = it;
                break;

        }

        if (isDress)
        {
            InventoryUI._instance.AddInventoryItem(currentInventoryItem);
            currentInventoryItem.isDress = false;
            PlayerInfoChangeEvent(InfoType.Equip);
            
        }
      
        this.Hp += it.Inventory.Hp;
        this.Damage += it.Inventory.Damage;
        this.Power += it.Inventory.Power;
        PlayerInfoChangeEvent(InfoType.Equip);
        Debug.Log("加状态");
        Debug.Log("当前状态" + this.Hp + " " + this.Damage + "" + this.Power);
    }

    public void PutoffEquip(InventoryItem it)//脱下装备
    {
        //是直接穿上，否卸下当前装备穿上新装备

        it.isDress = false;
        //当前是否已经穿了装备
     
        InventoryItem currentInventoryItem = null;
        switch (it.Inventory.EquipType)
        {
            case EquipType.Bracelet:     
                currentInventoryItem = BraceletInventoryItem;
                BraceletInventoryItem = null;
                break;
            case EquipType.Cloth:
                currentInventoryItem = ClothInventoryItem;
                ClothInventoryItem = null; 
                break;
            case EquipType.Helm:
                if (HelmInventoryItem!=null)
                {
                    currentInventoryItem = HelmInventoryItem;
                    HelmInventoryItem = null;
                }
               
                break;
            case EquipType.Necklace:
                currentInventoryItem = NecklaceInventoryItem;
                NecklaceInventoryItem = null;
                break;
            case EquipType.Ring:
                currentInventoryItem = RingInventoryItem;
                RingInventoryItem = null;
                break;
            case EquipType.Shoes:
                currentInventoryItem = ShoesInventoryItem;
                ShoesInventoryItem = null;
                break;
            case EquipType.Weapon:
                currentInventoryItem = WeaponInventoryItem;
                WeaponInventoryItem = null;
                break;
            case EquipType.Wing:
                currentInventoryItem = WingInventoryItem;
                WingInventoryItem = null;
                break;
        }
        InventoryUI._instance.AddInventoryItem(currentInventoryItem);
       
        this.Hp -= it.Inventory.Hp;
        this.Damage -= it.Inventory.Damage;
        this.Power -= it.Inventory.Power;
        PlayerInfoChangeEvent(InfoType.Equip);
    }

    public void ChangeName(string newName)//角色改名
    {
        this.Name= newName;
        PlayerInfoChangeEvent(InfoType.Name);
    }
	void Update () //更新体力历练自动增长
    {
  
	    if (_energy<100)  
	    {
	        energyTimer += Time.deltaTime;
	        PlayerInfoChangeEvent(InfoType.Energy);
	        if (energyTimer>60)
	        {
	            _energy++;
	            energyTimer = 0;

	        }
	    }    //体力自动增长
	    else
	    {
	        energyTimer = 0;

	    }
	    if (_toughen < 50)    
	    {
	        toughenTimer += Time.deltaTime;
	        if (toughenTimer > 60)
	        {
                _toughen++;
	            toughenTimer = 0;
	        }
	    }   //历练自动增长
        else
	    {
	        toughenTimer = 0;

	    }

    }
}
