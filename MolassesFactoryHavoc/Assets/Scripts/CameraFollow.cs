using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform targetEntity;
	public Vector3 targetOffset;
	public float slerpValue = 3f;

	void Update()
	{
		Vector3 slerpOffset = Vector3.Slerp(transform.position, targetEntity.position + targetOffset, slerpValue * Time.deltaTime);
		transform.position = new Vector3(slerpOffset.x,slerpOffset.y,targetOffset.z);
	}
}