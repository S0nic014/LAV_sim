using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera firstPersonCam;
    public Camera thirdPersonCam;
    public GameObject scopeOverlay;
    public GameObject aimReticle;
    public GameObject cameraAim;
    bool thirdSelected=true;


    void Start()
    {   
        firstPersonCam.enabled=false;
        scopeOverlay.SetActive(firstPersonCam.enabled);
        thirdPersonCam.enabled=true;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchView();   
    }

    private void SwitchView()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            thirdSelected=!thirdSelected;
            firstPersonCam.enabled=!thirdSelected;
            scopeOverlay.SetActive(!thirdSelected);
            aimReticle.SetActive(thirdSelected);
            cameraAim.SetActive(thirdSelected);
            thirdPersonCam.enabled=thirdSelected;
        }
    }
}
