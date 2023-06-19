using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CaptureScene : MonoBehaviour
{
    private byte[] _pngArray;
    private int _sequence;
    private int _sceneID;
    private CaptureTable _captureTable;

    [SerializeField]
    private Button _captureButton;
    private Camera _cam;
    
    // Start is called before the first frame update
    void Start()
    {
        _captureTable = Resources.Load<CaptureTable>($"Tables/Capture/CaptureTable");
        _captureButton.onClick.AddListener(SaveCameraView);
        _cam = GetComponent<Camera>();
    }


    public void SaveCameraView()
    {
        Toggle();
        RenderTexture screenTexture = new RenderTexture(Screen.width, Screen.height, 16);
        _cam.targetTexture = screenTexture;
        RenderTexture.active = screenTexture;
        _cam.Render();
        Texture2D renderedTexture = new Texture2D(Screen.width, Screen.height);
        renderedTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        RenderTexture.active = null;
        byte[] byteArray = renderedTexture.EncodeToPNG();
        SendString(byteArray);
        System.IO.File.WriteAllBytes(Application.dataPath + "/cameracapture.png", byteArray);
        Toggle();
    }
    public void CaptureImage() { }  
    public void SaveImage() { }
    public IEnumerator SendString(byte[] imageData)
    {
        // Create a form to send the byte array to the server
        WWWForm form = new WWWForm();

        form.AddBinaryData("file", imageData, "Test.png", "image/png");

        // Create a UnityWebRequest to send the form to the server
        using (UnityWebRequest requestPost = UnityWebRequest.Post("http://" + _captureTable.serverIP + "/file/upload", form))
        {
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
    private string CreateSerial() { return "d"; }

    private void Toggle()
    {
        _cam.cullingMask ^= 1 << LayerMask.NameToLayer("UI");
        _cam.cullingMask ^= 1 << LayerMask.NameToLayer("ControlObject");
    }
}
