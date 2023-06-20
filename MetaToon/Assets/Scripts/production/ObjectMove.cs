using UnityEngine;
using UnityEngine.UI;

public class ObjectMove : MonoBehaviour
{
    public GameObject targetObject; // 이동할 오브젝트
    public float moveSpeed = 5.0f; // 이동 속도
    public bool isButtonClick;

    void Update()
    {
        if (targetObject != null && isButtonClick == true)
        {
            // 키보드 입력을 사용하여 오브젝트 이동
            float horizontal = 0.0f;
            float vertical = 0.0f;
            float depth = 0.0f;

            // X 축 이동
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                horizontal = Input.GetAxis("Horizontal");
            }
            // Z축 이동
            if (Input.GetKey(KeyCode.Q))
            {
                vertical = 1.0f; 
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                vertical = -1.0f; 
            }
            // Y축 이동
            if (Input.GetKey(KeyCode.W))
            {
                depth = 1.0f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                depth = -1.0f;
            }

            // 이동 벡터 계산
            Vector3 moveDirection = new Vector3(horizontal, vertical, depth) * moveSpeed * Time.deltaTime;

            // 이동 벡터를 현재 위치에 더하여 오브젝트 이동
            targetObject.transform.position += moveDirection;
        }
        
    }

    public void buttonClick()
    {
        GameObject.Find("GameObject").GetComponent<ObjectSize>().sizeUiInActive();
        GameObject.Find("GameObject").GetComponent<ObjectRotation>().rotUiInActive();

        if (targetObject != null)
        {
            isButtonClick = true;
        }
        
    }

    public void MoveObject()
    {
        // 오브젝트 이동 벡터 계산
        //Vector3 moveDirection = new Vector3(1.0f, 0.0f, 0.0f) * moveSpeed * Time.deltaTime;

        // 이동 벡터를 현재 위치에 더하여 오브젝트 이동
        //targetObject.transform.position += moveDirection;
    }
}
