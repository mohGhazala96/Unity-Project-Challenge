using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public GameObject currentCamera;

    public void SaveCamera(bool isCameraNew)
    {

        Vector3 cameraPosition = currentCamera.transform.position;
        Vector3 cameraRotation = currentCamera.transform.localEulerAngles;
        float lensLength = currentCamera.GetComponent<Camera>().fieldOfView;
        string filePath = GetPath();

        //This is the writer, it writes to the filepath
        StreamWriter writer =  File.AppendText(filePath);
        int newCameraIndex = PlayerPrefs.GetInt("last camera index", -1);

        if (isCameraNew)
        {
            newCameraIndex = PlayerPrefs.GetInt("last camera index", -1) + 1;
            PlayerPrefs.SetInt("last camera index", newCameraIndex);
        }

        PlayerPrefs.SetInt("current camera index", newCameraIndex);

        writer.Write("\n"+
             newCameraIndex +
             "," + cameraPosition.x +
             "," + cameraPosition.y +
             "," + cameraPosition.z +
             "," + cameraRotation.x +
             "," + cameraRotation.y +
             "," + cameraRotation.z +
             "," + lensLength);

        writer.Flush();
        //This closes the file
        writer.Close();
    }

    public void LoadSavedCamera()
    {
        int cameraIndex  = PlayerPrefs.GetInt("current camera index");
        print(cameraIndex);
        string file = ReadCSV();
        string[] lines = file.Split("\n"[0]);
        string[] parts = lines[cameraIndex].Split(","[0]);
        float posX,posY,posZ,rotX,rotY,rotZ,fov;
        float.TryParse(parts[1], out posX);
        float.TryParse(parts[2], out posY);
        float.TryParse(parts[3], out posZ);
        float.TryParse(parts[4], out rotX);
        float.TryParse(parts[5], out rotY);
        float.TryParse(parts[6], out rotZ);
        float.TryParse(parts[7], out fov);

        currentCamera.transform.position = new Vector3(posX, posY, posZ);
        currentCamera.transform.localEulerAngles = new Vector3(rotX, rotY, rotZ);
        currentCamera.GetComponent<Camera>().fieldOfView = fov;
    }

    public void SaveScreenShot(bool isInGame)
    {
        string screenShotName = "/ScreenShots/Previews/" + PlayerPrefs.GetInt("last camera index") + ".jpg";
            if (isInGame)
        {
            screenShotName = "/ScreenShots/In Scene Screenshots/" +System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";
        }

        int resWidth = 1600;
        int resHeight = 900;
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        GetComponent<Camera>().targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        GetComponent<Camera>().Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        GetComponent<Camera>().targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Application.dataPath + screenShotName;
        File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", filename));
    }




    private string GetPath()
    {
        return Application.dataPath + "/CSV/" + "Saved_Cameras.csv";
    }

    public string ReadCSV()
    {
        string file = "";
        if (File.Exists(GetPath()))
        {
            FileStream fileStream = new FileStream(GetPath(), FileMode.Open, FileAccess.ReadWrite);
            StreamReader read = new StreamReader(fileStream);
            file = read.ReadToEnd();
        }
        return file;
    }

    private void Update()
    {
 
    }
}
