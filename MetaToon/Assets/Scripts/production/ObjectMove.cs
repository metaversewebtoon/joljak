using UnityEngine;
using UnityEngine.UI;

public class ObjectMove : MonoBehaviour
{
    public GameObject targetObject; // 이동할 오브젝트
    public float moveSpeed = 5.0f; // 이동 속도

    void Update()
    {
        if (targetObject != null)
        {
            // 키보드 입력을 사용하여 오브젝트 이동
            float horizontal = 0.0f;
            float vertical = 0.0f;
            float depth = 0.0f;

            // 방향키 입력 감지
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                horizontal = Input.GetAxis("Horizontal");
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                vertical = Input.GetAxis("Vertical");
            }
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                depth = 1.0f;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                depth = -1.0f;
            }

            // 이동 벡터 계산
            Vector3 moveDirection = new Vector3(horizontal, vertical, depth) * moveSpeed * Time.deltaTime;

            // 이동 벡터를 현재 위치에 더하여 오브젝트 이동
            targetObject.transform.position += moveDirection;
        }
        
    }

    public void MoveObject()
    {
        // 오브젝트 이동 벡터 계산
        Vector3 moveDirection = new Vector3(1.0f, 0.0f, 0.0f) * moveSpeed * Time.deltaTime;

        // 이동 벡터를 현재 위치에 더하여 오브젝트 이동
        targetObject.transform.position += moveDirection;
    }
}
