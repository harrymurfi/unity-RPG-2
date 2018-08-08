using UnityEngine;

public class GroundController : MonoBehaviour
{
	public Texture2D groundPointerTex;

	void OnMouseEnter()
	{
		Cursor.SetCursor(groundPointerTex, Vector2.zero, CursorMode.Auto);
	}

	void OnMouseExit()
	{
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
}
