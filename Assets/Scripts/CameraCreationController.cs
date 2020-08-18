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
    public const float minimum2DPosition = -14;
    public const float maximum2DPosition = 14;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SaveCamera()
    {
        cameraHandler.SaveCamera(currentCamera.transform.position, currentCamera.transform.localEulerAngles, currentCamera.fieldOfView);

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
