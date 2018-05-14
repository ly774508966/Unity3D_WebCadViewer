using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnZoomInOut : MonoBehaviour
{
	public GameObject MainCamera;
	public float ZoomAmount;

	private float ZoomSensitivity = 0.10f;
	private bool held;

	public void Update()
	{
		if (held)
			MainCamera.GetComponent<MainCameraOrbit>().ScrollAmount += ZoomAmount * ZoomSensitivity;
	}

	public void ZoomDown()
	{
		held = true;
	}

	public void ZoomUp()
	{
		held = false;
	}
}
