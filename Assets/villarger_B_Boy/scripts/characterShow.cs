using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterShow : MonoBehaviour {

	// Use this for initialization
    void OnMouseDown()
    {
    
        Debug.Log("press"+this.transform.parent.parent.name);
        StartMenuController._instance.OnCharacterClick(this.transform.parent.parent);
    }

   
}
