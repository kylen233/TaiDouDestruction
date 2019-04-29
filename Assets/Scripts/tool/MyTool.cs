using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTool : MonoBehaviour {

    public static int GetExpValue(int level)
    {
        //等差数列
        return (int)((level-1)*(100f+(100f+10f*(level-2f)))/2);
    }
}
