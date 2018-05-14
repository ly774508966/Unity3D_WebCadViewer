using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnRotate : MonoBehaviour
{
	public bool Checked;

	public GameObject MainCamera;

	public GameObject ImageObject;
	public Sprite CheckedFalseSprite;
	public Sprite CheckedTrueSprite;

	// Use this for initialization
	void Start()
	{
		ImageObject.GetComponent<Image>().sprite = CheckedFalseSprite;
	}

	// Update is called once per frame
	void Update()
	{
		if (Checked)
		{
			ImageObject.GetComponent<Image>().sprite = CheckedTrueSprite;
		}
		else
		{
			ImageObject.GetComponent<Image>().sprite = CheckedFalseSprite;
		}

		MainCamera.GetComponent<MainCameraOrbit>().AutoRotate = Checked;
	}

	public void ChangeChecked()
	{
		this.Checked = !Checked;
	}
}
