using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

    public float sensitivity = 700.0f;
    float rotationX =0.0f;
    float rotationY;

    public float viewAngleX = 0.0f;
    public float viewAngleY = 0.0f;

	void Update () {

        float mousePosX = Input.mousePosition.x;
        float mousePosY = Input.mousePosition.y;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        Debug.Log("mX:" + mousePosX + " mY:" + mousePosY);
        if ( mousePosX > screenWidth || mousePosX < 0 ||
             mousePosY > screenHeight || mousePosY < 0 )
        {
            return;
        }


        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");

        rotationY += mouseMoveValueX * sensitivity * Time.deltaTime;
        rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

        rotationX %= 360;
        rotationY %= 360;

        

        if (rotationX < -viewAngleX)
        {
            rotationX = -viewAngleX;

        }
        else if (rotationX > viewAngleX)
        {
            rotationX = viewAngleX;
        }


        if (rotationY < -viewAngleY)
        {
            rotationY = -viewAngleY;

        }
        else if (rotationY > viewAngleY)
        {
            rotationY = viewAngleY;
        }


        Debug.Log("X:" + rotationX + " Y:" + rotationY);
        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);
	}
}
