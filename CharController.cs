using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
	public Camera cam;
	Transform camPoint;
	public float moveSpeed = 2;
	public float rotateSpeed = 120;

	Vector3 offset = new Vector3(0, 3, -5);


	void Start()
	{
		//camPoint = GameObject.Find("Camera Point").transform;
	}

	void Update()
	{
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		transform.Translate(x, 0, z, camPoint);
	}

	float rtime = 1;
	void LateUpdate()
	{
//		if(rtime >= 1)
//		{
//			if(Input.GetKeyDown(KeyCode.E))
//			{
//				rtime = 0;
//				camPoint.Rotate(0, 45.0f, 0);
//			}
//			else if(Input.GetKeyDown(KeyCode.Q))
//			{
//				rtime = 0;
//				camPoint.Rotate(0, -45.0f, 0);
//			}
//		}
//		rtime += Time.deltaTime;
	}
}
