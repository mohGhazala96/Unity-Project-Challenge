using System.Collections;
using System.Collections.Generic;
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



    // Start is called before the first frame update
    void Start()
    {
        if (CameraCreationController.Instance != null)
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


            xRotationSlider.minValue = CameraCreationController.minimumAngleValue;
            xRotationSlider.maxValue = CameraCreationController.maximumAngleValue;
            xRotationSlider.value = CameraCreationController.Instance.intialCameraRotation.x;

            yRotationSlider.minValue = CameraCreationController.minimumAngleValue;
            yRotationSlider.maxValue = CameraCreationController.maximumAngleValue;
            yRotationSlider.value = CameraCreationController.Instance.intialCameraRotation.y;

            zRotationSlider.minValue = CameraCreationController.minimumAngleValue;
            zRotationSlider.maxValue = CameraCreationController.maximumAngleValue;
            zRotationSlider.value = CameraCreationController.Instance.intialCameraRotation.z;

            xPositionSlider.minValue = CameraCreationController.minimum2DPosition;
            xPositionSlider.maxValue = CameraCreationController.maximum2DPosition;
            xPositionSlider.value = CameraCreationController.Instance.initialCameraPosition.x;

            yPositionSlider.minValue = CameraCreationController.minimumVerticalPosition;
            yPositionSlider.maxValue = CameraCreationController.maximumVerticalPosition;
            yPositionSlider.value = CameraCreationController.Instance.initialCameraPosition.y;


            zPositionSlider.minValue = CameraCreationController.minimum2DPosition;
            zPositionSlider.maxValue = CameraCreationController.maximum2DPosition;
            zPositionSlider.value = CameraCreationController.Instance.initialCameraPosition.z;

            lensLengthSlider.minValue = CameraCreationController.minimumLensLength;
            lensLengthSlider.maxValue = CameraCreationController.maximumLensLegnth;
            lensLengthSlider.value = CameraCreationController.lensLength;
        


    }

    void UpdateCameraRotation()
    {
        if (CameraCreationController.Instance != null)
        {
            CameraCreationController.Instance.ChangeCameraRotation(xRotationSlider.value, yRotationSlider.value, zRotationSlider.value);
            UpdateTextUi();
        }
    }

    void UpdateCameraPosition()
    {
        if (CameraCreationController.Instance != null)
        {
            CameraCreationController.Instance.ChangeCameraPosition(xPositionSlider.value, yPositionSlider.value, zPositionSlider.value);
            UpdateTextUi();
        }
    }

    void UpdateCameraLens()
    {
        if (CameraCreationController.Instance != null)
        {
            CameraCreationController.Instance.ChangeCameraLensLegth(lensLengthSlider.value);
            UpdateTextUi();
        }
    }

    public void SaveCamera()
    {
        CameraCreationController.Instance.SaveCamera();
        SceneManager.LoadScene("Main Scene");
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
        //Main Scene
        //Main Scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
