using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    private Vector3 _vec3TargetScreenSpace;
    private Vector3 _vec3MouseTargetScreenSpace;
    private Vector3 _vector3TargetWorldSpace;
    private Vector3 offset;
     private Transform _tr;

    private void Awake()
    {
        _tr = this.transform;
        StartCoroutine(OnMouseDown());
    }
    
    IEnumerator OnMouseDown()
    {
        //先把要拖拽的目标从世界坐标转换成屏幕坐标
        //鼠标的坐标z轴为拖拽目标的屏幕坐标
        
        _vec3TargetScreenSpace = Camera.main.WorldToScreenPoint(this.transform.position);  
        _vec3MouseTargetScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);
        offset = this.transform.position - Camera.main.ScreenToWorldPoint(_vec3MouseTargetScreenSpace); //偏移量
        Debug.Log("test");
        while (Input.GetMouseButton(0))
        {
            _vec3MouseTargetScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);//按下的时候不停的刷新鼠标位置
            _vector3TargetWorldSpace = Camera.main.ScreenToWorldPoint(_vec3MouseTargetScreenSpace) + offset;//加上偏移量
            this.transform.position = _vector3TargetWorldSpace;
            yield return new WaitForFixedUpdate();//避免卡死
        }
    
        
    }
}
