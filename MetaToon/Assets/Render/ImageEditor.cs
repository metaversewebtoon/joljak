using System.Collections;
using System.Collections.Generic;
using Microsoft.Cci;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageEditor : MonoBehaviour
{
    private string dirName = "Screenshots";
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
}
