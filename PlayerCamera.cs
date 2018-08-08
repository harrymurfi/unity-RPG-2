using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	Transform player;
	public Vector3 position;
	public Vector3 rotation;
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void LateUpdate()
	{
		TrackPlayer();
	}

	void TrackPlayer()
	{
		transform.position = Vector3.Lerp(transform.position, player.position + position, 0.2f);
		transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, 0.2f);
	}
}
