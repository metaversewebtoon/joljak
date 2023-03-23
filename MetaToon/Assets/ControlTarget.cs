using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTarget : MonoBehaviour
{
    float distance = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnMouseDrag()
	{
        Vector3 mousePosition = new Vector2(Input.mousePosition.x,
Input.mousePosition.y);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //objPosition.z = 0;
        transform.position = objPosition;
    }
}

