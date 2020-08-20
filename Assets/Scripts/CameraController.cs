using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera currentCamera;
    public static Vector3 intialCameraRotation { get { return new Vector3(0, 144.86f, 0); } }
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

    public void SaveCamera()
    {
        SaveCamera(currentCamera.gameObject, true);
        SaveScreenShot(currentCamera,false);
    }

    public void SaveAnimatedCamera()
    {
        SaveCamera(currentCamera.gameObject, true);
        SaveScreenShot(currentCamera,false);
        Debug.Log("Current camera " + PlayerPrefs.GetInt("current camera index") + "has been overiden");

    }

    public void SaveScreenShotDuringGame()
    {
        SaveScreenShot(currentCamera,true);
    }

    public GameObject LoadSavedCamera()
    {
        int newCameraIndex = PlayerPrefs.GetInt("current camera index");
        print(newCameraIndex);
        var newCamera = Resources.Load<GameObject>("Saved Cameras/Camera " + newCameraIndex);
        print(newCamera);
        return newCamera;

    }


    void SaveCamera(GameObject currentCamera, bool isCameraNew)
    {
        int newCameraIndex;
        if (isCameraNew)
        {
            newCameraIndex = PlayerPrefs.GetInt("last camera index", 0) + 1;
            PlayerPrefs.SetInt("last camera index", newCameraIndex);
            PlayerPrefs.SetInt("current camera index", newCameraIndex);
        }
        else
        {
            newCameraIndex = PlayerPrefs.GetInt("current camera index");
            PlayerPrefs.SetInt("current camera index", newCameraIndex);
        }

        currentCamera.GetComponent<Camera>().rect = new Rect(0, 0, 1.0f, 1.0f);

        PrefabUtility.SaveAsPrefabAsset(currentCamera, "Assets/Resources/Saved Cameras/Camera " + (newCameraIndex) + ".prefab");
    }


    static void SaveScreenShot(Camera currentCamera, bool isInGame)
    {
        string screenShotName = UIManager.previewPath + PlayerPrefs.GetInt("current camera index") + ".jpg";
        if (isInGame)
        {
            screenShotName = UIManager.inGameScreenPath + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";
        }

        int resWidth = 3200;
        int resHeight = 1800;
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        currentCamera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        currentCamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        currentCamera.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Application.dataPath + screenShotName;
        File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", filename));
    }

}
