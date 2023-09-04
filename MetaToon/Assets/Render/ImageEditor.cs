using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Runtime.InteropServices;
using TMPro;

public class ImageEditor : MonoBehaviour
{
    private string dirName = "Assets/Resources/StoryBoard/Screenshots";
    private string fileName = "TestImage";
    private string server = "34.145.65.5:46351";
    //private string server = "192.168.61.52:46351";
    private byte[] pngArray; // Byte array of the Image

    public Button btn_CaptureScreen; // Button for Capturing screen
    public GameObject UserInterface; // Set UI(e.g. Canvas) from inspector menu

    public string token;
    public uint seq;

    public TMP_Text resultMsg;
    public GameObject panel;


    // 웹 브라우저에서 localStorage의 'token' 키에 저장된 값을 가져옵니다.
    [DllImport("__Internal")]
    private static extern string GetLocalStorageValue(string key);


    // Start is called before the first frame update
    void Start()
    {
        btn_CaptureScreen.onClick.AddListener(CaptureScreen);
        seq = 0;
        //token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiYWFhIiwiaWQiOjEsImlhdCI6MTY4NTM1NDM4NX0.d2We3d - BTPOiT_73A_TsJD1TwQmbzW7ZjxonuTvH0j0";
        token = GetLocalStorageValue("token");
        Debug.Log("Token: " + token);
    }



    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator WaitFrame()
    {
        yield return null; // wait for 1 frame
        UserInterface.SetActive(true);
        ControlObjectAble(true);
    }

    void CaptureScreen()
    {
        UserInterface.SetActive(false);
        ControlObjectAble(false);
        // If UI is hidden
        if (!UserInterface.activeSelf)
        {
            StartCoroutine(CaptureScreenCoroutine());
        }
    }

    IEnumerator CaptureScreenCoroutine()
    {
        yield return new WaitForEndOfFrame();

        try
        {
            // Capture the current screen as a texture
            Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            texture.Apply();

            // Convert the texture to a byte array
            byte[] imageData = texture.EncodeToPNG();
            File.WriteAllBytes(Application.persistentDataPath+"/" + fileName + seq.ToString() + ".png", imageData);
            seq++;
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
            requestPost.SetRequestHeader("token", token);
            yield return requestPost.SendWebRequest();
            
            // Check for errors
            if (requestPost.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(requestPost.error);
                StartCoroutine(ShowPanel());
                resultMsg.text = "Capture Failed";
            }
            else
            {
                Debug.Log("Image sent successfully");
                StartCoroutine(ShowPanel());
                resultMsg.text = "Capture Success";
            }
        }
    }

    IEnumerator ShowPanel()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(HidePanel());
    }
    IEnumerator HidePanel()
    {
        yield return new WaitForSeconds(1f);
        panel.SetActive(false);
    }

    void ControlObjectAble(bool state)
	{
        GameObject[] controls = GameObject.FindGameObjectsWithTag("control");
        foreach (var c in controls)
            c.SetActive(state);
	}
}
