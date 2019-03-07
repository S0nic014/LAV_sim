using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsBehaviour : MonoBehaviour
{
    public GameObject[] frontLightobjs;
    private Light[] frontLights;

    void Start(){   
        frontLights= new Light[frontLightobjs.Length];
        Debug.Log(frontLights.Length); 
        for (int i=0; i<frontLightobjs.Length; i++)
        {
            frontLights[i]=frontLightobjs[i].GetComponent<Light>();
        } 
    }
    void Update(){
        SwitchLights();
    }

    private void SwitchLights(){
        if (Input.GetKeyUp(KeyCode.L)){
            for (int i=0; i<frontLights.Length; i++){
                frontLights[i].enabled=!frontLights[i].enabled;
            }
        }

    }
}
