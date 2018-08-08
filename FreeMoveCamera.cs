using UnityEngine;

public class FreeMoveCamera : MonoBehaviour
{
	public float speed = 5;
	public float degree = 120;
	float mult = 1;
	void Update()
	{
		if(Input.GetKey(KeyCode.LeftShift))
			mult = 3;
		else
			mult = 1;

		if(Input.GetMouseButton(1))
		{
			Vector3 rot = new Vector3(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0) * degree * mult * Time.deltaTime;
			transform.Rotate(rot, Space.World);
		}

		Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * mult * Time.deltaTime;
		transform.Translate(dir);
	}
}
