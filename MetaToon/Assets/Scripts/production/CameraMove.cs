using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private float _zoomSpeed = 50.0f;
    [SerializeField]
    private float _rotateSpeed = 100.0f;

    private Vector3 _prePosition;


    private float _distance = 10.0f;

    private Transform _targetObject;

    private Vector3 _lookVec;

    private bool _isDrag= false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        MouseScrollEvent();
        if (_targetObject)
        {
            _lookVec = Vector3.Normalize(_targetObject.position - this.transform.position);
            _distance = Vector3.Distance(_targetObject.position, this.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt) && _targetObject) _targetObject = null;
        if (Input.GetMouseButtonDown(0))
        {
            _isDrag = true;
            _prePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);


            RaycastHit hit;
            Ray ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.Equals(null)) // 오브젝트 아니면 null
                {
                    _targetObject = null;
                    Debug.Log("hit none");
                    return;
                }
                    

                Transform objectHit = hit.transform;
                _targetObject = objectHit;
                this.transform.LookAt(_targetObject);
                
            }
        }
        if(Input.GetMouseButton(0))
		{
           if(_isDrag)
			{
                Debug.Log("drag");
                if (!_targetObject)
                    return;

                Vector3 currentPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                Vector3 direction = _prePosition - currentPosition;
                Debug.Log(direction);
                float rotationAroundYAxis = -direction.x * 180; 
                float rotationAroundXAxis = direction.y * 180;
                this.transform.position = _targetObject.position;

                this.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                this.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);
                this.transform.Translate(new Vector3(0, 0, -_distance));

                _prePosition = currentPosition;
            }
        }
        if(Input.GetMouseButtonUp(0))
		{
            Debug.Log("dragup");
            _isDrag = false;
		}

        

    }

    private void LookTargetObject() { }
    private void RotateWithTarget() {
        if (_targetObject)
        { }
		else 
        { }
    }


    private void DragEvent() { }
    private void MouseScrollEvent() {
        Vector2 scrollDelta = Input.mouseScrollDelta;
        Vector3 targetPos = this.transform.position + _lookVec * scrollDelta.y * Time.deltaTime * _zoomSpeed;
        this.transform.position = targetPos;
        Debug.Log("줌");
    }
    
}
