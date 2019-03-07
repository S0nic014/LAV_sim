using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public Transform turret;
    private Camera cam;
    public float turnRate = 30.0f;
    public float leftTraverse=180.0f;
    public float rightTraverse=180.0f;

    public bool showArcs=false;
    public bool showDebugRay=false;

    private Vector3 aimPoint;

    private bool aiming=false;
    private bool atRest=false;

    public bool Idle{get{return !aiming;}}
    public bool AtRest{get{return atRest;}}

    void Start()
    {   
        //cam=Camera.main;

        if(aiming==false)
            aimPoint=transform.TransformPoint(Vector3.forward*100.0f);

        Debug.Log(string.Format("Starting aimpoint: {0} {1} {2} ", aimPoint.x, aimPoint.y, aimPoint.z));
    }

    void Update()
    {
        SetAimPoint(GetCamAim());
        RotateTurret();

        if (showDebugRay)
        {
            DrawDebugRays();
        }
    }


    private Vector3 GetCamAim()
    {
        Vector3 point=new Vector3();
        Event currentEvent=Event.current;
        Vector2 mousePos=new Vector2();

        mousePos.x=currentEvent.mousePosition.x;
        mousePos.y=currentEvent.mousePosition.y;
        
        point=cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        return point;
    }
    public void SetAimPoint(Vector3 position)
    {
        aiming=true;
        aimPoint=position;
    }

    public void setIdle(bool idle)
    {
        aiming=!idle;

        if (aiming)
            atRest=false;
    }


    private void RotateTurret()
    {
        if (aiming)
        {
            RotateBase();
        }
        else if(!atRest)
        {
            atRest=RotatetoIdle();
        }
    }
    private void RotateBase()
    {
        Vector3 localTargetPos=transform.InverseTransformPoint(aimPoint);
        localTargetPos.y=0.0f;
        Vector3 clampedLocalVec2Target = localTargetPos;

        if (localTargetPos.x>=0.0f)
            clampedLocalVec2Target=Vector3.RotateTowards(Vector3.forward, localTargetPos, Mathf.Deg2Rad*rightTraverse, float.MaxValue);
        else
            clampedLocalVec2Target=Vector3.RotateTowards(Vector3.forward, localTargetPos, Mathf.Deg2Rad*leftTraverse, float.MaxValue);

        Quaternion rotationGlobal=Quaternion.LookRotation(clampedLocalVec2Target);
        Quaternion newRotation=Quaternion.RotateTowards(turret.localRotation, rotationGlobal, turnRate*Time.deltaTime);

        turret.localRotation=newRotation;
    }

    private bool RotatetoIdle()
    {
        bool baseFinished=false;

        Quaternion newRotation=Quaternion.RotateTowards(turret.localRotation, Quaternion.identity, turnRate*Time.deltaTime);
        turret.localRotation=newRotation;

        if(turret.localRotation==Quaternion.identity)
        {
            baseFinished=true;
        }

        return baseFinished;
    }

    private void DrawDebugRays()
    {
        if (turret!=null)
            Debug.DrawRay(turret.position, turret.forward*100.0f);
    }

}

