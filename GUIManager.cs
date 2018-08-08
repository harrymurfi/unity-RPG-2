using UnityEngine;

public class GUIManager : MonoBehaviour
{
	Canvas canvas;
	enum UIState {Normal, Paused, Inventory, Quest};

	public GameObject playerStatus;
	//bool playerStatusActive = true;

	public GameObject pausedMenu;
	//bool pausedMenuActive = false;

	public GameObject inventoryMenu;
	//bool inventoryMenuActive = false;

	public GameObject questMenu;
	//bool questMenuActive = false;

	UIState state = UIState.Normal;

	void Start()
	{
		canvas = FindObjectOfType<Canvas>();
		playerStatus.SetActive(true);
		pausedMenu.SetActive(false);
		inventoryMenu.SetActive(false);
		questMenu.SetActive(false);
	}

	void Update()
	{
		if(state == UIState.Normal)
		{
			if(Input.GetKeyDown(KeyCode.Escape)) ShowPausedMenu();
			if(Input.GetKeyDown(KeyCode.E)) ShowInventoryMenu();
			if(Input.GetKeyDown(KeyCode.V)) ShowQuestMenu();
		}
		else if(state == UIState.Paused)
		{
			if(Input.GetKeyDown(KeyCode.Escape)) ShowNormalState();
		}
		else if(state == UIState.Inventory)
		{
			if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E)) ShowNormalState();
		}
		else if(state == UIState.Quest)
		{
			if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.V)) ShowNormalState();
		}
	}

	void ShowNormalState()
	{
		state = UIState.Normal;
		playerStatus.SetActive(true);
		pausedMenu.SetActive(false);
		inventoryMenu.SetActive(false);
		questMenu.SetActive(false);
		Time.timeScale = 1;
	}

	void ShowPausedMenu()
	{
		state = UIState.Paused;
		playerStatus.SetActive(false);
		pausedMenu.SetActive(true);
		Time.timeScale = 0;
	}

	void ShowInventoryMenu()
	{
		state = UIState.Inventory;
		playerStatus.SetActive(false);
		inventoryMenu.SetActive(true);
		Time.timeScale = 0;
	}

	void ShowQuestMenu()
	{
		state = UIState.Quest;
		playerStatus.SetActive(false);
		questMenu.SetActive(true);
		Time.timeScale = 0;
	}
}
