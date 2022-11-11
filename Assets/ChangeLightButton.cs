using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class ChangeLightButton : MonoBehaviour
{
    // create light list that can be updated in the inspector
    public List<Light> Lights;
    // create frame and button variables 
    private VisualElement frame;
    private Button button;

    public string myText;
    // This function is called when the object becomes enabled and active.
    void OnEnable()
    {
        // get the UIDocument component (make sure this name matches!)
        var uiDocument = GetComponent<UIDocument>();
        // get the rootVisualElement (the frame component)
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame1");
        // get the button, which is nested in the frame
        button = frame.Q<Button>("Button1");
        // create event listener that calls ChangeLight() when pressed
        button.RegisterCallback<ClickEvent>(ev => ChangeLight());
    }
    // initialize click count
    int click = 0;
    private void ChangeLight()
    {
        EnableLight(click);
        click++;
        // reset counter so it is not out of bounds (only have 4 lights + 1 dim)
        // if (click > 4)
        // {
        //     click = 0;
        // }
        // reset counter so it is not out of bounds (on, off, dim)
        if (click > 2)
        {
            click = 0;
        }
    }
    // private void EnableLight(int n) // switch between lights & dimness
    // {
    //     // disable each of the cameras
    //     Lights.ForEach(lit => lit.enabled = false);
    //     // Cameras.ForEach(cam => cam.depth = 0);
    //     // enable the selected camera
    //     if (n != 4){
    //         if (n == 0){
    //             Lights[0].intensity = (Lights[0].intensity * 2);
    //             Lights[1].intensity = (Lights[1].intensity * 2);
    //             Lights[2].intensity = (Lights[2].intensity * 2);
    //             Lights[3].intensity = (Lights[3].intensity * 2);
    //         }
    //         Lights[n].enabled = true;
    //     } else {
    //         Lights.ForEach(lit => lit.enabled = true);
    //         Lights[0].intensity = (Lights[0].intensity / 2);
    //         Lights[1].intensity = (Lights[1].intensity / 2);
    //         Lights[2].intensity = (Lights[2].intensity / 2);
    //         Lights[3].intensity = (Lights[3].intensity / 2);
    //     }
        
    //     // Cameras[n].depth = 1;
    // }
    private void EnableLight(int n) // switch between light on / off / dim
    {
        // disable each of the cameras
        Lights.ForEach(lit => lit.enabled = false);
        // Cameras.ForEach(cam => cam.depth = 0);
        // enable the selected camera
        if (n == 0){ // dim
            Lights[0].intensity = (Lights[0].intensity / 5);
            Lights[1].intensity = (Lights[1].intensity / 5);
            Lights[2].intensity = (Lights[2].intensity / 5);
            Lights[3].intensity = (Lights[3].intensity / 10);
            Lights.ForEach(lit => lit.enabled = true);
        } else if (n == 1) { // on
            Lights[0].intensity = (Lights[0].intensity * 5);
            Lights[1].intensity = (Lights[1].intensity * 5);
            Lights[2].intensity = (Lights[2].intensity * 5);
            Lights[3].intensity = (Lights[3].intensity * 10);
            Lights.ForEach(lit => lit.enabled = true);
        } else { // off
            Lights.ForEach(lit => lit.enabled = false);
        }
        
        // Cameras[n].depth = 1;
    }
}