using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Class <c>CameraController</c> is  responsible controlling the camera (postional and rotational)parameters when creating a new one.
/// Alos it's repsonsible for saving a new camera or editing a saved one, and it is takes care of taking screenshots and previewes for the camera.
///</summary>

public class CameraController : MonoBehaviour
{
    /// <summary>Instance variable <c>currentCamera</c> represents the current camera in the scene (either when creating or animating one)
    /// </summary>
    public Camera currentCamera;

    /// <summary>Instance variable <c>intialCameraRotation</c> represents the default rotation for the camera
    /// </summary>
    public static Vector3 intialCameraRotation { get { return new Vector3(0, 144.86f, 0); } }

    /// <summary>Instance variable <c>initialCameraPosition</c> represents the default position for the camera
    /// </summary>
    public Vector3 initialCameraPosition { get { return new Vector3(-2.668f, 1.556f, 2.11f); } }

    /// <summary>Instance variable <c>lensLength</c> represents the default lens length
    /// </summary>
    public const float lensLength = 60;

    /// <summary>Instance variable <c>minimumAngleValue</c> represents the minmum value the camera will be rotating at, in all three axis
    /// </summary>
    public const float minimumAngleValue = 0;

    /// <summary>Instance variable <c>maximumAngleValue</c> represents the maximum value the camera will be rotating at, in all three axis
    /// </summary>
    public const float maximumAngleValue = 360;

    /// <summary>Instance variable <c>minimumLensLength</c> represents the minimum lens length
    /// </summary>
    public const float minimumLensLength = 1;

    /// <summary>Instance variable <c>maximumLensLegnth</c> represents the maximum lens length
    /// </summary>
    public const float maximumLensLegnth = 144;

    /// <summary>Instance variable <c>minimum2DPosition</c> represents the minimum value the camera will be moving in the x or z axis
    /// </summary>
    public const float minimum2DPosition = -15;

    /// <summary>Instance variable <c>maximum2DPosition</c> represents the maximum value the camera will be moving in the x or z axis
    /// </summary>
    public const float maximum2DPosition = 15;

    /// <summary>Instance variable <c>minimumVerticalPosition</c> represents the minimum value the camera will be moving in the y axis
    /// </summary>
    public const float minimumVerticalPosition = 1;

    /// <summary>Instance variable <c>maximumVerticalPosition</c> represents the maximum value the camera will be moving in the y axis
    /// </summary>
    public const float maximumVerticalPosition = 14;

