using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetUserInfo : MonoBehaviour
{
    private string server = "34.145.65.5:46351";
    private string token = LoginScene.token;

    public TMP_Text idText;
    //public TMP_Text passwdText;
    public TMP_Text nameText;

    public Canvas ChangePasswdCanvas;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        ChangePasswdCanvas.enabled = false;

        yield return null; // Wait for a frame

        using (UnityWebRequest requestGet = UnityWebRequest.Get("http://" + server + "/api/user"))
        {
            requestGet.SetRequestHeader("token", token);
            yield return requestGet.SendWebRequest();

            if (requestGet.result == UnityWebRequest.Result.Success)
            {
                // Get the response data as JSON
                string jsonResponse = requestGet.downloadHandler.text;
                Debug.Log(jsonResponse);

                // Parse the JSON data
                // JsonUtility.FromJson 이 자꾸 오류나서 아래 함수로 실행
                UserInfo[] userInfoArray = JsonConvert.DeserializeObject<UserInfo[]>(jsonResponse);

                if (userInfoArray.Length > 0)
                {
                    UserInfo userInfo = userInfoArray[0];

                    idText.text = userInfo.email;
                    //passwdText.text = userInfo.password;
                    nameText.text = userInfo.name;
                }
            }
            else
            {
                // Request failed, handle the error
                Debug.Log("Error: " + requestGet.error);
            }
        }
    }
}

[System.Serializable]
public class UserInfo
{
    public int id;
    public string email;
    public string password;
    public string name;
    public string created_at;
}