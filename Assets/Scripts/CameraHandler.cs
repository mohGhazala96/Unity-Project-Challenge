using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public GameObject newCamera;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("last camera index", -1);

    }

    public void SaveCamera(Vector3 cameraPosition, Vector3 cameraRotation, float lensLength)
    {
        string filePath = GetPath();

        //This is the writer, it writes to the filepath
        StreamWriter writer =  File.AppendText(filePath);

        int newCameraIndex = PlayerPrefs.GetInt("last camera index", -1) + 1;
        PlayerPrefs.SetInt("last camera index", newCameraIndex);

        writer.WriteLine(
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

    public void LoadLastSavedCamera()
    {
        string file = ReadCSV();
        string[] lines = file.Split("\n"[0]);
        string[] parts = lines[lines.Length-2].Split(","[0]);
        float posX,posY,posZ,rotX,rotY,rotZ,fov;
        float.TryParse(parts[1], out posX);
        float.TryParse(parts[2], out posY);
        float.TryParse(parts[3], out posZ);
        float.TryParse(parts[4], out rotX);
        float.TryParse(parts[5], out rotY);
        float.TryParse(parts[6], out rotZ);
        float.TryParse(parts[7], out fov);

        newCamera.transform.position = new Vector3(posX, posY, posZ);
        newCamera.transform.localEulerAngles = new Vector3(rotX, rotY, rotZ);
        newCamera.GetComponent<Camera>().fieldOfView = fov;
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


}
