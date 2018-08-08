using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogController : MonoBehaviour
{
	Dialog currentDialog;
	int max;
	int step;

	public Text nameText;
	public Text contentText;
	public Text nextButtonText;

	public void StartDialog(NPC npc)
	{
		currentDialog = npc.dialog;
		max = currentDialog.dialogs.Length;
		nameText.text = npc.npcName;
		SetContent(0);
		step++;
		nextButtonText.text = "Next";
	}

	public void NextDialog()
	{
		if(step == max)
		{
			CloseDialogPanel();
			return;
		}
		if(step == max - 1)
		{
			nextButtonText.text = "Done";
		}
		if(step < max)
		{
			SetContent(step);
		}
		step++;
	}

	public void SetContent(int index)
	{
		contentText.text = currentDialog.dialogs[index];
	}

	public void CloseDialogPanel()
	{
		step = 0;
		gameObject.SetActive(false);
	}

}
