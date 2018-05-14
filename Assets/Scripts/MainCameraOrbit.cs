using UnityEngine;
using System.Collections;
using System;

public class MainCameraOrbit : MonoBehaviour
{
	protected Transform _XForm_Camera;
	protected Transform _XForm_Parent;

	public Vector3 _LocalRotation;
	public Vector3 _LocalTransform;
	public Vector3 _CameraPosition;

	private float MouseSensitivity = 4f;
	private float ScrollSensitvity = 2f;
	private float OrbitDampening = 10f;
	private float ScrollDampening = 6f;

	public bool AutoRotate;
	public float ScrollAmount;

	// Use this for initialization
	void Start()
	{
		this._XForm_Camera = this.transform;
		this._XForm_Parent = this.transform.parent;

		this._LocalRotation = new Vector3(this.transform.parent.localRotation.eulerAngles.y, this.transform.parent.localRotation.eulerAngles.x, 0f);
		this._LocalTransform = this.transform.localPosition;
		this._CameraPosition = this.transform.localPosition;
	}

	void LateUpdate()
	{
		// Rotation: Autorotate from Button
		if (AutoRotate)
		{
			_LocalRotation.x += (-1) * 0.15f * ScrollSensitvity;
		}

		// Rotation: Rotation of the Camera based on Mouse Coordinates
		if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKey(KeyCode.Mouse2))
		{
			if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
			{
				_LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
				_LocalRotation.y += Input.GetAxis("Mouse Y") * MouseSensitivity * (-1);
			}
		}

		// Rotation: Clamp the y Rotation to horizon and not flipping over at the top
		if (_LocalRotation.y < 0f)
			_LocalRotation.y = 0f;
		else if (_LocalRotation.y > 90f)
			_LocalRotation.y = 90f;

		// Translation: Moving camera by holding middle mouse button (wheel)
		if ((!(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) && Input.GetKey(KeyCode.Mouse2))
		{
			if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
			{
				_LocalTransform.x -= Input.GetAxis("Mouse X") * MouseSensitivity / 4f;
				_LocalTransform.y -= Input.GetAxis("Mouse Y") * MouseSensitivity / 4f;
			}
		}

		// Translation: Finally
		_CameraPosition += _LocalTransform;
		_LocalTransform = new Vector3();

		// Zooming: Zooming Input from our Mouse Scroll Wheel
		if (Input.GetAxis("Mouse ScrollWheel") != 0f)
		{
			ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;
		}

		// Zooming: Scroll amount Finally
		ScrollAmount *= (this._CameraPosition.z * 0.5f);
		this._CameraPosition.z -= ScrollAmount;
		ScrollAmount = 0;

		// Finally: Actual Camera Rig Transformations
		Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
		this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);

		if (this._XForm_Camera.localPosition != this._CameraPosition)
		{
			this._XForm_Camera.localPosition =
				new Vector3(
					Mathf.Lerp(this._XForm_Camera.localPosition.x, this._CameraPosition.x, Time.deltaTime * ScrollDampening * 2f),
					Mathf.Lerp(this._XForm_Camera.localPosition.y, this._CameraPosition.y, Time.deltaTime * ScrollDampening * 2f),
					Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraPosition.z, Time.deltaTime * ScrollDampening
					));
		}
	}
}