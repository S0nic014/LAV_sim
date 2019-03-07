using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera firstPersonCam;
    public Camera thirdPersonCam;
    bool thirdSelected=true;

    void Start()
    {
        firstPersonCam.enabled=false;
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
            thirdPersonCam.enabled=thirdSelected;
        }
    }
}
