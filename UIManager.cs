using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
	public UIManager Instance {get; private set;}

	Camera mainCamera;

	public GameObject mainMenu;
	public GameObject loadMenu;
	public GameObject optionsMenu;
	public GameObject quitAppMenu;

	public GameObject gameplayUI;
	public GameObject mainUI;

	public GameObject dialogPanel;
	public Text dialogOwner;
	public Text dialogText;

	private Vector3 interactBtnOffset = new Vector3(0,2.75f,0);
	private BlurOptimized blur;
	private bool isPaused;

	public Texture2D cursorNormal;
	public Texture2D cursorSpeak;
	public Texture2D cursorAttack;

	public DialogController dialogController;

	void Awake()
	{
		if(Instance == null) Instance = this;
		else Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		ChangeCursor(1);
		mainCamera = FindObjectOfType<Camera>();
		blur = Camera.main.GetComponent<BlurOptimized>();
		blur.enabled = false;
		if(SceneManager.GetActiveScene().buildIndex == 0)
			ShowMainMenu();
		else
			ShowGameplay();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)) ShowPausedMenu();
	}

	public void ShowMainMenu()
	{
		mainMenu.SetActive(true);
		quitAppMenu.SetActive(false);
		gameplayUI.SetActive(false);
		mainUI.SetActive(false);
	}

	public void ShowLoadMenu()
	{
		
	}

	public void ShowOptionsMenu()
	{
		
	}

	public void ShowQuitAppMenu()
	{
		mainMenu.SetActive(false);
		quitAppMenu.SetActive(true);
	}

	public void ShowGameplay()
	{
		gameplayUI.SetActive(true);
		mainUI.SetActive(true);
		mainMenu.SetActive(false);
		quitAppMenu.SetActive(false);
	}

	public void ShowPausedMenu()
	{
		isPaused = !isPaused;
		if(isPaused)
		{
			blur.enabled = true;
			Time.timeScale = 0;
		}
		else
		{
			blur.enabled = false;
			Time.timeScale = 1;
		}
	}

	void OnLevelWasLoaded(int i)
	{
		if(i == 0) ShowMainMenu();
		else ShowGameplay();
		blur = FindObjectOfType<Camera>().GetComponent<BlurOptimized>();
		blur.enabled = false;
	}

	public void OpenDialog(NPC npc)
	{
		dialogPanel.SetActive(true);
		dialogController.StartDialog(npc);
	}

	public void ChangeCursor(int state)
	{
		switch(state)
		{
		case 1: Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto); break;
		case 2: Cursor.SetCursor(cursorSpeak, Vector2.zero, CursorMode.Auto); break;
		case 3: Cursor.SetCursor(cursorAttack, Vector2.zero, CursorMode.Auto); break;
		}
	}

	public void ClosePanel(GameObject panel)
	{
		panel.SetActive(false);
	}
}
