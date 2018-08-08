using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
	public RectTransform healthBar;
	public RectTransform mpBar;
	public Text healthText;
	public Text mpText;
	public int maxHealth = 1000;
	public int maxMP = 100;

	int health;
	int mp;

	public int Health
	{
		get { return health; }
		set {
			health = value;
			if(health < 0) health = 0;
			else if(health > maxHealth) health = maxHealth;

			healthBar.localScale = new Vector3((float)health/maxHealth, 1, 1);
			healthText.text = health.ToString() + "/" + maxHealth.ToString();
		}
	}

	public int MP
	{
		get { return mp; }
		set {
			mp = value;
			if(mp < 0) mp = 0;
			else if(mp > maxMP) mp = maxMP;

			mpBar.localScale = new Vector3((float) mp/maxMP, 1, 1);
			mpText.text = mp.ToString() + "/" + maxMP.ToString();
		}
	}

	void Start()
	{
		Health = maxHealth;
		MP = maxMP;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow)) Health -= 100;
		else if(Input.GetKeyDown(KeyCode.RightArrow)) Health += 100;
	}
}
