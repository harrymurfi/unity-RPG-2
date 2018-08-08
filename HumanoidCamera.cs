using UnityEngine;

public class HumanoidCamera : MonoBehaviour
{
	public Transform target;
	public float mouseSensitivity = 10;
	public float distance = 2;
	public float rotationSmoothTime = 0.3f;

	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;
	Vector2 degreeMinMax = new Vector2(10, 30);

	float yaw, pitch;

	void LateUpdate()
	{
		yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
		pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		pitch = Mathf.Clamp (pitch, degreeMinMax.x, degreeMinMax.y);

		currentRotation = Vector3.SmoothDamp (currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
		transform.eulerAngles = currentRotation;
		transform.position = target.position;
	}
}
