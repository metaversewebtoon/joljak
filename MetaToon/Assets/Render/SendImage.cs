using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Woo
{
    public class SendImage : MonoBehaviour
    {
        private string ImgString = "Base64 String";
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SendString());
        }

        // Update is called once per frame
        void Update()
        {

        }

        public IEnumerator SendString()
        {
            // Create a form to send the string to the server
            WWWForm form = new WWWForm();
            form.AddField("email", "aaa@aaa.com");
            form.AddField("password", "1234");
            form.AddField("name", "Woo");

            // Create a UnityWebRequest to send the form to the server
            using(UnityWebRequest request = UnityWebRequest.Post("192.168.82.71:3000/api/user/register", form))
            {
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
    }
}


/* node.js ¼­¹ö javascript

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