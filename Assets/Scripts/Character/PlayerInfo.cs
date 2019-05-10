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
    Exp
}

public enum DotweenDir
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
    private int _helmID=0;//头盔
    private int _clothID=0;//衣服
    private int _weaponID=0;//武器
    private int _shoesID=0;//鞋子
    private int _necklaceID=0;//项链
    private int _braceletID=0;//手镯
    private int _ringID=0;//戒指
    private int _wingID=0;//翅膀
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

    public int HelmID
    {
        get
        {
            return _helmID;
        }

        set
        {
            _helmID = value;
        }
    }

    public int ClothID
    {
        get
        {
            return _clothID;
        }

        set
        {
            _clothID = value;
        }
    }

    public int WeaponID
    {
        get
        {
            return _weaponID;
        }

        set
        {
            _weaponID = value;
        }
    }

    public int ShoesID
    {
        get
        {
            return _shoesID;
        }

        set
        {
            _shoesID = value;
        }
    }

    public int NecklaceID
    {
        get
        {
            return _necklaceID;
        }

        set
        {
            _necklaceID = value;
        }
    }

    public int BraceletID
    {
        get
        {
            return _braceletID;
        }

        set
        {
            _braceletID = value;
        }
    }

    public int RingID
    {
        get
        {
            return _ringID;
        }

        set
        {
            _ringID = value;
        }
    }

    public int WingID
    {
        get
        {
            return _wingID;
        }

        set
        {
            _wingID = value;
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

    void Awake()
    {
        _instance = this;
      
    }
    
    void Start ()
    {
        Init();
    }
    
    void Init()
    {
        _name = "Kylen233";
        _headPortrait = "头像底板女性";
        _level = 10;
        _power = 4396;
        _exp = 200;
        _diamond = 231;
        _coin = 54;
        _energy = 37;
        _toughen = 14;
        _spar = 1;
        _siderite = 0;
        //穿上几件装备测试
        this.BraceletID = 1001;
        this.WingID = 1002;
        this.RingID = 1003;
        this.ClothID = 1004;
        this.HelmID = 1005;
        this.WeaponID = 1006;
        this.NecklaceID = 1007;
        this.ShoesID = 1008;
        InitHpDamagePower();
        PlayerInfoChangeEvent(InfoType.All);
       
    }

    void InitHpDamagePower()
    {
        this.Hp = Level * 100;
        this.Damage = Level * 50;
        this.Power = this.Hp + this.Damage;
        PutOnEquip(BraceletID);
        PutOnEquip(WingID);
        PutOnEquip(RingID);
        PutOnEquip(ClothID);
        PutOnEquip(HelmID);
        PutOnEquip(WeaponID);
        PutOnEquip(NecklaceID);
        PutOnEquip(ShoesID);
    }
    private void PutOnEquip(int id)
    {
        Inventory _inventory = null;
        if (id==0)return;
        InventoryManager._instance.inventoryDic.TryGetValue(id, out _inventory);
        this.Hp += _inventory.Hp;
        this.Damage += _inventory.Damage;
        this.Power += _inventory.Power;


    }

    private void PutOffEquip(int id)
    {
        Inventory _inventory = null;
        if (id == 0) return;
        InventoryManager._instance.inventoryDic.TryGetValue(id, out _inventory);
        this.Hp -= _inventory.Hp;
        this.Damage -= _inventory.Damage;
        this.Power -= _inventory.Power;
    }
    public void ChangeName(string newName)
    {
        this.Name= newName;
        PlayerInfoChangeEvent(InfoType.Name);
    }
	void Update () {
    //    Debug.Log("体力时间"+energyTimer);
    //    Debug.Log("历练时间"+toughenTimer);
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
