using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Runtime.InteropServices;

public class ImageEditor : MonoBehaviour
{
    private string dirName = "Assets/Resources/Screenshots";
    private string fileName = "TestImage.png";
    private string server = "34.145.65.5:46351";
    //private string server = "192.168.61.52:46351";
    private byte[] pngArray; // Byte array of the Image

    public Button btn_CaptureScreen; // Button for Capturing screen
    public GameObject UserInterface; // Set UI(e.g. Canvas) from inspector menu

    public string token;


    // �� ���������� localStorage�� 'token' Ű�� ����� ���� �����ɴϴ�.
    [DllImport("__Internal")]
    private static extern string GetLocalStorageValue(string key);


    // Start is called before the first frame update
    void Start()
    {
        btn_CaptureScreen.onClick.AddListener(CaptureScreen);
        
        token = GetLocalStorageValue("token");
        Debug.Log("Token: " + token);
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

                // Send Byte array of the image to DB
                byte[] imageData = File.ReadAllBytes(fullPath);
                StartCoroutine(SendString(imageData));
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

    

    public IEnumerator SendString(byte[] imageData)
    {
        // Create a form to send the byte array to the server
        WWWForm form = new WWWForm();

        //String token = LoginScene.token;
        //Debug.Log("token = "+token);


        form.AddBinaryData("file", imageData, "Test.png", "image/png");
        form.AddField("fileTitle", "testFile");

        // Create a UnityWebRequest to send the form to the server
        using (UnityWebRequest requestPost = UnityWebRequest.Post("http://" + server + "/file/upload", form))
        {
            //requestPost.SetRequestHeader("token", token);
            yield return requestPost.SendWebRequest();
            
            // Check for errors
            if (requestPost.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(requestPost.error);
            }
            else
            {
                Debug.Log("Image sent successfully");
            }
        }
    }
}
