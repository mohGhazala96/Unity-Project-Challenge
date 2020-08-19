# Unity-Project-Challenge

This project only uses Unity. 
The aim is to let the user to easily test out different camera positions and camera moves.


## Main Features 

```
1. Create new camera
2. View list of created cameras (snapshots)
3. Adjust camera parameters in the Camera Creation scene using sliders
4. Animate the created cameras 
5. Take a screenshot when animating the camera
6. Override current camera paramters when animating the camera

```
## Extra Feature


## Scenes
There are 3 main scenes to this application
### Main menu
This scene allows the user to either create a new camera which will redirect him/her to Camera Creation scene ot View the list of the created cameras which will then show the list view.
![Main menu](https://github.com/mohGhazala96/Unity-Project-Challenge/blob/master/app%20main%20screens/Main%20Menu.png)

Once the user clicks on View Created camera he will be showed a list of previewes of all avialable cameras. One can also click on the left top button to return back to the original view. User can click on the button under th camera previewes to choose the camera they want to animate.
![List View](https://github.com/mohGhazala96/Unity-Project-Challenge/blob/master/app%20main%20screens/List%20view.png)

### Camera Creation
This is the camera creation scene where one can adjust position,rotation, lens length using sliders. One can also reset the camera parameters to the default parameters. The last two button allows the user to save the camera and then get directed to the Main Animation scene where the user can animate the current camera, Or go back the main menu.
![Camera Creation Scene](https://github.com/mohGhazala96/Unity-Project-Challenge/blob/master/app%20main%20screens/Creation.png)

### Main Animation Scene
This scene allows the user to animate the camera using keyboard controls. One can view these keyboard controls by clicking on the Help button. One can also override the current camera parameters after animating the camera. Also one can save a screenshot which will be saved in the assets folder under ScreenShots/In Scene Screenshots/ . Finally one can return back to the main menu using the main menu button. 
![Main Animation Scene](https://github.com/mohGhazala96/Unity-Project-Challenge/blob/master/app%20main%20screens/Animation%20Scene.png)

These are the controls guide the user will be presented by after they click the help button.
![Main Animation Scene](https://github.com/mohGhazala96/Unity-Project-Challenge/blob/master/app%20main%20screens/help.png)


## Scripts

* CameraCreationController.cs
* CameraHandler.cs
* CamerePreviewUiElementHandler.cs
* MainSceneHandler.cs
* UIManager.cs

