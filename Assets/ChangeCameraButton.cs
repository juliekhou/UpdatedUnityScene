using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeCameraButton : MonoBehaviour
{
    // Create camera list that can be updated in the inspector
    public List<Camera> Cameras;

    // Create frame & button variables
    private VisualElement frame;
    private Button button;

    void OnEnable()
    {
        // Get the UIDocument component
        var uiDocument = GetComponent<UIDocument>();

        // Get the rootVisualElement (the frame component)
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame");

        // Get the button, which is nested in the frame
        button = frame.Q<Button>("Button");

        // Create event listener that calls ChangeCamera() when pressed
        button.RegisterCallback<ClickEvent>(ev => ChangeCamera());
    }

    // Initialize click count
    int click = 0;
    private void ChangeCamera()
    {
        EnableCamera(click);
        click++;

        // Reset counter so it is not out of bounds (only have 4 cameras)
        if (click > 3){
            click = 0;
        }
    }
    private void EnableCamera(int n)
    {
        // disable each of the cameras
        Cameras.ForEach(cam => cam.enabled = false);

        // enable the selected camera
        Cameras[n].enabled = true;
    }
}
