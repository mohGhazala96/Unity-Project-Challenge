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
        xRotationSlider.minValue = 0;
        xRotationSlider.maxValue = 360;
        xRotationSlider.value = SceneController.Instance.currentCamera.transform.localEulerAngles.x;
        xRotationSlider.onValueChanged.AddListener(delegate { UpdateCameraRotation(); });

        yRotationSlider.minValue = 0;
        yRotationSlider.maxValue = 360;
        yRotationSlider.value = SceneController.Instance.currentCamera.transform.localEulerAngles.y;
        yRotationSlider.onValueChanged.AddListener(delegate { UpdateCameraRotation(); });

        zRotationSlider.minValue = 0;
        zRotationSlider.maxValue = 360;
        zRotationSlider.value = SceneController.Instance.currentCamera.transform.localEulerAngles.z;
        zRotationSlider.onValueChanged.AddListener(delegate { UpdateCameraRotation(); });

        xPositionSlider.minValue = -14;
        xPositionSlider.maxValue = 14;
        xPositionSlider.value = SceneController.Instance.currentCamera.transform.position.x;
        xPositionSlider.onValueChanged.AddListener(delegate { UpdateCameraPosition(); });

        yPositionSlider.minValue = 1;
        yPositionSlider.maxValue = 10;
        yPositionSlider.value = SceneController.Instance.currentCamera.transform.position.y;
        yPositionSlider.onValueChanged.AddListener(delegate { UpdateCameraPosition(); });


        zPositionSlider.minValue = -14;
        zPositionSlider.maxValue = 14;
        zPositionSlider.value = SceneController.Instance.currentCamera.transform.position.z;
        zPositionSlider.onValueChanged.AddListener(delegate { UpdateCameraPosition(); });

        lensLengthSlider.minValue = 0;
        lensLengthSlider.maxValue = 144;
        lensLengthSlider.value = SceneController.Instance.currentCamera.fieldOfView;
        lensLengthSlider.onValueChanged.AddListener(delegate { UpdateCameraLens(); });

        UpdateCameraRotation();
        UpdateCameraPosition();
        UpdateCameraLens();
    }

    void UpdateCameraRotation()
    {
        if (SceneController.Instance != null)
        {
            SceneController.Instance.ChangeCameraRotation(xRotationSlider.value, yRotationSlider.value, zRotationSlider.value);
            xRotationText.text = "Horizontal Rotation : " + (int)xRotationSlider.value;
            yRotationText.text = "Vertical Rotation : " + (int)yRotationSlider.value;
            zRotationText.text = "Forward Rotation : " + (int)zRotationSlider.value;

        }
    }

    void UpdateCameraPosition()
    {
        if (SceneController.Instance != null)
        {
            SceneController.Instance.ChangeCameraPosition(xPositionSlider.value, yPositionSlider.value, zPositionSlider.value);
            xPositionText.text = "Horizontal Position : " + (int)xPositionSlider.value;
            yPositionText.text = "Vertical Position : " + (int)yPositionSlider.value;
            zPositionText.text = "Forward Position : " + (int)zPositionSlider.value;
        }
    }

    void UpdateCameraLens()
    {
        if (SceneController.Instance != null)
        {
            SceneController.Instance.ChangeCameraLensLegth(lensLengthSlider.value);
            lensLengthText.text = "Length : " + (int)lensLengthSlider.value;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
