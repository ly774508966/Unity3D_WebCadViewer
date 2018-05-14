using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCubeRotation : MonoBehaviour
{
	protected Transform CubeTransform;
	protected Transform CameraTransform;
	protected Transform PivotTransform;

	public Transform MainCamera;

	// Use this for initialization
	void Start()
	{
		CubeTransform = this.transform;
		CameraTransform = this.MainCamera.transform;
		PivotTransform = this.MainCamera.parent.transform;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		CubeTransform.localRotation = Quaternion.Inverse(PivotTransform.localRotation);
	}
}
