using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelete : MonoBehaviour
{
    public GameObject targetObject; // ������ ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void objectDelete()
    {
        if (targetObject != null)
        {
            Destroy(targetObject);
        }
    }
}
