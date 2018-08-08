using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MessageSystem : MonoBehaviour
{
	Canvas canvas;
	public GameObject messageGUI;
	Text messageText;

	void Start()
	{
		canvas = FindObjectOfType<Canvas>();
		messageText = messageGUI.GetComponent<Text>();
	}

	void Update()
	{
		
	}

	void SetMessage()
	{
		
	}
}
