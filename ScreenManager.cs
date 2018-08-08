using UnityEngine;

public class ScreenManager : MonoBehaviour
{
	Animator anim;
	bool showed;

	void Start()
	{
		anim = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			showed = !showed;
			anim.SetBool("open", showed);
		}
	}
}
