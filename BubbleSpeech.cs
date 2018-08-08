using UnityEngine;
using UnityEngine.UI;

public class BubbleSpeech : MonoBehaviour
{
	public DialogManagerTest dialogManager;

	// dialogs
	public string[] dialogs;

	void Start()
	{
		if(dialogManager == null) FindObjectOfType<DialogManagerTest>();
	}

	void OnMouseDown()
	{
		
	}
}
