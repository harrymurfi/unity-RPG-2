using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Transform tgt;
	bool visibility = true;

	void Start()
	{
		
	}

	void Update()
	{
		transform.position = Camera.main.WorldToScreenPoint(tgt.transform.position);
		if(Input.GetKeyDown(KeyCode.Space))
		{
			visibility = !visibility;
			GetComponent<Image>().enabled = visibility;
		}
	}
}
