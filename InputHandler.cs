using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
	public event Action OnRightClick;
	public event Action OnLeftClick;

	void Update()
	{
		//if(Input.GetMouseButtonDown(1)) OnRightClick();
		if(Input.GetMouseButtonDown(0)) OnLeftClick();
	}
}
