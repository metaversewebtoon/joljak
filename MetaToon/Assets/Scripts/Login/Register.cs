using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Register : MonoBehaviour
{
    public TMP_InputField idField;
    public TMP_InputField passwordField;
    public TMP_InputField nameField;

    public Button submitBtn;
    public TMP_Text errorText;

    public void Start()
    {
        errorText.text = "";
    }

    public void CallRegister()
    {
        StartCoroutine(Registering());
    }

    IEnumerator Registering()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", idField.text);
        form.AddField("password", passwordField.text);
        form.AddField("name", nameField.text);
        using(UnityWebRequest requestPost = UnityWebRequest.Post("http://34.145.65.5:46351/api/user/register", form))
        {
            yield return requestPost.SendWebRequest();

            // Check for errors
            if (requestPost.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(requestPost.error);
                errorText.text = "Error registering : " + requestPost.error;
            }
            else
            {
                Debug.Log("Info sent successfully");
                SceneManager.LoadScene("LoginScene");
            }
        }
    }

    public void VerifyInputs()
    {
        submitBtn.interactable = (idField.text.Length >= 1 && passwordField.text.Length >= 4 && nameField.text.Length >= 1);
    }
}
