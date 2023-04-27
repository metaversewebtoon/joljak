using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void prefabCreate()
    {
        string buttonName = GameObject.Find("GameObject").GetComponent<SceneChanger>().ButtonName(1);
        string prefabName = buttonName + "_prefab";

        GameObject obj = Instantiate(Resources.Load<GameObject>(prefabName));

        Debug.Log("∫≠∆∞ ¿Ã∏ß" + buttonName);
        if (buttonName.Contains("avatar"))
        {
            obj.AddComponent<SA.FullBodyIKBehaviour>();
            obj.AddComponent<AttachControlTarget>();

        }
    }
}
