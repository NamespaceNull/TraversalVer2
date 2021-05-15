using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour {

	public Transform target; 
	public float smoothSpeed = 0.125f;
	public Vector3 offset;
	bool on = true;

	void LateUpdate() 
	{
		if (on)
		{ 
			Vector3 desiredPosition = target.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			transform.position = smoothedPosition;
		}
	}
}
