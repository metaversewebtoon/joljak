using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using System.IO.Compression;
using System.Collections;
using TMPro;

public class UserWebtoonLoader : MonoBehaviour
{
    public GameObject itemPrefab; // Prefab of the UI item for each file
    public Transform containerParent; // Parent transform to hold the UI items

    private string serverURL = "http://34.145.65.5:46351/toon_archive"; // Replace with your server API URL

    private string token = LoginScene.token;

    private void Start()
    {
        StartCoroutine(LoadFilesFromServer());
    }

    private IEnumerator LoadFilesFromServer()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(serverURL))
        {
            request.SetRequestHeader("token", token);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to retrieve files from the server: " + request.error);
                yield break;
            }

            // Save the zip file to disk
            string zipFilePath = Path.Combine(Application.persistentDataPath, "files.zip");
            File.WriteAllBytes(zipFilePath, request.downloadHandler.data);

            // Unzip the file
            string extractPath = Path.Combine(Application.persistentDataPath, "ExtractedFiles");
            ZipFile.ExtractToDirectory(zipFilePath, extractPath);

            // Get all the files in the extracted folder
            string[] files = Directory.GetFiles(extractPath, "*.*", SearchOption.AllDirectories);

            // Instantiate and position UI items dynamically
            for (int i = 0; i < files.Length; i++)
            {
                Debug.Log(Path.GetFileName(files[i]));
                // Create a new UI item
                GameObject item = Instantiate(itemPrefab, containerParent);

                // Set position and layout for the UI item
                RectTransform itemRectTransform = item.GetComponent<RectTransform>();
                itemRectTransform.anchoredPosition = new Vector2(400f,-100f +( -i * 50f)); // Vertically stack items with 50 units spacing

                // Set the name of the file as the UI item's text
                string fileName = Path.GetFileName(files[i]); // 1_testToon.png
                string title;

                string[] fileNameParts = fileName.Split('_');
                title = fileNameParts[0] + ". " +fileNameParts[1].Split('.')[0];

                TMP_Text itemText = item.GetComponentInChildren<TMP_Text>();
                itemText.text = title;
            }

            // Clean up the extracted files
            Directory.Delete(extractPath, true);
            File.Delete(zipFilePath);
        }
    }
}
