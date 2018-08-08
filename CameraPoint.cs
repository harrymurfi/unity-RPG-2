using UnityEngine;

public class CameraPoint : MonoBehaviour
{
	Transform cam;
	public Player player;
	bool dockingOnNPC = false;

	void Start()
	{
		cam = Camera.main.transform;
		cam.Translate(new Vector3(0,7,-7) - cam.position);
		cam.Rotate(new Vector3(45,0,0));
		cam.SetParent(this.transform);
		player = FindObjectOfType<Player>();
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
