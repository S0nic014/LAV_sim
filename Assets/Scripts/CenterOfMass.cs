using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 com;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.centerOfMass=com;   
    }

}
