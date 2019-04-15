using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    public GameObject audioObj;
    private AudioSource audioSrs;
    public float minPitch=0.8f;
    public float idlePitch=1f;
    public float currentPitch;
    public float maxPitch=1.3f;
    public float deltaPitch=0.01f;
    // Start is called before the first frame update
    void Start()
    {
        audioSrs=audioObj.GetComponent<AudioSource>();
        audioSrs.pitch=idlePitch;
        currentPitch=audioSrs.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)){
            if(currentPitch<maxPitch){}
                StopCoroutine("ToIdle");
                StartCoroutine("SpeedUp");
        }

        if (Input.GetKeyDown(KeyCode.S)){
            if(currentPitch>minPitch){}
                StopCoroutine("ToIdle");
                StartCoroutine("SlowDown");
        }

        if ((Input.GetKeyUp(KeyCode.W))||(Input.GetKeyUp(KeyCode.S))){
            if(currentPitch!=idlePitch){}
                StopCoroutine("SpeedUp");
                StopCoroutine("SlowDown");
                StartCoroutine("ToIdle");
        }
    }

    IEnumerator SpeedUp(){
        yield return new WaitForSeconds(0.2f);
        if (currentPitch<maxPitch){
            audioSrs.pitch+=deltaPitch;
            currentPitch=audioSrs.pitch; 
            StartCoroutine("SpeedUp");
        }
    }

    IEnumerator SlowDown(){
        yield return new WaitForEndOfFrame();
        if (currentPitch>minPitch){
            audioSrs.pitch-=deltaPitch;
            currentPitch=audioSrs.pitch; 
            StartCoroutine("SlowDown");
        }
    }

    IEnumerator ToIdle(){
        yield return new WaitForEndOfFrame();

        if (currentPitch>idlePitch){
            audioSrs.pitch-=deltaPitch;
            currentPitch=audioSrs.pitch; 
        }
        
        else if (currentPitch<idlePitch)
        {
            audioSrs.pitch+=deltaPitch;
            currentPitch=audioSrs.pitch;
        }
        StartCoroutine("ToIdle");
    }


}
