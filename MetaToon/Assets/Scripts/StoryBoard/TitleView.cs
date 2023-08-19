using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleView : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_InputField _field;

    public string titletext { 
        get
		{
            return _field.text;
		}
    }
    void Start()
    {
        _field = GetComponent<TMP_InputField>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   
}
