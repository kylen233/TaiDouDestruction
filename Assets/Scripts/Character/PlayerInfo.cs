using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public  enum InfoType  //角色信息更新枚举
{
    HeadSprite,
    Name,
    Level,
    Toughen,
    Energy,
    All
}

public class PlayerInfo : MonoBehaviour {

    #region   PlayProperty //人物属性

    private string _name;
    private string _headPortrait;
    private int _level = 1;
    private int _power = 1;
    private int _exp = 0;
    private int _diamond;
    private int _coin;
    private int _energy;
    private int _toughen;
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
    #endregion
  
    public static PlayerInfo _instance;
    private float energyTimer=0;
    private float toughenTimer = 0;
    public delegate void PlayerInfoChangeDelegate(int nub);
    public event PlayerInfoChangeDelegate PlayerInfoChangeEvent;

    void Awake()
    {
        _instance = this;
        
    }
    void Start ()
    {
        Init();
    }

    void OnEnable()
    {
       
    }
    void Init()
    {
        _name = "Kylen233";
        _headPortrait = "头像底板女性";
        _level = 10;
        _power = 200;
        _exp = 200;
        _diamond = 500;
        _coin = 200;
        _energy = 37;
        _toughen = 14;
        PlayerInfoChangeEvent += i => Debug.Log(i + 1);
        PlayerInfoChangeEvent(1);
       
    }
	// Update is called once per frame
	void Update () {
    //    Debug.Log("体力时间"+energyTimer);
    //    Debug.Log("历练时间"+toughenTimer);
	    if (_energy<100)  
	    {
	        energyTimer += Time.deltaTime;
	        if (energyTimer>3)
	        {
	            _energy++;
	            energyTimer = 60;
	        }
	    }    //体力自动增长
	    else
	    {
	        energyTimer = 0;

	    }
	    if (_toughen < 100)    
	    {
	        toughenTimer += Time.deltaTime;
	        if (toughenTimer > 3)
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
