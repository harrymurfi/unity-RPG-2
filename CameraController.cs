using UnityEngine;

public class CameraController : MonoBehaviour
{
	Transform cam;
	PlayerKnight player;
	bool dockingOnNPC = false;

	void Start()
	{
		cam = Camera.main.transform;
		cam.Translate(new Vector3(0,9,-8) - cam.position);
		cam.Rotate(new Vector3(50,0,0));
		cam.SetParent(this.transform);
		player = FindObjectOfType<PlayerKnight>();
	}

	void LateUpdate()
	{
		if(player)
		{
			if(!dockingOnNPC)
			{
				transform.position = player.transform.position;
				if(Input.GetMouseButton(1))
				{
					transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * 360 * Time.deltaTime);
				}
			}
			else
			{
				if(Input.GetKeyDown(KeyCode.Escape))
				{
					Undocking();
				}
			}
		}
	}

	public void Docking(Transform point)
	{
		dockingOnNPC = true;
		cam.position = point.position;
		cam.rotation = point.rotation;
	}

	public void Undocking()
	{
		print("undocking");
		dockingOnNPC = false;
	}
}
