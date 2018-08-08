using UnityEngine;

public class CustomButton : MonoBehaviour
{
	public void ClosePanel()
	{
		transform.parent.gameObject.SetActive(false);
	}
}
