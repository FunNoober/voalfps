using System;
using UnityEngine;
using UnityEditor;

public class ScreenshotUtility : EditorWindow
{
    private string imageName;

    [MenuItem("Tools/ScreenShot")]
    public static void CreateWindow()
    {
        GetWindow<ScreenshotUtility>("ScreenShot");
    }

    private void OnGUI()
    {
        imageName = EditorGUILayout.TextField("Name", imageName);
        if(GUILayout.Button("Save Image"))
        {
            ScreenCapture.CaptureScreenshot(imageName + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".png");
        }
    }
}