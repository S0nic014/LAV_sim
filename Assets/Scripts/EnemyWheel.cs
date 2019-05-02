using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWheel : MonoBehaviour
{
    public WheelCollider[] targetWheels;
    public GameObject[] wheelMeshes;
    private Vector3 wheelPosition = new Vector3();
    private Quaternion wheelRotation= new Quaternion(); 


    void Update()
    {
        for(int wheelIndex=0; wheelIndex<targetWheels.Length; wheelIndex++)
        {
            targetWheels[wheelIndex].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelMeshes[wheelIndex].transform.position=wheelPosition;
            wheelMeshes[wheelIndex].transform.rotation=wheelRotation;
        }
    }
}
