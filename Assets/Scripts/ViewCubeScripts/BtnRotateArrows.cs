using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnRotateArrows : MonoBehaviour
{
	public GameObject MainCamera;
	public Vector3 localRotation;
	public Vector3 localTransofrm;

	private float rotationSensitivity = 1.00f;
	private float translationSensitivity = 0.50f;

	private bool held;

	public void Update()
	{
		if (held)
		{
			MainCamera.GetComponent<MainCameraOrbit>()._LocalRotation += localRotation * rotationSensitivity;
			MainCamera.GetComponent<MainCameraOrbit>()._LocalTransform += localTransofrm * translationSensitivity;
		}
	}

	public void btnDown()
	{
		held = true;
	}

	public void btnUp()
	{
		held = false;
	}
}
