using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

	public Transform player;
	private Vector3 cameraOffset;
	public float RotSpeed=5.0f;
	public float zOffset=-2.5f;
	public float yOffset=1.5f;

	void Start () {
		cameraOffset=new Vector3(player.position.x, player.position.y+yOffset, player.position.z+zOffset);
		Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
	}
	
	void LateUpdate () {
		cameraOffset=Quaternion.AngleAxis(Input.GetAxis("Mouse X")*RotSpeed, Vector3.up)*cameraOffset;
		cameraOffset=Quaternion.AngleAxis(Input.GetAxis("Mouse Y")*RotSpeed, Vector3.right)*cameraOffset;
		transform.position=player.position+cameraOffset;
		transform.LookAt(player.position);
	}
	
}
