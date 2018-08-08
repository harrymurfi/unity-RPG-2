using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
	public enum UIState {Play, Pause, InventoryUp, SkillUp, QuestUp};
	public UIState currentState;

	public static UIController Instance { get; private set;}

	public GameObject mainMenu;
	public GameObject quitMenu;
	public GameObject mainHUD;
	public GameObject inventoryMenu;
	public GameObject skillMenu;
	public GameObject questMenu;
	public GameObject normalDialog;
	public GameObject optionDialog;

	public Texture2D[] cursorSet;

	BlurOptimized blurEffect;

	void Awake()
	{
		if(Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	void Start()
	{
		blurEffect = Camera.main.GetComponent<BlurOptimized>();
		ChangeCursor(0);
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.LeftControl))
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				ChangeState(UIState.InventoryUp);
			}
			else if(Input.GetKeyDown(KeyCode.Q))
			{
				ChangeState(UIState.QuestUp);
			}
			else if(Input.GetKeyDown(KeyCode.G))
			{
				ChangeState(UIState.SkillUp);
			}
		}
		else if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(currentState == UIState.Play) ChangeState(UIState.Pause);
			else ChangeState(UIState.Play);
		}
	}

	void ChangeState(UIState state)
	{
		currentState = state;
		switch(state)
		{
		case UIState.Play:
			{
				mainMenu.SetActive(false);
				quitMenu.SetActive(false);
				inventoryMenu.SetActive(false);
				skillMenu.SetActive(false);
				questMenu.SetActive(false);

				mainHUD.SetActive(true);
				blurEffect.enabled = false;
				Time.timeScale = 1;
				break;
			}
		case UIState.Pause:
			{
				mainHUD.SetActive(false);
				inventoryMenu.SetActive(false);
				skillMenu.SetActive(false);
				questMenu.SetActive(false);

				mainMenu.SetActive(true);
				blurEffect.enabled = true;
				Time.timeScale = 0;
				break;
			}
		case UIState.InventoryUp:
			{
				if(inventoryMenu.activeSelf)
					inventoryMenu.SetActive(false);
				else
				{
					mainMenu.SetActive(false);
					inventoryMenu.SetActive(true);
					skillMenu.SetActive(false);
					questMenu.SetActive(false);
				}

				break;
			}
		case UIState.SkillUp:
			{
				if(skillMenu.activeSelf)
					skillMenu.SetActive(false);
				else
				{
					mainMenu.SetActive(false);
					inventoryMenu.SetActive(false);
					skillMenu.SetActive(true);
					questMenu.SetActive(false);
				}

				break;
			}
		case UIState.QuestUp:
			{
				if(questMenu.activeSelf)
					questMenu.SetActive(false);
				else
				{
					mainMenu.SetActive(false);
					inventoryMenu.SetActive(false);
					skillMenu.SetActive(false);
					questMenu.SetActive(true);
				}

				break;
			}
		}
	}

	public void ChangeCursor(int state)
	{
		Cursor.SetCursor(cursorSet[state], Vector2.zero, CursorMode.Auto);
	}

	public void ShowQuit()
	{
		mainMenu.SetActive(false);
		quitMenu.SetActive(true);
	}

	public void ResumePlay()
	{
		ChangeState(UIState.Play);
	}
}
