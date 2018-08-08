using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Dialog : MonoBehaviour
{
	// dialog rules: [0]normal [1]close [2]option

	public byte id;
	public DialogManagerTest dialogManager;

	// dialogs
	public string[] dialogs;

	void Start()
	{
		FindObjectOfType<DialogManagerTest>();
	}

	void OnMouseDown()
	{
		dialogManager.InitiateDialog(this);
	}
}
