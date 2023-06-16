using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UploadWebtoon : MonoBehaviour
{
    private string dirName = "Assets/Resources/Screenshots"; // 웹툰 저장되는 폴더
    private string fileName = "DemoSample2.jpg"; // 웹툰 사진 파일 명
    private string server = "34.145.65.5:46351"; // 서버 주소
    //private string server = "192.168.61.52:46351";
    private byte[] pngArray; // Byte array of the Image

    public Button uploadBtn; // 업로드 버튼(버튼 클릭 시 업로드 하는 경우)

    private string token = LoginScene.token; // 로그인 시 생성되는 코드(추후 로컬에서 가져오는 방식으로 변경 예정)

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
        form.AddField("toonTitle", "testToon2"); // testToon2 가 웹툰 제목

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
