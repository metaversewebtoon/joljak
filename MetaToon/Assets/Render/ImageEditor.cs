using System.Collections;
using System.Collections.Generic;
using Microsoft.Cci;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ImageEditor : MonoBehaviour
{
    private string dirName = "Assets/Render/Screenshots";
    private string fileName = "TestImage.png";

    public Button btn_CaptureScreen; // Button for Capturing screen
    public GameObject UserInterface; // Set UI(e.g. Canvas) from inspector menu

    // Start is called before the first frame update
    void Start()
    {
        btn_CaptureScreen.onClick.AddListener(CaptureScreen);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator WaitFrame()
    {
        // Number of frames to wait
        //int skipFrame = 1;
        //Debug.Log(skipFrame);
        //for (int i = 0; i < skipFrame; i++)
        //{
        //    yield return null;
        //}
        yield return null; // wait for 1 frame
        UserInterface.SetActive(true);
    }

    void CaptureScreen()
    {
        UserInterface.SetActive(false);
        // If UI is hidden
        if (!UserInterface.activeSelf)
        {
            try
            {
                // Capture and Save Screen
                DirectoryInfo screenshotDirectory = Directory.CreateDirectory(dirName);
                string fullPath = Path.Combine(screenshotDirectory.FullName, fileName);
                ScreenCapture.CaptureScreenshot(fullPath);
                Debug.Log("Saved Screenshot : " + fullPath);

                // Convert Image to Base64 String
                byte[] imageData = File.ReadAllBytes(fullPath);
                Texture2D texture = new Texture2D(0, 0);
                texture.LoadImage(imageData);
                string base64String = TextureToBase64(texture);
                Debug.Log("Base64 String : " + base64String);
            }
            catch (System.Exception e)
            {
                Debug.Log("Error : " + e.Message);
            }
            finally
            {
                StartCoroutine(WaitFrame());
            }
        }
    }

    // Convert Image Texture to Base64 String
    public static string TextureToBase64(Texture2D texture)
    {
        byte[] bytes = texture.EncodeToPNG();
        string base64String = Convert.ToBase64String(bytes);
        return base64String;
    }
}
