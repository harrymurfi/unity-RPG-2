using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestTest : MonoBehaviour
{
	public int id;
	public string title;
	public int steps;
	public int currentStep;
	public string[] summary;

	static QuestManagerTest QM;

	void Start()
	{
		if(QM == null) QM = FindObjectOfType<QuestManagerTest>();
	}

	public void Initialize()
	{

	}

	public void NextStep()
	{

	}
}
