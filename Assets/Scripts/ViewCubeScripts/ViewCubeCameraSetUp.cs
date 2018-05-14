using UnityEngine;

public class ViewCubeCameraSetUp : MonoBehaviour
{
	public Vector3 viewDirection;

	public GameObject MainCamera;

	private MainCameraOrbit mainCamera;

	private void Start()
	{
		this.mainCamera = MainCamera.GetComponent<MainCameraOrbit>();
	}

	private void OnMouseDown()
	{
		mainCamera._LocalRotation = viewDirection;
	}

	private void OnMouseOver()
	{
		gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
	}

	private void OnMouseExit()
	{
		gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
	}
}