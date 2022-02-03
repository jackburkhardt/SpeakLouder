using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BuildManager : MonoBehaviour
{

    [SerializeField] private int screenWidth;
    [SerializeField] private int screenHeight;
    [SerializeField] private Canvas debugScreen;

    void Awake() {
        foreach (var display in Display.displays)
        {
            display.Activate();
        }

        Screen.SetResolution(screenWidth,screenHeight, FullScreenMode.FullScreenWindow);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        if (Input.GetKeyDown(KeyCode.D)) debugScreen.enabled = !debugScreen.enabled;
        
    }

}
