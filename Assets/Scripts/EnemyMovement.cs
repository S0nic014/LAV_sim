using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyMovement : MonoBehaviour
{
    public Path enemyPath;
    private int currentNode=0;
    public float maxSteerAngle=30;
    public float maxTorque=200f;
    public float maxBrakingTorque=230f;
    public float maxSpeed=20f;
    public float currentSpeed;
    public bool isBraking=false;
    public bool Debugging=false;
    public WheelCollider[] steerWheels;
    public WheelCollider[] torqueWheels;

    private void FixedUpdate() {
        ApplySteer();
        Drive();
        CheckWaypointDistance();
        Braking();
        
        if (Debugging)
        {
            Debug.Log(string.Format("{0}'s next waypoint {1}, Speed: {2}", transform.name, currentNode, currentSpeed));
        }
    }

    void ApplySteer()
    {
        Vector3 relativeVector=transform.InverseTransformPoint(enemyPath.nodes[currentNode].position);
        float newSteer=(relativeVector.x/=relativeVector.magnitude)*maxSteerAngle;
        foreach (WheelCollider wheel in steerWheels)
        {
            wheel.steerAngle=newSteer;
        }
    }

    void Drive()
    {
        currentSpeed=2*Mathf.PI*torqueWheels[0].radius*torqueWheels[0].rpm*60/1000;

        if (currentSpeed<maxSpeed && !isBraking)
        {
            foreach (WheelCollider wheel in torqueWheels)
            {
                wheel.motorTorque=maxTorque;
            }
        } else
        {
            foreach (WheelCollider wheel in torqueWheels)
            {
                wheel.motorTorque=0;
            }
            Braking();
        }


    }

    void CheckWaypointDistance()
    {
        
        
        if (Vector3.Distance(transform.position, enemyPath.nodes[currentNode].position)<1f)
        {
            if (currentNode==enemyPath.nodes.Count-1)
            {
                currentNode=0;
            } else
            {
                currentNode++;
            }
        }
    }

    void Braking()
    {
        if (isBraking)
        {
            foreach (WheelCollider wheel in torqueWheels)
            {
                wheel.brakeTorque=maxBrakingTorque;
            }
        } else
        {
            foreach (WheelCollider wheel in torqueWheels)
            {
                wheel.brakeTorque=0;
            }
        }
    }

}
