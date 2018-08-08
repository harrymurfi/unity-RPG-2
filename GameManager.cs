using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	enum GameState {OnMainMenu, OnPlay, OnPause, OnCutScene};

	public static GameManager Instance {get; private set;}

	private Canvas mainCanvas;
	private GameState gameState = GameState.OnMainMenu;

	void Awake()
	{
		if(Instance == null) Instance = this;
		else Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		mainCanvas  = FindObjectOfType<Canvas>();
	}

	public void PlayGame()
	{
		gameState = GameState.OnPlay;
		SceneManager.LoadScene(2);
	}

	public void QuitApp()
	{
		Application.Quit();
	}
}
