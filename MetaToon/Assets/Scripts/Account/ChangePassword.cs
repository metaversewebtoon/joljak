using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ChangePassword : MonoBehaviour
{
    public Canvas ChangePasswdCanvas;
    public Canvas UserWebtoonCanvas;
    public Button ChangePasswdBtn;
    public TMP_Text ChangePasswdBtnText;

    public TMP_InputField originalPasswdField;
    public TMP_InputField newPasswdField;

    public Button submitBtn;

    private string token = LoginScene.token;

    private void Start()
    {
        ChangePasswdBtnText = ChangePasswdBtn.GetComponentInChildren<TMP_Text>();
    }

    public void ShowChangePassword()
    {
        ChangePasswdCanvas.enabled = !ChangePasswdCanvas.enabled;
        UserWebtoonCanvas.enabled = !UserWebtoonCanvas.enabled;

        if (ChangePasswdBtnText.text == "비밀번호 변경")
        {
            ChangePasswdBtnText.text = "변경 취소";
        }
        else if (ChangePasswdBtnText.text == "변경 취소")
        {
            ChangePasswdBtnText.text = "비밀번호 변경";
        }
    }

    public void CallChangePassword()
    {
        StartCoroutine(ChangePasswd());
    }

    IEnumerator ChangePasswd()
    {
        WWWForm form = new WWWForm();
        form.AddField("originalPw", originalPasswdField.text);
        Debug.Log("originalPw: " + originalPasswdField.text);
        form.AddField("newPw", newPasswdField.text);
        Debug.Log("newPw: " + newPasswdField.text);

        using (UnityWebRequest requestPost = UnityWebRequest.Post("http://34.145.65.5:46351/api/user_update", form))
        {
            requestPost.SetRequestHeader("token", token);
            yield return requestPost.SendWebRequest();

            if (requestPost.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("비밀번호 변경 실패: "+requestPost.error);
                yield break;
            }

            if (requestPost.responseCode == 200)
            {
                Debug.Log("비밀번호 변경 성공");
            }
            else
            {
                Debug.LogError("password error");
            }
        }
    }

    public void VerifyInputs()
    {
        submitBtn.interactable = (newPasswdField.text.Length >= 4);
    }
}
