using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
	public GameObject contentPlaceholder;
	public GameObject listPrefab;
	public Text summaryText;

	public int height = -25;

	QuestManager questManager;

	void Start()
	{
		questManager = FindObjectOfType<QuestManager>();
		int i = 0;
		foreach(string val in questManager.questList.Values)
		{
			GameObject obj = Instantiate(listPrefab) as GameObject;
			obj.transform.SetParent(contentPlaceholder.transform, false);
			RectTransform objRect = obj.GetComponent<RectTransform>();
			objRect.anchoredPosition = new Vector2(0, i * height);
			Text t = obj.GetComponentInChildren<Text>();
			t.text = val;
			i++;
		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			AddQuest();
		}
	}

	public void AddQuest()
	{
		GameObject obj = Instantiate(listPrefab) as GameObject;
		obj.transform.SetParent(contentPlaceholder.transform, false);
		RectTransform objRect = obj.GetComponent<RectTransform>();
		objRect.anchoredPosition = new Vector2(0, height);
	}

	public void OnClickList()
	{
		
	}
}
