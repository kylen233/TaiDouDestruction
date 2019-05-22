using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{

    public GameObject bg;
    public DOTweenVisualManager ManagerBg;
    public DOTweenAnimation ManagerText;
    public static MessageManager _instance;
    public Text messageText;
    void Awake()
    {
        _instance = this;
    }
	
	void Update () {
		
	}

    public void ShowMessage(string message,float waitTime)
    {
        StartCoroutine(Show(message, waitTime));
    }
    IEnumerator Show(string message,float waitTime)
    {
        messageText.text = message;
        bg.SetActive(true);
        yield return  new WaitForSeconds(waitTime);
        ManagerBg.enabled=true;
        ManagerText.enabled = true;
        yield return new WaitForSeconds(1);
        ManagerBg.enabled = false;
        ManagerText.enabled = false;
        bg.SetActive(false);


    }
}
