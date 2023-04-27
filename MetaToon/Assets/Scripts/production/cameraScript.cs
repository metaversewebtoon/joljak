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
	LayerMask layerMask;
	bool isAlt;
	Vector2 clickPoint;

	GameObject hitObject;

	private Transform _lookTarget;

	private Vector3 _lookVec;
	private float _distance = 10.0f;
	private Vector3 _prePosition;
	private bool _isDrag = false;

	private void Start()
	{

	}

	void Update()
	{
		if(hitObject)
		{
			_lookVec = Vector3.Normalize(hitObject.transform.position+Vector3.up - this.transform.position);
		}

		if (Input.GetKeyDown(KeyCode.LeftAlt) && hitObject) hitObject = null;
		if (Input.GetKeyDown(KeyCode.LeftAlt)) isAlt = true;
		if (Input.GetKeyUp(KeyCode.LeftAlt)) isAlt = false;
		if (Input.GetMouseButtonDown(0)) clickPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

		// 마우스 왼쪽 버튼을 클릭할 때
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			// 스크롤 비활성화
			GameObject.Find("GameObject").GetComponent<scrollScript>().ScrollInactive();
			_prePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			_isDrag = true;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 현재 마우스 위치에서 Ray 생성

			RaycastHit hit;
			// Ray가 충돌한 물체를 인식한 경우 오브젝트 조정
			if (Physics.Raycast(ray, out hit))
			{
				hitObject = hit.collider.gameObject;

				_distance = Vector3.Distance(hitObject.transform.position + Vector3.up, this.transform.position);

				Debug.Log("인식된 물체: " + hitObject.name);
				if (hitObject.layer != LayerMask.NameToLayer("UI"))
				{
					objectClick();
				}
			}
			// 인식된 물체가 없는 경우 카메라 조정

		}
		if (Input.GetMouseButton(0))
		{
			if (_isDrag)
			{
				if (!hitObject)
				{
					objectClickNo();
					// Alt키 누른 경우 카메라 이동
					if (isAlt)
					{
						Vector3 position = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);

						position.z = position.y;
						position.y = .0f;

						Vector3 move = position * (Time.deltaTime * dragSpeed);

						transform.Translate(move);
					}
					// Alt키 누르지 않은 경우 카메라 회전
					else
					{
						xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed*1.5f;
						yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed*1.5f;

						yRotate = transform.eulerAngles.y + yRotateMove;

						xRotate = xRotate + xRotateMove;

						xRotate = Mathf.Clamp(xRotate, -90, 90); // 위, 아래 고정

						transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
					}
				}
				else
				{

					Vector3 currentPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
					Vector3 direction = _prePosition - currentPosition;
					Debug.Log(direction);
					float rotationAroundYAxis = -direction.x * 180;
					float rotationAroundXAxis = direction.y * 180;
					this.transform.position = hitObject.transform.position+ Vector3.up;

					this.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
					this.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);
					this.transform.Translate(new Vector3(0, 0, -_distance));

					_prePosition = currentPosition;
				}
			}
		}
		if (Input.GetMouseButtonUp(0))
			_isDrag = false;

		if (hitObject)
		{
			MouseScrollEvent();
		}
		else
		{
			float scroollWheel = Input.GetAxis("Mouse ScrollWheel");
			Vector3 targetPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + scroollWheel * Time.deltaTime * scrollSpeed*100);
			this.transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * 1);
		}
	}

	void objectClick()
	{
		if (hitObject.layer == LayerMask.NameToLayer("avatar"))
		{
			GameObject.Find("GameObject").GetComponent<lookScript>().avatar = hitObject;
		}
		GameObject.Find("GameObject").GetComponent<ObjectMove>().targetObject = hitObject;
		GameObject.Find("GameObject").GetComponent<ObjectRotation>().targetObject = hitObject;
		GameObject.Find("GameObject").GetComponent<ObjectSize>().targetObject = hitObject;
	}

	void objectClickNo()
	{
		GameObject.Find("GameObject").GetComponent<lookScript>().avatar = null;
		GameObject.Find("GameObject").GetComponent<ObjectMove>().targetObject = null;
		GameObject.Find("GameObject").GetComponent<ObjectRotation>().targetObject = null;
		GameObject.Find("GameObject").GetComponent<ObjectSize>().targetObject = null;

		GameObject.Find("GameObject").GetComponent<ObjectMove>().isButtonClick = false;
		GameObject.Find("GameObject").GetComponent<ObjectSize>().sizeUiInActive();
		GameObject.Find("GameObject").GetComponent<ObjectRotation>().rotUiInActive();
	}

	private void MouseScrollEvent()
	{
		Vector2 scrollDelta = Input.mouseScrollDelta;
		
		Vector3 targetPos = this.transform.position + _lookVec * scrollDelta.y * Time.deltaTime * scrollSpeed;
		this.transform.position = targetPos;
	}

}
