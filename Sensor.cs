using UnityEngine;

public class Sensor : MonoBehaviour
{
	Unit04 ai;

	void Start()
	{
		ai = GetComponentInParent<Unit04>();
	}

	void OnTriggerEnter(Collider other)
	{
	//print("Found player");
		ai.seeTarget = true;
		ai.currentTarget = other.transform;
	}

	void OnTriggerExit(Collider other)
	{
		//print("Lost player");
		ai.seeTarget = false;
		if(ai.currentTarget == other.transform)
			ai.currentTarget = null;
	}
}
