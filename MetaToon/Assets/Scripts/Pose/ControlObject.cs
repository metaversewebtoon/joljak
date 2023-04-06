using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObject
{
    private Transform _head;
    private Transform _leftWrist;
    private Transform _rightWrist;
    private Transform _leftFoot;
    private Transform _rightFoot;

    public Transform head { get; set; }
    public Transform leftWrist { get; set; }
    public Transform rightWrist { get; set; }
    public Transform leftFoot { get; set; }
    public Transform rightFoot { get; set; }

    public void SetControlObjectsTransform(SA.FullBodyIK fk, GameObject prefab, Transform parent)
	{
        GameObject coParent = new GameObject("ControlObjects");
        coParent.transform.parent = parent;
        GameObject tempControlObject;


        

        tempControlObject = Object.Instantiate(prefab);
        tempControlObject.name = "HeadControl";
        tempControlObject.transform.parent = coParent.transform;
        head = tempControlObject.transform;
        head.position = fk.headEffectors.head.transform.position;

        tempControlObject = Object.Instantiate(prefab);
        tempControlObject.name = "LeftWristControl";
        tempControlObject.transform.parent = coParent.transform;
        leftWrist = tempControlObject.transform;
        leftWrist.position = fk.leftArmBones.wrist.transform.position;

        tempControlObject = Object.Instantiate(prefab);
        tempControlObject.name = "RightWristControl";
        tempControlObject.transform.parent = coParent.transform;
        rightWrist = tempControlObject.transform;
        rightWrist.position = fk.rightArmBones.wrist.transform.position;

        tempControlObject = Object.Instantiate(prefab);
        tempControlObject.name = "LefFootControl";
        tempControlObject.transform.parent = coParent.transform;
        leftFoot = tempControlObject.transform;
        leftFoot.position = fk.leftLegBones.foot.transform.position;

        tempControlObject = Object.Instantiate(prefab);
        tempControlObject.name = "RightFootControl";
        tempControlObject.transform.parent = coParent.transform;
        rightFoot = tempControlObject.transform;
        rightFoot.position = fk.rightLegBones.foot.transform.position;
    }
}
