# Unity-Project-Challenge

This project only uses Unity. 
The aim is to let the user to easily test out different camera positions and camera moves.


## Main Features 

```
1. Create new camera
2. Adjust camera parameters in the Camera Creation scene using sliders
3. Animate the created cameras 
```
## Extra Features
```
1. View list of created cameras (snapshots)
2. Take a screenshot when animating the camera
3. Override current camera paramters when animating the camera

```
#### feature 1: 
The user can see a screenshot previews of the saved cameras in the Main menu.
#### feature 2: 
The user can take a screenshot while animating the camera which will be saved in the project.
#### feature 3: 
The user can override the current camera properties when animating the camera in the Main Animation Scene. After they override it the old values of the camera will be replaced with the new ones.

## Scenes
There are 3 main scenes to this application
### Main menu
This scene allows the user to either create a new camera which will redirect him/her to Camera Creation scene ot View the list of the created cameras which will then show the list view.
![Main menu](https://github.com/mohGhazala96/Unity-Project-Challenge/blob/master/app%20main%20screens/Main%20Menu.png)

Once the user clicks on View Created camera he will be showed a list of previewes (Preview UI Holder) of all avialable cameras . One can also click on the left top button to return back to the original view. User can click on the button under th camera previewes to choose the camera they want to animate.
![List View](https://github.com/mohGhazala96/Unity-Project-Challenge/blob/master/app%20main%20screens/List%20view.png)

### Camera Creation
This is the camera creation scene where one can adjust position,rotation, lens length using sliders. One can also reset the camera parameters to the default parameters. The last two button allows the user to save the camera and then get directed to the Main Animation scene where the user can animate the current camera, Or go back the main menu. Moreover, the white plane with they grey cube (camera) is where the user will be able to visualize how the camera is moving. Finally, the user can see what the actual camera view in the panel at the bottom of the screen.  <br /> 
The new camera is instaintiated from the current camera the user is adjusting its values. After the user creates a new camera, a prefab for it is created under reasources/saved cameras/. As well as it's preview is saved under Screenshots/Previews. 
![Camera Creation Scene](https://github.com/mohGhazala96/Unity-Project-Challenge/blob/master/app%20main%20screens/Creation.png)

### Main Animation Scene
This scene allows the user to animate the camera using keyboard controls. One can view these keyboard controls by clicking on the Help button. One can also override the current camera parameters after animating the camera. Also one can save a screenshot which will be saved in the assets folder under ScreenShots/In Scene Screenshots/ . Finally one can return back to the main menu using the main menu button.  <br /> 
The camera here is loaded from the saved camera prefabs in reasources/saved cameras/ . 
![Main Animation Scene](https://github.com/mohGhazala96/Unity-Project-Challenge/blob/master/app%20main%20screens/Animation%20Scene.png)

These are the controls guide the user will be presented by after they click the help button.
![Main Animation Scene](https://github.com/mohGhazala96/Unity-Project-Challenge/blob/master/app%20main%20screens/help.png)


## Scripts

* CameraController <br /> 
This script is responsible for saving a new camera or editing a saved one. Also it is resposible for taking screenshots and previewes for the camera.
* CamerePreviewUiElementHandler <br /> 
This script is responsible for handilng a camera preview in the Main menu. (this is attached to Preview UI holder Prefab)
* MainSceneHandler <br /> 
This script is responsible for animating the camera in the Main Animation Scene.
* UIManager <br /> 
This script is responsible for everything in the Ui in all three scenes.

## Prefabs

* Preview UI Holder <br /> 
This prefab has the CamerePreviewUiElementHandler attached to it. Prefabs of this type are instaitaited to show the camera preview with button underneath them in the Main Menu scene.

