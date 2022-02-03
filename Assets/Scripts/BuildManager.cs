using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BuildManager : MonoBehaviour
{

    [SerializeField] private int screenWidth = 1920, screenHeight = 1080;
    [SerializeField] private Canvas debugScreen;

    void Awake() {
        
        foreach (var display in Display.displays)
        {
            display.Activate();
        }

        Screen.SetResolution(screenWidth, screenHeight, FullScreenMode.FullScreenWindow);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if esc is pressed, close program
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        // if D is pressed, toggle visibility of debug canvas
        if (Input.GetKeyDown(KeyCode.D)) debugScreen.enabled = !debugScreen.enabled;
        
    }

}
