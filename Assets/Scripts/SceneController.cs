using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public CameraHandler cameraHandler;
    public Camera currentCamera;

    private static SceneController instance;
    public static SceneController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<SceneController>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
