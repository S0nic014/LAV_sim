using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SuspensionInfo {
    public Transform spring;
    public Transform target;
    public Transform baseObj;
    private float idleDistance;
    private float distance;
    private float deltaScale;

    public float Idle
    {
        get{return idleDistance;}
        set{idleDistance=value;}
    }

    public float Distance
    {
        get{return distance;}
        set{distance=value;}
    }

    public float DeltaScale
    {
        get{return deltaScale;}
        set{deltaScale=value;}
    }

}


public class Suspension : MonoBehaviour
{
    public List<SuspensionInfo> suspensionInfos; 


    private void Start() {
        foreach(SuspensionInfo element in suspensionInfos){
            element.Idle=Vector3.Distance(element.target.position, element.baseObj.position);
            element.Distance=element.Idle;
        }
    }

    private void FixedUpdate() {
        foreach (SuspensionInfo element in suspensionInfos)
        {
            updateSpring(element);
        }
    }

    public void updateSpring(SuspensionInfo element){

        element.Distance=Vector3.Distance(element.target.position, element.baseObj.position);
        element.DeltaScale=element.Distance/element.Idle;
        Vector3 newScale=new Vector3(1f, element.DeltaScale, 1f);
        element.spring.localScale=newScale;
    }
    

}







//OLD 
/*
public class Suspension : MonoBehaviour
{
    public Transform spring;
    public Transform target;
    public Transform baseObj;
    public float idleDistance;
    public float distance;

    private void Start() {
        idleDistance=Vector3.Distance(target.position, baseObj.position);
        distance=idleDistance;
    }

    void Update()
    {   
        distance=Vector3.Distance(target.position, baseObj.position);
        float deltaScale=distance/idleDistance;
        Vector3 newScale= new Vector3(1f, deltaScale, 1f);
        spring.localScale=newScale;
    }
}
*/