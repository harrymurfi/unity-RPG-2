using UnityEngine;

public class Item : MonoBehaviour
{
	public int ID;
	public string Name;
	public int Qty;

	void Update()
	{
		transform.Rotate(Vector3.up * 90 * Time.deltaTime);
	}
}
