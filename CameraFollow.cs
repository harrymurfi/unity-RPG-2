using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	GameObject player;
	public Vector3 offset = new Vector3(0, 5, -5);
	public float sensitivity = 0.5f;

	void Start()
	{
		player = GameObject.Find("Player");
	}

	void LateUpdate()
	{
		transform.position = player.transform.position + offset;
		if(Input.GetMouseButton(1))
		{
			//transform.Rotate(Vector3.up * 10 * Input.GetAxisRaw("Mouse X"));
			//transform.local = Quaternion.Euler(Vector3.up * 10 * Input.GetAxisRaw("Mouse X"));
			transform.RotateAround(player.transform.position, Vector3.up, 120 * Time.deltaTime);
		}
	}
}
