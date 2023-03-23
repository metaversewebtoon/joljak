using System.Collections;
using System.Collections.Generic;
using Microsoft.Cci;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;
using Woo;
using UnityEngine.Networking;

public class ImageEditor : MonoBehaviour
{
    private string dirName = "Assets/Render/Screenshots";
    private string fileName = "TestImage.png";
    private string server = "192.168.82.71:3000";
    private byte[] pngArray;

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
                StartCoroutine(SendString(base64String, imageData));
                StartCoroutine(GetByte());
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

    public IEnumerator SendString(String base64String, byte[] imageData)
    {
        // Create a form to send the string to the server
        WWWForm form = new WWWForm();
        WWWForm form2 = new WWWForm();
        form.AddField("email", "ddd@ddd.com");
        form.AddField("password", "1234");
        form.AddField("name", base64String);

        form2.AddBinaryData("file", imageData, "Woo.png", "image/png");

        // Create a UnityWebRequest to send the form to the server
        using (UnityWebRequest requestPost = UnityWebRequest.Post("http://" + server + "/file/upload", form2))
        {
            yield return requestPost.SendWebRequest();

            // Check for errors
            if (requestPost.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(requestPost.error);
            }
            else
            {
                Debug.Log("String sent successfully");
            }
        }
    }

    public IEnumerator GetByte()
    {
        DirectoryInfo screenshotDirectory = Directory.CreateDirectory(dirName);
        //string fullPath = Path.Combine(screenshotDirectory.FullName, fileName);
        using (UnityWebRequest requestGet = UnityWebRequest.Get("http://" + server + "/file/1"))
        {
            yield return requestGet.SendWebRequest();
            pngArray = requestGet.downloadHandler.data;
            Texture2D texture = new Texture2D(1, 1);
            texture = BytesToTexture2D(pngArray);
            SaveTextureToFile(texture, "C:/");

            // Check for errors
            if (requestGet.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(requestGet.error);
            }
            else
            {
                Debug.Log("String sent successfully");
            }
        }
    }
    public static Texture2D BytesToTexture2D(byte[] bytes)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(bytes);
        return texture;
    }

    public static void SaveTextureToFile(Texture2D texture, string filePath)
    {
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);
    }

    // Convert Image Texture to Base64 String
    public static string TextureToBase64(Texture2D texture)
    {
        byte[] bytes = texture.EncodeToPNG();
        string base64String = Convert.ToBase64String(bytes);
        return base64String;
    }
}
