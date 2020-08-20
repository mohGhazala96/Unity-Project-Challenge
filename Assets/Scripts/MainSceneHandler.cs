using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>MainSceneHandler</c> is responsible for animating the camera in the Main Animation Scene.
///</summary>

public class MainSceneHandler : MonoBehaviour
{
    /// <summary>Instance variable <c>currentCamera</c> represents the current camera the user is animating
    /// </summary>
    GameObject currentCamera;

    /// <summary>Instance variable <c>newTransform</c> represents the current transform at which the camera will be animating relative to
    /// I.e. make the orgin to the the inital direction at which the camera is poiting at, not the the (0,0,0) origin
    /// </summary>
    Transform newTransform;

    /// <summary>Instance variable <c>movementValue</c> represents speed at which the camera will be moving at all three axis 
    /// </summary>
    const float movementValue = 2;

    /// <summary>Instance variable <c>zoomValue</c> represents speed at which the camera will be zomming in or out at
    /// </summary>
    const float zoomValue = 20;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    /// <summary>
    /// loads the current camera and creates a new transform
    /// </summary>
    void Init()
    {
        // loads the camera (either saved or just created)
        currentCamera = Instantiate(CameraController.Instance.LoadSavedCamera());

        // Assigns the current camera variable to CameraController such that the user can save a screenshot or override the current camera parameters
        CameraController.Instance.currentCamera = currentCamera.GetComponent<Camera>();

        // creates an new transform object that will hold the transform that the camera will be animating to
        GameObject tempTransformObject = new GameObject();
        newTransform = tempTransformObject.transform;
    }

    private void Update()
    {
        if (currentCamera == null)
            return;

        newTransform.transform.position = currentCamera.transform.position;

        // adjust the transform's angles such that the camera move horizontally relative to the current view
        newTransform.transform.localEulerAngles = new Vector3(currentCamera.transform.localEulerAngles.x, currentCamera.transform.localEulerAngles.y, 0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //move to the right
            currentCamera.transform.position += newTransform.transform.right * Time.deltaTime * movementValue;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //move to the left
            currentCamera.transform.position -= newTransform.transform.right * Time.deltaTime * movementValue;

        }

        // adjust the transform's angles such that the camera move forward relative to the current view
        newTransform.transform.localEulerAngles = new Vector3(0, currentCamera.transform.localEulerAngles.y, 0);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            // dolly in
            currentCamera.transform.position += newTransform.transform.forward * Time.deltaTime * movementValue;

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // dolly out
            currentCamera.transform.position -= newTransform.transform.forward * Time.deltaTime * movementValue;
        }

        // adjust the transform's angles such that the camera move vertically relative to the current view
        newTransform.transform.localEulerAngles = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            // move down
            currentCamera.transform.position -= newTransform.transform.up * Time.deltaTime * movementValue;

        }
        else if (Input.GetKey(KeyCode.U))
        {
            // move up
            currentCamera.transform.position += newTransform.transform.up * Time.deltaTime * movementValue;

        }

        if (Input.GetKey(KeyCode.I))
        {
            // zoom in
            currentCamera.GetComponent<Camera>().fieldOfView -= Time.deltaTime * zoomValue;
        }
        else if (Input.GetKey(KeyCode.O))
        {
            // zoom out
            currentCamera.GetComponent<Camera>().fieldOfView += Time.deltaTime * zoomValue;

        }
    }
}
