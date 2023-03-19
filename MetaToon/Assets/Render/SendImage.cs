using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendImage : MonoBehaviour
{
    private string ImgString = "Base64 String";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SendString()
    {
        // Create a form to send the string to the server
        WWWForm form = new WWWForm();
        form.AddField("image string", ImgString);

        // Create a UnityWebRequest to send the form to the server
        UnityWebRequest request = UnityWebRequest.Post("/*서버 주소*/", form);
        yield return request.SendWebRequest();

        // Check for errors
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("String sent successfully");
        }

    }
}

/* node.js 서버 javascript

    const express = require('express');
    const bodyParser = require('body-parser');

    const app = express();
    app.use(bodyParser.urlencoded({ extended: true }));

    app.post('/upload', (req, res) => {
      // Get the string data from the request
      const myString = req.body.myString;

      // Do something with the string data
      console.log(myString);

      // Send a response
      res.send('String received!');
    });

    app.listen(3000, () => {
      console.log('Server running on port 3000');
    });

 */