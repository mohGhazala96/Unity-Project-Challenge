using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Class <c>MainSceneHandler</c> is  responsible handling everything in the Ui in all three scenes.
///</summary>

public class UIManager : MonoBehaviour
{
    /// <summary>Instance variable <c>xPositionSlider</c> represents the slider the user will control to change the horizontal position of the current Camera
    /// </summary>
    public Slider xPositionSlider;

    /// <summary>Instance variable <c>xRotationSlider</c> represents the slider the user will control to change the horizontal rotation of the current Camera
    /// </summary>
    public Slider xRotationSlider;

    /// <summary>Instance variable <c>yPositionSlider</c> rrepresents the slider the user will control to change the vertical position of the current Camera
    /// </summary>
    public Slider yPositionSlider;

    /// <summary>Instance variable <c>yRotationSlider</c> represents the slider the user will control to change the vertical rotation of the current Camera
    /// </summary>
    public Slider yRotationSlider;

    /// <summary>Instance variable <c>zPositionSlider</c> represents the slider the user will control to change the foward position of the current Camera
    /// </summary>
    public Slider zPositionSlider;

    /// <summary>Instance variable <c>zRotationSlider</c> represents the slider the user will control to change the foward rotation of the current Camera
    /// </summary>
    public Slider zRotationSlider;

    /// <summary>Instance variable <c>lensLengthSlider</c> represents the slider the user will control to change the lens length of the current Camera
    /// </summary>
    public Slider lensLengthSlider;


    /// <summary>Instance variable <c>xPositionText</c> represents the text value that shows the current camera's horziontal position
    /// </summary>
    public Text xPositionText;

    /// <summary>Instance variable <c>yPositionText</c> represents the text value that shows the current camera's vertical position
    /// </summary>
    public Text yPositionText;

    /// <summary>Instance variable <c>zPositionText</c> represents the text value that shows the current camera's forward position
    /// </summary>
    public Text zPositionText;

    /// <summary>Instance variable <c>xRotationText</c> represents the text value that shows the current camera's horziontal rotation
    /// </summary>
    public Text xRotationText;

    /// <summary>Instance variable <c>yRotationText</c> represents the text value that shows the current camera's vertical rotation
    /// </summary>
    public Text yRotationText;

    /// <summary>Instance variable <c>zRotationText</c> represents the text value that shows the current camera's forward rotation
    /// </summary>
    public Text zRotationText;

    /// <summary>Instance variable <c>lensLengthText</c> represents the text value that shows the current camera's lens length
    /// </summary>
    public Text lensLengthText;


    /// <summary>Instance variable <c>contentInList</c> represents the holder gameobject for the list of saved camera previews in the main menu scene
    /// </summary>
    public GameObject contentInList;

    /// <summary>Instance variable <c>previewUIHolder</c> represents the prefab used when created the previews list in the main menu scene
    /// </summary>
    public GameObject previewUIHolder;


    /// <summary>Instance variable <c>previewPath</c> represents the path at which the previews will be saved in
    /// </summary>
    public const string previewPath ="/ScreenShots/Previews/";

    /// <summary>Instance variable <c>inGameScreenPath</c> represents the path at which the the screenshot taken when animating the camera will be saved in
    /// </summary>
    public const string inGameScreenPath =  "/ScreenShots/In Scene Screenshots/";

    /// <summary>Instance variable <c>isInCreationScene</c> represents the current camera the user is animating
    /// </summary>
    public bool isInCreationScene;

    void Start()
    {
        Init();
    }

    /// <summary>
    /// This method called to instialize the sliders values, listners as well as the values for the text variables
    /// </summary>
    void Init()
    {
        // assisgns the sliders listeners to either UpdateCameraRotation or UpdateCameraPosition or UpdateCameraLens
        // only in the camera creation  scene
        if (isInCreationScene)
        {

            xRotationSlider.onValueChanged.AddListener(delegate { UpdateCameraRotation(); });
            yRotationSlider.onValueChanged.AddListener(delegate { UpdateCameraRotation(); });
            zRotationSlider.onValueChanged.AddListener(delegate { UpdateCameraRotation(); });

            xPositionSlider.onValueChanged.AddListener(delegate { UpdateCameraPosition(); });
            yPositionSlider.onValueChanged.AddListener(delegate { UpdateCameraPosition(); });
            zPositionSlider.onValueChanged.AddListener(delegate { UpdateCameraPosition(); });

            lensLengthSlider.onValueChanged.AddListener(delegate { UpdateCameraLens(); });

            // resets the camera's parameters as well as intialize the text varaiables in the UI scene
            ResetCameraParameters();
        }
    }

    /// <summary>
    /// This method is reset the camera positional , lens length, rotational values
    /// Also it assigns the text variables in the scene to match the current camera parameters
    /// </summary>
    public void ResetCameraParameters()
    {
        InitValues();
        UpdateTextUi();
    }

