using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{

    public float rotateSpeed;
  
	void Update () {
       
	}

    IEnumerator OnMouseDown()
    {
        Vector2 vector3StartMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        while (Input.GetMouseButton(0))
        {
            float offsetX = vector3StartMousePos.x - Input.mousePosition.x;
            if (offsetX > 2) //左边移动
            {
                Debug.Log("左转");
                Vector3 temp = this.transform.localEulerAngles;
                temp.y += rotateSpeed;
                this.transform.localEulerAngles = temp;

            }
            else if(offsetX <-2)
            {
                Debug.Log("右转");
                Vector3 temp = this.transform.localEulerAngles;
                temp.y -= rotateSpeed;
                this.transform.localEulerAngles = temp;
            }
            yield return new WaitForFixedUpdate();//避免卡死
        }

    }
}
