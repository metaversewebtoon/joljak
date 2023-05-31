using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MyResponseData
{
    public string result;
    public string token;
}

public class LoginScene : MonoBehaviour
{
    public TMP_InputField idField;
    public TMP_InputField passwordField;

    public Button submitBtn;
    public Button registerBtn;

    public TMP_Text errorText;

    public static string token;

    public void Start()
    {
        errorText.text = "";
    }

    public void CallLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", idField.text);
        form.AddField("password", passwordField.text);
        using (UnityWebRequest requestPost = UnityWebRequest.Post("http://34.145.65.5:46351/api/user/login", form))/*"http://34.145.65.5:46351/api/user/login"*/
        {
            yield return requestPost.SendWebRequest();

            if (requestPost.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(requestPost.error);
                errorText.text = "Error logging in user: " + requestPost.error;
                yield break;
            }

            // Check if the response from the server indicates a successful login
            if (requestPost.responseCode == 200)
            {
                Debug.Log("User logged in successfully");

                // Get the response data as JSON
                string jsonResponse = requestPost.downloadHandler.text;

                // Parse the JSON data
                MyResponseData responseData = JsonUtility.FromJson<MyResponseData>(jsonResponse);

                token = responseData.token;
                Debug.Log("token = " + token);

                SceneManager.LoadScene("main");
            }
            else
            {
                Debug.LogError("Incorrect username or password");
                errorText.text = "Incorrect username or password";
            }
        }
    }

    public void VerifyInputs()
    {
        submitBtn.interactable = (idField.text.Length >= 1 && passwordField.text.Length >= 4);
    }

    public void LoadUserRegisterScene()
    {
        string userRegister = "UserRegister";
        SceneManager.LoadScene(userRegister);
    }
}
