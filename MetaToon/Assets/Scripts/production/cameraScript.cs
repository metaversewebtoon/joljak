using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cameraScript : MonoBehaviour
{
    public float rotateSpeed = 500.0f;
    public float scrollSpeed = 10.0f;
    float dragSpeed = 30.0f;
    private float xRotate, yRotate, xRotateMove, yRotateMove;

    bool isAlt;
    Vector2 clickPoint;

    private Transform _lookTarget;

	private void Start()
	{
		
	}

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt)) isAlt = true;
        if (Input.GetKeyUp(KeyCode.LeftAlt)) isAlt = false;

        if (Input.GetMouseButtonDown(0)) clickPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            GameObject.Find("GameObject").GetComponent<scrollScript>().ScrollInactive();

            if (isAlt)
            {
                Vector3 position = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);

                position.z = position.y;
                position.y = .0f;

                Vector3 move = position * (Time.deltaTime * dragSpeed);

                transform.Translate(move);
            }
            else
            {
                xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
                yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

                yRotate = transform.eulerAngles.y + yRotateMove;
                
                xRotate = xRotate + xRotateMove;

                xRotate = Mathf.Clamp(xRotate, -90, 90); // 위, 아래 고정

                transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
            }

        }
        else
        {
            float scroollWheel = Input.GetAxis("Mouse ScrollWheel");
            Vector3 targetPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + scroollWheel * Time.deltaTime * scrollSpeed);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * 1);

        }
    }
}