    /// <summary>
    /// This method is reset the camera positional , lens length, rotational values
    /// As well as the maximum and minimum values for each of the parameters
    /// </summary>
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

    /// <summary>
    /// This method is used to assign the text varablies in the UI to match the current camera parameters
    /// </summary>
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

    /// <summary>
    /// This method is called whenever one of the three sliders responsible for altering the rotation is called
    /// </summary>
    void UpdateCameraRotation()
    {
        if (CameraController.Instance != null)
        {
            CameraController.Instance.ChangeCameraRotation(xRotationSlider.value, yRotationSlider.value, zRotationSlider.value);
            UpdateTextUi();
        }
    }

    /// <summary>
    /// This method is called whenever one of the three sliders responsible for altering the position is called
    /// </summary>
    void UpdateCameraPosition()
    {
        if (CameraController.Instance != null)
        {
            CameraController.Instance.ChangeCameraPosition(xPositionSlider.value, yPositionSlider.value, zPositionSlider.value);
            UpdateTextUi();
        }
    }

    /// <summary>
    /// This method is called slider responsible for altering the lens length is called
    /// </summary>
    void UpdateCameraLens()
    {
        if (CameraController.Instance != null)
        {
            CameraController.Instance.ChangeCameraLensLegth(lensLengthSlider.value);
            UpdateTextUi();
        }
    }

    /// <summary>
    /// This method is called when the user clicks the Save Camera button in the Camera Creation Scene
    /// </summary>
    public void SaveCamera()
    {
        CameraController.Instance.SaveCamera();
        SceneManager.LoadScene("Main Animation Scene");
    }

    /// <summary>
    /// This method is called when the user clicks the Override button in the Main Animation Scene
    /// </summary>
    public void SaveAnimatedCamera()
    {
        CameraController.Instance.SaveAnimatedCamera();
    }

    /// <summary>
    /// This method is called when the user clicks the Screenshot button in the Main Animation Scene
    /// To save a screen shot while animating the camera
    /// </summary>
    public void TakeScreenShot()
    {
        CameraController.Instance.SaveScreenShotDuringGame();
    }

    /// <summary>
    /// This method is called when the user clicks the Create Camera button in the Main menu
    /// </summary>
    public void CreateNewCamera()
    {
        SceneManager.LoadScene("Camera Creation");
    }

    /// <summary>
    /// This method is called when the user  the Main Menu button in any of the Scenes
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    /// <summary>
    /// This method is called to view the scene of the chosen camera when the user clicks any button of the camera previews in the main menu 
    /// </summary>
    public void LoadCamera(int cameraIndex)
    {
        PlayerPrefs.SetInt("current camera index", cameraIndex);
        SceneManager.LoadScene("Main Animation Scene");
    }

    /// <summary>
    /// This method is called when the user click the view created cameras button
    /// to instialize the list view of the camera previews in the main menu scene
    /// </summary>
    public void LoadCamerasPreviews()
    {
        //destroy all of the previously created previews
        for(int child = contentInList.transform.childCount - 1; child >= 0; child--)
        {
            Destroy(contentInList.transform.GetChild(child).gameObject);
        }

        // gets the  index of the last saved camera
        int lastCameraIndex = PlayerPrefs.GetInt("last camera index") ;

        // creates the list of the camera previews
        for(int cameraIndex= 1; cameraIndex<=lastCameraIndex; cameraIndex++)
        {
            GameObject currentPreviewUIHolder = Instantiate(previewUIHolder, contentInList.transform);

            // assigns the current camera's index 
            currentPreviewUIHolder.GetComponent<CamerePreviewUiElementHandler>().curentCameraIndex = cameraIndex;
            int curentCameraIndex = cameraIndex;

            // assigns the LoadCamera with the current camera's index as a listener, to load the this actual camera when the button is clicked
            currentPreviewUIHolder.GetComponent<CamerePreviewUiElementHandler>().viewButton.onClick.AddListener(() => LoadCamera(curentCameraIndex));

            // assigns the image for the current camera preview
            currentPreviewUIHolder.GetComponent<CamerePreviewUiElementHandler>().previewImage.texture = ReadTextureFromFiles(cameraIndex + ".jpg");

            // assigns the text for the button to the Camera's index
            currentPreviewUIHolder.GetComponent<CamerePreviewUiElementHandler>().buttonText.text = "Camera " +cameraIndex;

        }
    }

    /// <summary>
    /// This method is called to return the texture to based to the input parameters
    /// </summary>
    /// <returns>
    ///  The camera preview texture texture relative to the camera id
    /// </returns>
    /// <param name="filename"> Represent filename at which camera relative to the current camera id</param>
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
