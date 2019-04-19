using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class StartMenuController : MonoBehaviour
{
    public static StartMenuController _instance;
    public GameObject startPanel; 
    public GameObject loginPanle; 
    public GameObject registerPanel;
    public GameObject serverPanel;
    public GameObject characterPanle;
    public GameObject characterShowPanel;
    public InputField userNameLoginPanelInputField;
    public InputField passwordLoginPanelInputField;
    public InputField userNameRegisterPanelInputField;
    public InputField passwordRegisterPanelInputField;
    public InputField repasswordRegisterPanelInputField;
    public Text startUserNameText;
    public Transform transform_serverList;
    private bool isInitServer;
    public GameObject serverButtonRed;
    public GameObject serverButtonGreen;
    public int serverCount;
    private string username;
    private string password;
    public GameObject[] characterArray;
    public GameObject[] characterInstanceArray;
    public Transform characterParent;
    public InputField CreatCharacterInputField;
    public Text characterName;
    public Text characterLv;
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {

        InitServer();
    }
    /// <summary>
    /// 开始面板的用户名
    /// </summary>
  public void OnUserNameClick()
    {
        //输入账号进行登录
        HidePanel(startPanel);
        ShowPanle(loginPanle);
        userNameLoginPanelInputField.text = username;
        
    }
    /// <summary>
    /// 选择服务器
    /// </summary>
  public void OnServerClick()
    {
       startPanel.SetActive(false);
        serverPanel.SetActive(true);
    }

    public void OnServerClose()
    {
        startPanel.SetActive(true);
        serverPanel.SetActive(false);
    }
    /// <summary>
    /// 进入游戏
    /// </summary>
    public void OnEnterGameClick()
    {
       //连接服务器
       //验证账号密码
        startPanel.SetActive(false);
        characterPanle.SetActive(true);
        characterPanle.transform.DOLocalMoveX(0, 0.5f, false);
    }
    /// <summary>
    /// 登录账号
    /// </summary>
  public void OnLoginClick()
    {
       //现在可以输入中文密码,以后用正则表达修正
        if (userNameLoginPanelInputField.text!="") 
        {
            username = userNameLoginPanelInputField.text;
            password = passwordLoginPanelInputField.text;
            startUserNameText.text = username;
        }
        HidePanel(loginPanle);
        ShowPanle(startPanel);
    }
    /// <summary>
    /// 登录面板关闭
    /// </summary>
    /// <param name="newPanel"></param>
  public void OnLoginCloseClick()
    {
        loginPanle.SetActive(false);
        startPanel.SetActive(true);
    }
    /// <summary>
    /// 弹出注册面板
    /// </summary>
  public void OnRegisterShowClick()
    {
        HidePanel(loginPanle);
        ShowPanle(registerPanel);

    }
    /// <summary>
    /// 注册界面的取消按钮
    /// </summary>
    public void OnCancelClick()
    {
        HidePanel(registerPanel);
        ShowPanle(loginPanle);
    }
   /// <summary>
   /// 更换角色按钮
   /// </summary>
    public void OnChangeCharacterClick()
    {
        HidePanel(characterPanle);
        ShowPanle(characterShowPanel);
        characterShowPanel.transform.DOLocalMoveX(0, 0.5f, false); ;
        characterPanle.transform.DOLocalMoveX(-1334, 0.5f, false);
    }
    /// <summary>
    /// 更换角色面板返回按钮
    /// </summary>
    public void OnCharacterShowBackClick()
    {
        HidePanel(characterShowPanel);
        ShowPanle(characterPanle);
        characterShowPanel.transform.DOLocalMoveX(-1334, 0.5f, false);
        //还原选中的角色
        if (currentCharacter!=null)
        {
            currentCharacter.localScale = initialScale;
            currentCharacter = null;
        }
    }

    public void OnCharacterShowButtonSureClick()
    {
        //1判断名字是否正确
        //2判断是否选择角色
        //if (currentCharacter==null)
        //{
        //    return;
        //}
        for (int i = 0; i <characterInstanceArray.Length; i++)
        {
            if (currentCharacter.GetChild(0).gameObject.name==characterInstanceArray[i].name)
            {
                Destroy(characterParent.GetChild(0).gameObject);
                GameObject.Instantiate(characterInstanceArray[i], characterParent, false);
                characterName.text = CreatCharacterInputField.text;
                characterLv.text = "Lv1";
                CreatCharacterInputField.text = "";
            }
        }
        HidePanel(characterShowPanel);
        characterShowPanel.transform.DOLocalMoveX(-1334, 0.5f, false);
        ShowPanle(characterPanle);
        characterPanle.transform.DOLocalMoveX(0, 0.5f, false);
    }
    /// <summary>
    /// 注册并登录
    /// </summary>
    public void OnRegisterAndLoginClick()
    {
        //1本地校验，连接服务器进行验证
        //TODO
        //2连接失败
        //TODO
        //3连接成功
        //保存用户名和密码 返回开始界面
        if (passwordRegisterPanelInputField.text == repasswordRegisterPanelInputField.text &&
            userNameRegisterPanelInputField.text != "")    
        {
            username = userNameRegisterPanelInputField.text;
            password = passwordRegisterPanelInputField.text;
            HidePanel(registerPanel);
            ShowPanle(startPanel);
            startUserNameText.text = username;
            userNameRegisterPanelInputField.text="";
            passwordRegisterPanelInputField.text = "";
            repasswordRegisterPanelInputField.text = "";

        }
        else
        {
            Debug.Log("密码或用户名不正确");
        }
    }
    /// <summary>
    /// 关闭注册面板
    /// </summary>
    public void OnRegisterCloseClick()
    {
       OnCancelClick();
    }

    private Vector3 initialScale;  //初始大小
    private Transform currentCharacter; //当前选中的角色
    
    /// <summary>
    /// 角色被点击
    /// </summary>
    /// <param name="go"></param>
    public void OnCharacterClick(Transform go)
    {
        
        if (currentCharacter == null)
        {
            currentCharacter = go;
            initialScale = go.localScale;
            go.transform.localScale=new Vector3(1.5f,1.5f,1.5f);
        }
        else
        {
            currentCharacter.localScale = initialScale;
            currentCharacter = go;
            initialScale = go.localScale;
            go.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            
        }
           
    }
    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <param name="Panel"></param>
  void  HidePanel(GameObject Panel)
    {
        Panel.SetActive(false);
    }
  /// <summary>
  /// 显示面板
  /// </summary>
  /// <param name="Panel"></param>
  void ShowPanle(GameObject Panel)
    {
        Panel.SetActive(true);
    }
    /// <summary>
    /// 初始化服务器
    /// </summary>
    void InitServer()
    {
        if (isInitServer) return;
        for (int i = 0; i <serverCount ; i++)
        {
            string serverName = i + 1 + "区" + "  " + "浙江";
            string ip = "127.0.0.1";
            int count = Random.Range(0, 100);
            if (count>50)
            {
                GameObject go=Instantiate(serverButtonRed, transform_serverList);
                ServerProperty _property = go.GetComponent<ServerProperty>();
                _property.serverName = serverName;
                _property.ipaddress = ip;
                _property.count = count;

            }
            else
            {
                GameObject go = Instantiate(serverButtonGreen, transform_serverList);
                ServerProperty _property = go.GetComponent<ServerProperty>();
                _property.serverName = serverName;
                _property.ipaddress = ip;
                _property.count = count;
            }
        }

        isInitServer = true;
    }
}
