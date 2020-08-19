using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCreationController : MonoBehaviour
{
    public CameraHandler cameraHandler;
    public Camera currentCamera;
    public Vector3 intialCameraRotation { get { return new Vector3(0, 144.86f, 0); } }
    public Vector3 initialCameraPosition { get { return new Vector3(-2.668f, 1.556f, 2.11f); } }
    public const float lensLength = 60;
    public const float minimumAngleValue = 0;
    public const float maximumAngleValue = 360;
    public const float minimumLensLength = 1;
    public const float maximumLensLegnth = 144;
    public const float minimum2DPosition = -15;
    public const float maximum2DPosition = 15;
    public const float minimumVerticalPosition = 1;
    public const float maximumVerticalPosition = 14;

    private static CameraCreationController instance;
    public static CameraCreationController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<CameraCreationController>();
            }
            return instance;
        }
    }

    public void SaveCamera()
    {
        cameraHandler.SaveCamera(true);
        cameraHandler.SaveScreenShot(false);
    }

    public void SaveAnimatedCamera()
    {
        cameraHandler.SaveCamera(false);
        cameraHandler.SaveScreenShot(false);
        Debug.Log("Current camera " + PlayerPrefs.GetInt("current camera index") + "has been overiden");

    }

    public void SaveScreenShotDuringGame()
    {
        cameraHandler.SaveScreenShot(true);
    }

    public void ChangeCameraRotation(float x, float y, float z)
    {
        currentCamera.transform.localEulerAngles = new Vector3(x, y, z);
    }

    public void ChangeCameraPosition(float x, float y, float z)
    {
        currentCamera.transform.position = new Vector3(x, y, z);

    }

    public void ChangeCameraLensLegth(float length)
    {
        currentCamera.fieldOfView = length;
    }

}
