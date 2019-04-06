using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBehaviour : MonoBehaviour
{
    //TODO:Add slow down

    public float idleSpeed;
    public float idleSize;
    public float idleRate;

    public float maxSpeed=4.0f;
    public float maxSize=1.0f;
    public float maxRate=15.0f;

    public float speedDelta=0.2f;
    public float sizeDelta=0.1f;
    public float rateDelta=3.0f;
    public float currentSpeed;
    public float currentSize;
    public float currentRate;
    private ParticleSystem smoke;
    void Start()
    {
        smoke=GetComponent<ParticleSystem>();
        idleSpeed=smoke.startSpeed;
        idleSize=smoke.startSize;
        idleRate=smoke.emissionRate;

        currentSpeed=smoke.startSpeed;
        currentSize=smoke.startSize;
        currentRate=smoke.emissionRate;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            if (currentSpeed<maxSpeed){
                StartCoroutine("SpeedUp");
            }

            if (currentSize<maxSize){
                StartCoroutine("SizeUp");
            }

            if (currentRate<maxRate){
                StartCoroutine("RateUp");
            }
        }
    }

    IEnumerator SpeedUp(){
        yield return new WaitForFixedUpdate();
        if (currentSpeed<maxSpeed){
            smoke.startSpeed+=speedDelta;
            currentSpeed=smoke.startSpeed;
            StartCoroutine("SpeedUp");
        }
    }

    IEnumerator SizeUp(){
        yield return new WaitForFixedUpdate();
        if (currentSize<maxSize){
            smoke.startSize+=sizeDelta;
            currentSize=smoke.startSize;
            StartCoroutine("SizeUp");
        }
    }

    IEnumerator RateUp(){
        yield return new WaitForFixedUpdate();
        if (currentRate<maxRate){
            smoke.emissionRate+=rateDelta;
            currentRate=smoke.emissionRate;
            StartCoroutine("RateUp");
        }
    }

        

}
