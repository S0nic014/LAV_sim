using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    //Turret object transfrom
    public Transform turret;
    //Target object tranform to rotate to
    public Transform target;
    //Rotation speed of turret
    public float traverseSpeed=30f;

    //Rotation limits, range(0,180)
    public float leftTraverse=180f;
    public float rightTraverse=180f;
    //aimVector
    private Vector3 aimPoint;

    void Start()
    {

    }

    void Update()
    {
        HandleTurret();
    }

    private void HandleTurret()
    {   
        aimPoint=target.position;
        Vector3 localTargetPos=transform.InverseTransformPoint(aimPoint);
        localTargetPos.y=0f;
        Vector3 clampedTargetPos=localTargetPos;

        if (localTargetPos.x>=0.0f)
            clampedTargetPos=Vector3.RotateTowards(Vector3.forward, localTargetPos, Mathf.Deg2Rad*rightTraverse, float.MaxValue);
        else
            clampedTargetPos=Vector3.RotateTowards(Vector3.forward, localTargetPos, Mathf.Deg2Rad*leftTraverse, float.MaxValue);

        Quaternion rotationGlobal=Quaternion.LookRotation(clampedTargetPos);
        Quaternion newRotation=Quaternion.RotateTowards(turret.localRotation, rotationGlobal, traverseSpeed*Time.deltaTime);

        turret.localRotation=newRotation;
    }

}
