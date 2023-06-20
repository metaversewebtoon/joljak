using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelete : MonoBehaviour
{
    public GameObject targetObject; // 삭제할 오브젝트

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
