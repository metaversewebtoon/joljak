using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public partial class StoryBoard
{ 
	enum RequestType { GET, POST}

	private byte[] pngArray; // Byte array of the Image

	private string token;

	[DllImport("__Internal")]
	private static extern string GetLocalStorageValue(string key);

	//private string token = LoginScene.token; // 로그인 시 생성되는 코드(추후 로컬에서 가져오는 방식으로 변경 예정)
	public void LoadZipFile()
	{
		
		var request =  UnityWebRequest.Get("http://" + table.serverIP + "/file_archive");
		StartCoroutine(SendRequest(request));
	}

	public void UploadStoryBoard(byte[] imageData, string title)
	{
		//token = GetLocalStorageValue("token");
		token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiYWFhIiwiaWQiOjEsImlhdCI6MTY4NTM1NDM4NX0.d2We3d-BTPOiT_73A_TsJD1TwQmbzW7ZjxonuTvH0j0";
		var form = new WWWForm();
		form.AddBinaryData("toon", imageData, "Test.png", "image/png");
		form.AddField("toonTitle", title);
		var request = UnityWebRequest.Post("http://" + table.serverIP + "/toon/upload",form);
		request.SetRequestHeader("token", token);
		StartCoroutine(SendRequest(request));
		
	}

	

	public bool Unzip( string sourcePath, string desPath)
	{
		try
		{
			ZipFile.ExtractToDirectory(sourcePath, desPath);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public IEnumerator SendRequest(UnityWebRequest request)
	{
		using (UnityWebRequest webrequest = request)
		{
			Debug.Log("adad");
			yield return webrequest.SendWebRequest();
			
			// Check for errors
			if (webrequest.result != UnityWebRequest.Result.Success)
			{
				Debug.Log(webrequest.error);
			}
			else
			{
				Debug.Log("Image sent successfully");
				var data = webrequest.downloadHandler.data;
				var zippath = Application.persistentDataPath + "/" + table.zipPath;
				File.WriteAllBytes(zippath, data);
				Unzip(zippath, Application.persistentDataPath);
				RefreshAll();

			}
		}
	}
}