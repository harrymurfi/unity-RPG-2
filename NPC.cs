using UnityEngine;

public class NPC : MonoBehaviour
{
	public string npcName;
	public Dialog dialog;

	void Start()
	{
		this.dialog = GetComponent<Dialog>();
	}

	void OnMouseEnter()
	{
		UIController.Instance.ChangeCursor(1);
	}

	void OnMouseExit()
	{
		UIController.Instance.ChangeCursor(0);
	}

	void OnMouseDown()
	{
		
	}
}
