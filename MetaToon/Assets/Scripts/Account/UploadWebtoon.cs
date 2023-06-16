using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UploadWebtoon : MonoBehaviour
{
    private string dirName = "Assets/Resources/Screenshots"; // ���� ����Ǵ� ����
    private string fileName = "DemoSample2.jpg"; // ���� ���� ���� ��
    private string server = "34.145.65.5:46351"; // ���� �ּ�
    //private string server = "192.168.61.52:46351";
    private byte[] pngArray; // Byte array of the Image

    public Button uploadBtn; // ���ε� ��ư(��ư Ŭ�� �� ���ε� �ϴ� ���)

    private string token = LoginScene.token; // �α��� �� �����Ǵ� �ڵ�(���� ���ÿ��� �������� ������� ���� ����)

    // Start is called before the first frame update
    void Start()
    {
        uploadBtn.onClick.AddListener(CaptureScreen);
    }

    void CaptureScreen()
    {
        try
        {
            // Capture and Save Screen
            DirectoryInfo screenshotDirectory = Directory.CreateDirectory(dirName);
            string fullPath = Path.Combine(screenshotDirectory.FullName, fileName);
            Debug.Log("path: " + fullPath);

            // Send Byte array of the image to DB
            byte[] imageData = File.ReadAllBytes(fullPath);
            StartCoroutine(SendString(imageData));
        }
        catch (System.Exception e)
        {
            Debug.Log("Error : " + e.Message);
        }
    }

    IEnumerator SendString(byte[] imageData)
    {
        // Create a form to send the byte array to the server
        WWWForm form = new WWWForm();

        //String token = LoginScene.token;
        //Debug.Log("token = "+token);


        form.AddBinaryData("toon", imageData, "Test.png", "image/png");
        form.AddField("toonTitle", "testToon2"); // testToon2 �� ���� ����

        // Create a UnityWebRequest to send the form to the server
        using (UnityWebRequest requestPost = UnityWebRequest.Post("http://" + server + "/toon/upload", form))
        {
            requestPost.SetRequestHeader("token", token);
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
