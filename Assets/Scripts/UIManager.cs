using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        xRotationSlider.onValueChanged.AddListener(delegate { UpdateCameraRotation(); });
        yRotationSlider.onValueChanged.AddListener(delegate { UpdateCameraRotation(); });
        zRotationSlider.onValueChanged.AddListener(delegate { UpdateCameraRotation(); });

        xPositionSlider.onValueChanged.AddListener(delegate { UpdateCameraPosition(); });
        yPositionSlider.onValueChanged.AddListener(delegate { UpdateCameraPosition(); });
        zPositionSlider.onValueChanged.AddListener(delegate { UpdateCameraPosition(); });

        lensLengthSlider.onValueChanged.AddListener(delegate { UpdateCameraLens(); });
        ResetCameraParameters();
    }

    void InitValues()
    {


        xRotationSlider.minValue = SceneController.minimumAngleValue;
        xRotationSlider.maxValue = SceneController.maximumAngleValue;
        xRotationSlider.value = SceneController.Instance.intialCameraRotation.x;

        yRotationSlider.minValue = SceneController.minimumAngleValue;
        yRotationSlider.maxValue = SceneController.maximumAngleValue;
        yRotationSlider.value = SceneController.Instance.intialCameraRotation.y;

        zRotationSlider.minValue = SceneController.minimumAngleValue;
        zRotationSlider.maxValue = SceneController.maximumAngleValue;
        zRotationSlider.value = SceneController.Instance.intialCameraRotation.z;

        xPositionSlider.minValue = SceneController.minimum2DPosition;
        xPositionSlider.maxValue = SceneController.maximum2DPosition;
        xPositionSlider.value = SceneController.Instance.initialCameraPosition.x;

        yPositionSlider.minValue =SceneController.minimumVerticalPosition;
        yPositionSlider.maxValue = SceneController.maximumVerticalPosition;
        yPositionSlider.value = SceneController.Instance.initialCameraPosition.y;


        zPositionSlider.minValue = SceneController.minimum2DPosition;
        zPositionSlider.maxValue = SceneController.maximum2DPosition;
        zPositionSlider.value = SceneController.Instance.initialCameraPosition.z;

        lensLengthSlider.minValue = SceneController.minimumLensLength;
        lensLengthSlider.maxValue = SceneController.maximumLensLegnth;
        lensLengthSlider.value = SceneController.lensLength;

    }

    void UpdateCameraRotation()
    {
        if (SceneController.Instance != null)
        {
            SceneController.Instance.ChangeCameraRotation(xRotationSlider.value, yRotationSlider.value, zRotationSlider.value);
            UpdateTextUi();
        }
    }

    void UpdateCameraPosition()
    {
        if (SceneController.Instance != null)
        {
            SceneController.Instance.ChangeCameraPosition(xPositionSlider.value, yPositionSlider.value, zPositionSlider.value);
            UpdateTextUi();
        }
    }

    void UpdateCameraLens()
    {
        if (SceneController.Instance != null)
        {
            SceneController.Instance.ChangeCameraLensLegth(lensLengthSlider.value);
            UpdateTextUi();
        }
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
