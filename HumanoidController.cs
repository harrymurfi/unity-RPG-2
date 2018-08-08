using UnityEngine;

public class HumanoidController : MonoBehaviour
{
	public float walkSpeed = 2;
	public float runSpeed = 5;
	public float gravity = -12;
	public float jumpHeight = 2;
	[Range(0, 1)] 
	public float airControlPercent;

	public float turnSmoothTime = .2f;
	float turnSmoothVelocity;
	public float speedSmoothTime = .1f;
	float speedSmoothVelocity;
	float currentSpeed;
	float velocityY;

	Transform cameraTransform;
	CharacterController controller;

	void Start()
	{
		cameraTransform = Camera.main.transform;
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		Vector2 direction = input.normalized;

		if(direction != Vector2.zero)
		{
			float targetRotation = Mathf.Atan2 (direction.x, direction.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle (transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime (turnSmoothTime));
		}
	}

	float GetModifiedSmoothTime(float smoothTime) {
		if (controller.isGrounded) {
			return smoothTime;
		}

		if (airControlPercent == 0) {
			return float.MaxValue;
		}

		return smoothTime / airControlPercent;
	}
}
