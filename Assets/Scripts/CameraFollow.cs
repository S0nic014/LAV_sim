using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraMoveSpeed=120.0f;
    public GameObject cameraFollowobj;

    Vector3 followPos;
    public float upperclampAngle=80.0f;

    public float lowerClampAngle=28.0f;
    public float inputSensetivity=150.0f;
    public GameObject cameraObj;
    public GameObject playerObj;
    public float camDistanceXToPlayer; 
    public float camDistanceYToPlayer; 
    public float camDistanceZToPlayer; 
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotY=0.0f;
    private float rotX=0.0f;
    
    void Start()
    {
        Vector3 rot=transform.localRotation.eulerAngles;
        rotX=rot.x;
        rotY=rot.y;
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
    }

    // Update is called once per frame
    void Update()
    {//Setup the  rotation
        float inputX=Input.GetAxis("RightStickHorizontal");
        float inputZ=Input.GetAxis("RightStickVertical");
        mouseX=Input.GetAxis("Mouse X");
        mouseY=Input.GetAxis("Mouse Y");
        finalInputX=inputX+mouseX;
        finalInputZ=inputZ+mouseY;

        rotY+=finalInputX*inputSensetivity*Time.deltaTime;
        rotX+=finalInputZ*inputSensetivity*Time.deltaTime;

        rotX=Mathf.Clamp(rotX, -lowerClampAngle, upperclampAngle);

        Quaternion localRotation=Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation=localRotation;
    }

    void LateUpdate() {
        CameraUpdater();
    }

    void CameraUpdater()
    {   
        //Set target obj
         Transform target=cameraFollowobj.transform;

         //Move towards target obj
         float step=cameraMoveSpeed*Time.deltaTime;
         transform.position=Vector3.MoveTowards(transform.position, target.position, step);
    }

}
 