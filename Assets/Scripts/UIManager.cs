using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider xPositionSlider;
    public Slider yPositionSlider;
    public Slider zPositionSlider;
    public Slider xRotationSlider;
    public Slider yRotationSlider;
    public Slider zRotationSlider;
    public Slider lensLengthSlider;

    public Text xPositionText;
    public Text yPositionText;
    public Text zPositionText;
    public Text xRotationText;
    public Text yRotationText;
    public Text zRotationText;
    public Text lensLengthText;


    public GameObject contentInList;
    public GameObject previewUIHolder;

    public  const string previewPath ="/ScreenShots/Previews/";
    public  const string inGameScreenPath =  "/ScreenShots/In Scene Screenshots/";
    public bool isInCreationScene;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("last camera index", 0);
        //PlayerPrefs.SetInt("current camera index", 0);
        if (isInCreationScene)
        {

            xRotationSlider.onValueChanged.AddListener(delegate { UpdateCameraRotation(); });
            yRotationSlider.onValueChanged.AddListener(delegate { UpdateCameraRotation(); });
            zRotationSlider.onValueChanged.AddListener(delegate { UpdateCameraRotation(); });

            xPositionSlider.onValueChanged.AddListener(delegate { UpdateCameraPosition(); });
            yPositionSlider.onValueChanged.AddListener(delegate { UpdateCameraPosition(); });
            zPositionSlider.onValueChanged.AddListener(delegate { UpdateCameraPosition(); });

            lensLengthSlider.onValueChanged.AddListener(delegate { UpdateCameraLens(); });
            ResetCameraParameters();
        }
    }

    void InitValues()
    {
            xRotationSlider.minValue = CameraController.minimumAngleValue;
            xRotationSlider.maxValue = CameraController.maximumAngleValue;
            xRotationSlider.value = CameraController.intialCameraRotation.x;

            yRotationSlider.minValue = CameraController.minimumAngleValue;
            yRotationSlider.maxValue = CameraController.maximumAngleValue;
            yRotationSlider.value = CameraController.intialCameraRotation.y;

            zRotationSlider.minValue = CameraController.minimumAngleValue;
            zRotationSlider.maxValue = CameraController.maximumAngleValue;
            zRotationSlider.value = CameraController.intialCameraRotation.z;

            xPositionSlider.minValue = CameraController.minimum2DPosition;
            xPositionSlider.maxValue = CameraController.maximum2DPosition;
            xPositionSlider.value = CameraController.Instance.initialCameraPosition.x;

            yPositionSlider.minValue = CameraController.minimumVerticalPosition;
            yPositionSlider.maxValue = CameraController.maximumVerticalPosition;
            yPositionSlider.value = CameraController.Instance.initialCameraPosition.y;


            zPositionSlider.minValue = CameraController.minimum2DPosition;
            zPositionSlider.maxValue = CameraController.maximum2DPosition;
            zPositionSlider.value = CameraController.Instance.initialCameraPosition.z;

            lensLengthSlider.minValue = CameraController.minimumLensLength;
            lensLengthSlider.maxValue = CameraController.maximumLensLegnth;
            lensLengthSlider.value = CameraController.lensLength;
    }

    void UpdateCameraRotation()
    {
        if (CameraController.Instance != null)
        {
            CameraController.Instance.ChangeCameraRotation(xRotationSlider.value, yRotationSlider.value, zRotationSlider.value);
            UpdateTextUi();
        }
    }

    void UpdateCameraPosition()
    {
        if (CameraController.Instance != null)
        {
            CameraController.Instance.ChangeCameraPosition(xPositionSlider.value, yPositionSlider.value, zPositionSlider.value);
            UpdateTextUi();
        }
    }

    void UpdateCameraLens()
    {
        if (CameraController.Instance != null)
        {
            CameraController.Instance.ChangeCameraLensLegth(lensLengthSlider.value);
            UpdateTextUi();
        }
    }

    public void SaveCamera()
    {
        CameraController.Instance.SaveCamera();
        SceneManager.LoadScene("Main Animation Scene");
    }

    public void SaveAnimatedCamera()
    {
        CameraController.Instance.SaveAnimatedCamera();
    }

    public void TakeScreenShot()
    {
        CameraController.Instance.SaveScreenShotDuringGame();

    }

    public void ResetCameraParameters()
    {
        InitValues();
        UpdateTextUi();
    }

    public void UpdateTextUi()
    {
        xRotationText.text = "Horizontal Rotation : " + (int)xRotationSlider.value;
        yRotationText.text = "Vertical Rotation : " + (int)yRotationSlider.value;
        zRotationText.text = "Forward Rotation : " + (int)zRotationSlider.value;
        xPositionText.text = "Horizontal Position : " + (int)xPositionSlider.value;
        yPositionText.text = "Vertical Position : " + (int)yPositionSlider.value;
        zPositionText.text = "Forward Position : " + (int)zPositionSlider.value;
        lensLengthText.text = "Length : " + (int)lensLengthSlider.value;
    }

    public void CreateNewCamera()
    {
        SceneManager.LoadScene("Camera Creation");
    }

    public void LoadCamerasPreviews()
    {
        for(int child = contentInList.transform.childCount - 1; child >= 0; child--)
        {
            Destroy(contentInList.transform.GetChild(child).gameObject);
        }

        int lastCameraIndex = PlayerPrefs.GetInt("last camera index") ;
        for(int cameraIndex= 1; cameraIndex<=lastCameraIndex; cameraIndex++)
        {
            GameObject currentPreviewUIHolder = Instantiate(previewUIHolder, contentInList.transform);
            currentPreviewUIHolder.GetComponent<CamerePreviewUiElementHandler>().elementIndex = cameraIndex;
            int e = currentPreviewUIHolder.GetComponent<CamerePreviewUiElementHandler>().elementIndex; ;
            currentPreviewUIHolder.GetComponent<CamerePreviewUiElementHandler>().viewButton.onClick.AddListener(() => LoadCamera(e));
            currentPreviewUIHolder.GetComponent<CamerePreviewUiElementHandler>().previewImage.texture = ReadTextureFromFiles(cameraIndex + ".jpg");
            currentPreviewUIHolder.GetComponent<CamerePreviewUiElementHandler>().buttonText.text = "Camera " +cameraIndex;

        }
    }

    public void LoadCamera(int cameraIndex)
    {
        PlayerPrefs.SetInt("current camera index",cameraIndex);
        SceneManager.LoadScene("Main Animation Scene");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");

    }
    public Texture2D ReadTextureFromFiles(string filename)
    {
        Texture2D tex = null;

        try
        {
            var bytes = File.ReadAllBytes(Application.dataPath + previewPath + filename);
            tex = new Texture2D(1, 1);
            tex.LoadImage(bytes);
        }
        catch (Exception e)
        {
            Debug.Log($"There is Error: {e.ToString()}" + "\n");
        }
        return tex;


    }
}
