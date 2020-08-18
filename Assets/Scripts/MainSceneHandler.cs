using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneHandler : MonoBehaviour
{
    public GameObject newCamera;

    // Start is called before the first frame update
    void Start()
    {
        GameObject currentCamera = Instantiate(newCamera);
        currentCamera.GetComponent<CameraHandler>().LoadSavedCamera();
    }
}
