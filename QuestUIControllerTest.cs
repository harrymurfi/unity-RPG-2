using UnityEngine;
using UnityEngine.UI;

public class QuestUIControllerTest : MonoBehaviour
{
	public GameObject contentPanel;
	public GameObject descPanel;
	public GameObject QuestPrefab;

	private static int posY = -30;

	public RectTransform butt;

	public void AddQuest()
	{
		GameObject q = Instantiate(QuestPrefab) as GameObject;
		q.transform.SetParent(contentPanel.transform, false);
		RectTransform rt = q.GetComponent<RectTransform>();

	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.A)) AddQuest();

		if(Input.GetKeyDown(KeyCode.P))
		{
			print(butt.anchoredPosition);
		}
	}
}
