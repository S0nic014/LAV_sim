using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBehaviour : MonoBehaviour
{
    private float fMaxTime=5.0f;
	void Start () {
		Destroy(gameObject,fMaxTime);
	}
}

  
