using UnityEngine;
using UnityEngine.UI;

public class ObjectMove : MonoBehaviour
{
    public GameObject targetObject; // �̵��� ������Ʈ
    public float moveSpeed = 5.0f; // �̵� �ӵ�

    void Update()
    {
        if (targetObject != null)
        {
            // Ű���� �Է��� ����Ͽ� ������Ʈ �̵�
            float horizontal = 0.0f;
            float vertical = 0.0f;
            float depth = 0.0f;

            // ����Ű �Է� ����
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

            // �̵� ���� ���
            Vector3 moveDirection = new Vector3(horizontal, vertical, depth) * moveSpeed * Time.deltaTime;

            // �̵� ���͸� ���� ��ġ�� ���Ͽ� ������Ʈ �̵�
            targetObject.transform.position += moveDirection;
        }
        
    }

    public void MoveObject()
    {
        // ������Ʈ �̵� ���� ���
        Vector3 moveDirection = new Vector3(1.0f, 0.0f, 0.0f) * moveSpeed * Time.deltaTime;

        // �̵� ���͸� ���� ��ġ�� ���Ͽ� ������Ʈ �̵�
        targetObject.transform.position += moveDirection;
    }
}
