using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
public class Temp : MonoBehaviour
{

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			{
				print(hit.point);
				StopAllCoroutines();
				StartCoroutine(Test(hit.point));
			}
		}

	}

	IEnumerator Test(Vector3 dest)
	{
		print("go");
		while(Vector3.Distance(transform.position, dest) > 0.1f)
		{
			transform.position = Vector3.Lerp(transform.position, dest, 2 * Time.deltaTime);
			yield return null;
		}
		print("done!");
	}
}
