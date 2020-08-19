using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneHandler : MonoBehaviour
{
    public GameObject newCamera;
    GameObject currentCamera;
    GameObject tempTransformObject;
    Transform newTransform;

    // Start is called before the first frame update
    void Start()
    {
        currentCamera = Instantiate(newCamera);
        currentCamera.GetComponent<CameraHandler>().LoadSavedCamera();
        GetComponent<CameraCreationController>().cameraHandler = currentCamera.GetComponent<CameraHandler>();
        GetComponent<CameraCreationController>().currentCamera = currentCamera.GetComponent<Camera>();
        tempTransformObject = new GameObject();
        newTransform = tempTransformObject.transform;

    }

    private void Update()
    {
        if (currentCamera == null)
            return;
        float movementValue = 2;
        float zoomValue = 20;


        newTransform.transform.position = currentCamera.transform.position;
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
