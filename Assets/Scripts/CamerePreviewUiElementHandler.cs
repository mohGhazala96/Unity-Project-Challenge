using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>CamerePreviewUiElementHandler</c> is responsible for handilng a camera preview (attached to the Preview UI Holder prefab) in the Main menu when prevewing the list of all the created cameras
/// Each preview has an image,button and a text for the button as well as the current camera index
///</summary>

public class CamerePreviewUiElementHandler : MonoBehaviour
{
    /// <summary>Instance variable <c>viewButton</c> represents the button in the (Preview UI Holder prefab) that the user will click to redirect to the main animation scene
    /// </summary>
    public Button viewButton;

    /// <summary>Instance variable <c>previewImage</c> represents the image in the (Preview UI Holder prefab) that shows the camera preview
    /// </summary>
    public RawImage previewImage;

    /// <summary>Instance variable <c>buttonText</c> represents the text that show the camera's Id
    /// </summary>
    public Text buttonText;

    /// <summary>Instance variable <c>curentCameraIndex</c> represents the camera's id
    /// </summary>
    public int curentCameraIndex;
}
