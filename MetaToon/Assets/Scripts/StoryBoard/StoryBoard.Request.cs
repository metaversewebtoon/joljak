using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public partial class StoryBoard
{ 
	enum RequestType { GET, POST}

	private byte[] pngArray; // Byte array of the Image



	//private string token = LoginScene.token; // 로그인 시 생성되는 코드(추후 로컬에서 가져오는 방식으로 변경 예정)
	public void LoadZipFile()
	{
		var form = new WWWForm();
		var request = UnityWebRequest.Get("http://" + table.serverIP + "/file_archive");
		SendRequest(request);
		var data = request.downloadHandler.data;
		File.WriteAllBytes(table.zipPath, data);
		Unzip(table.zipPath, table.resourceDir);
	}

	public void UploadStoryBoard(byte[] imageData, string title)
	{
		var form = new WWWForm();
		form.AddBinaryData("toon", imageData, "Test.png", "image/png");
		form.AddField("toonTitle", title);
		var request = UnityWebRequest.Post("http://" + table.serverIP + "/toon/upload",form);
		SendRequest(request);
	}

	

	public bool Unzip( string sourcePath, string desPath)
	{
		try
		{
			if (Directory.Exists(desPath))
				Directory.Delete(desPath);
			ZipFile.ExtractToDirectory(sourcePath, desPath);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public IEnumerable SendRequest(UnityWebRequest request)
	{
		using (UnityWebRequest webrequest = request)
		{
			//requestPost.SetRequestHeader("token", token);
			yield return webrequest.SendWebRequest();

			// Check for errors
			if (webrequest.result != UnityWebRequest.Result.Success)
			{
				Debug.Log(webrequest.error);
			}
			else
			{
				Debug.Log("Image sent successfully");
			}
		}
	}
}