    /// <summary>Instance variable <c>instance</c> represents CameraController singleton variable that will be called from different classes
    /// </summary>
    private static CameraController instance;
    public static CameraController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<CameraController>();
            }
            return instance;
        }
    }

    /// <summary>
    /// Rotate the camera when creating it in all three axis using the input paramters
    /// </summary>
    /// <param name="x"> Represent the X angle at which camera will be rotating at</param>
    /// <param name="y"> Represent the Y angle at which camera will be rotating at</param>
    /// <param name="z"> Represent the Z angle at which camera will be rotating at</param>
    public void ChangeCameraRotation(float x, float y, float z)
    {
        currentCamera.transform.localEulerAngles = new Vector3(x, y, z);
    }

    /// <summary>
    /// moves the camera when creating it  in all three axis using the input paramters
    /// </summary>
    /// <param name="x"> Represent the X coordinate at which camera will be moving to</param>
    /// <param name="y"> Represent the Y coordinate at which camera will be moving to</param>
    /// <param name="z"> Represent the Z coordinate at which camera will be moving to</param>
    public void ChangeCameraPosition(float x, float y, float z)
    {
        currentCamera.transform.position = new Vector3(x, y, z);

    }


    /// <summary>
    /// changes the camera's lens length when creating it  using the input paramters
    /// </summary>
    /// <param name="length"> Represent the lens length the camera will have
    public void ChangeCameraLensLegth(float length)
    {
        currentCamera.fieldOfView = length;
    }

    /// <summary>
    /// This method is calls the main SaveCamera method to save a new camera
    /// </summary>
    public void SaveCamera()
    {
        SaveCamera(currentCamera.gameObject, true);
        SaveScreenShot(currentCamera,false);
    }

    /// <summary>
    /// This method is calls the main SaveCamera method to override a currnet saved camera
    /// </summary>
    public void SaveAnimatedCamera()
    {
        SaveCamera(currentCamera.gameObject, false);
        SaveScreenShot(currentCamera,false);
        Debug.Log("Current camera " + PlayerPrefs.GetInt("current camera index") + " has been overiden");

    }

    /// <summary>
    /// This method is called to save a screenshot when animating the camera
    /// </summary>
    public void SaveScreenShotDuringGame()
    {
        SaveScreenShot(currentCamera,true);
    }

    /// <summary>
    /// This method is called to save a screenshot when animating the camera
    /// </summary>
    /// /// <returns>
    /// The camera saved at the current camera index
    /// </returns>
    public GameObject LoadSavedCamera()
    {
        int newCameraIndex = PlayerPrefs.GetInt("current camera index");
        var newCamera = Resources.Load<GameObject>("Saved Cameras/Camera " + newCameraIndex);
        return newCamera;
    }

    /// <summary>
    /// This method is called to save a new camera or override a current one (as a prefab) using the input parameters
    /// </summary>
    /// <param name="currentCamera"> Represent current camera that will be saved as a prefab
    /// <param name="isCameraNew"> This boolean is to check if the camera is new or an already saved camera that has to be overrided 
    void SaveCamera(GameObject currentCamera, bool isCameraNew)
    {
        int newCameraIndex;
        if (isCameraNew)
        {
            // updates the current camera index and last camera added index
            newCameraIndex = PlayerPrefs.GetInt("last camera index") + 1;
            PlayerPrefs.SetInt("last camera index", newCameraIndex);
            PlayerPrefs.SetInt("current camera index", newCameraIndex);
        }
        else
        {
            // updates the current camera index
            newCameraIndex = PlayerPrefs.GetInt("current camera index");
            PlayerPrefs.SetInt("current camera index", newCameraIndex);
        }

        // resets the viewport rect properties 
        currentCamera.GetComponent<Camera>().rect = new Rect(0, 0, 1.0f, 1.0f);

        // save current camera as a prefab
        PrefabUtility.SaveAsPrefabAsset(currentCamera, "Assets/Resources/Saved Cameras/Camera " + (newCameraIndex) + ".prefab");
    }

    /// <summary>
    /// This method is to save a screenshot or a camera preview depending on the input parameters
    /// </summary>
    /// <param name="currentCamera"> Represent current camera that will do screencapture to its view 
    /// <param name="isInAnimationScene"> This boolean if true the screencapture will be saved as a screenshot, if not it will be saved as a camera preview 
    static void SaveScreenShot(Camera currentCamera, bool isInAnimationScene)
    {
        string screenShotName = UIManager.previewPath + PlayerPrefs.GetInt("current camera index") + ".jpg";

        if (isInAnimationScene)
        {
            screenShotName = UIManager.inGameScreenPath + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";
        }

        int resWidth = 3200;
        int resHeight = 1800;

        /*The following part creates a new texture
         * then assigns the camera targetTexture to the new texture
         *  then save it in the 'screenShot' variable
         *  then destory the created textutre and reset the current camera's targetTexture to null*/

        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        currentCamera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        currentCamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        currentCamera.targetTexture = null;
        RenderTexture.active = null; 
        Destroy(rt);
        ////
       
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Application.dataPath + screenShotName;

        // saves screen capture in the appropriate path depending on the value of 
        File.WriteAllBytes(filename, bytes);

        Debug.Log(string.Format("Took screenshot to: {0}", filename));
    }

}
