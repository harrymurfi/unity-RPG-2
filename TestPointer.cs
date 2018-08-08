using UnityEngine;
using UnityEngine.EventSystems;

public class TestPointer : MonoBehaviour, IPointerClickHandler
{
	public Texture2D tex;
	bool hasFocus;

	void OnMouseEnter()
	{
		print("enter");
		Cursor.SetCursor(tex, Vector2.zero, CursorMode.Auto);
	}

	void OnMouseExit()
	{
		Debug.Log("exit");
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}

	#region IPointerClickHandler implementation

	void IPointerClickHandler.OnPointerClick (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion
}
