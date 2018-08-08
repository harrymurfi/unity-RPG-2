using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogManagerTest : MonoBehaviour
{
	// normal dialog
	public GameObject normalPanel;
	public RectTransform normalRect;
	public Text normalText;
	public Button normalButton;
	public Text normalButtonText;

	// option dialog
	public GameObject optionPanel;

	public string[] dialogs;
	public int counter;

	Transform player, npc;

	void Start()
	{
		normalPanel.SetActive(false);
		optionPanel.SetActive(false);
	}

	public void InitiateDialog(Dialog dialog)
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		npc = dialog.transform;
		this.dialogs = dialog.dialogs;
		counter = 0;
		NextDialog();
	}

	void NextDialog()
	{
		DecodeDialog(dialogs[counter], counter);
		counter++;
	}

	void CloseDialog()
	{
		normalPanel.SetActive(false);
		optionPanel.SetActive(false);
	}

	void DecodeDialog(string line, int counter)
	{
		switch(line[1])
		{
		// normal dialog
		case '0':
			{
				normalPanel.SetActive(true);
				optionPanel.SetActive(false);
				normalPanel.transform.position = Camera.main.WorldToScreenPoint(npc.position);
				normalText.text = dialogs[counter].Substring(3);
				if(counter < dialogs.Length - 1)
				{
					normalButtonText.text = "Next";
					normalButton.onClick.RemoveAllListeners();
					normalButton.onClick.AddListener(NextDialog);
				}
				else
				{
					normalButtonText.text = "Close";
					normalButton.onClick.RemoveAllListeners();
					normalButton.onClick.AddListener(CloseDialog);
				}
			}
			break;
		// option dialog
		case '1': 
			{
				optionPanel.SetActive(true);
				normalPanel.SetActive(false);
				optionPanel.transform.position = Camera.main.WorldToScreenPoint(npc.position);

			}
			break;
		}
	}
}
