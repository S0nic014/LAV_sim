using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float initialFOV;
    public float zoomedFOV=30.0f;
    public float currentFOV;   
    public Camera cam;
    public float zoomDelta=2.5f;

    void Start()
    {   
        initialFOV=cam.fieldOfView;
        currentFOV=initialFOV;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse1)){
            if(currentFOV>zoomedFOV)
                StartCoroutine("ZoomIn");

            else
                StartCoroutine("ZoomOut");
        }
    }

    
    IEnumerator ZoomIn(){
        yield return new WaitForFixedUpdate();

        if (currentFOV>zoomedFOV){
            cam.fieldOfView-=zoomDelta;
            currentFOV=cam.fieldOfView; 
            StartCoroutine("ZoomIn");
        }
    }
    
    IEnumerator ZoomOut(){
        yield return new WaitForFixedUpdate();

        if(currentFOV<initialFOV){
            cam.fieldOfView+=zoomDelta;
            currentFOV=cam.fieldOfView; 
            StartCoroutine("ZoomOut");
        }
    }
}
