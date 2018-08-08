using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour
{
	public event Action OnDied;
	public event Action OnKills;

	// fields
	public Texture2D atkCursor;
	public string unitName;
	public int health;
	public UnitState currentState = UnitState.Idle;
	public bool seeTarget;
	public bool targetInRange;
	public Transform target;

	static Player player;
	Animator animator;
	NavMeshAgent agent;
	float idleTimer;
	float atkCooldown = 0.75f;
	float atkTimer;
	public Vector3 patrolDest;

	// properties
	public int Health
	{
		get { return health; }
		set 
		{
			health = value;
			if(health <= 0)
			{
				health = 0;
				DieState();
			}
		}
	}

	void Start()
	{
		if(player == null)
			player = FindObjectOfType<Player>();
		animator = GetComponentInChildren<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		switch(currentState)
		{
		case UnitState.Idle: IdleState(); break;
		case UnitState.Patrol: PatrolState(); break;
		case UnitState.Engage: EngageState(); break;
		case UnitState.Attack: AttackState(); break;
		case UnitState.Die: DieState(); break;
		}
	}

	// Main State
	void ToIdleState()
	{
		agent.ResetPath();
		animator.SetBool("Walk", false);
		idleTimer = Time.time + 3;
		currentState = UnitState.Idle;
	}

	void IdleState()
	{
		if(seeTarget)
			ToEngageState();
		if(Time.time > idleTimer)
			ToPatrolState();
	}

	void ToPatrolState()
	{
		animator.SetBool("Walk", true);
		patrolDest = UnityEngine.Random.insideUnitCircle * 12;
		agent.SetDestination(patrolDest);
		currentState = UnitState.Patrol;
	}

	void PatrolState()
	{
		if(seeTarget)
			ToEngageState();
		if(!agent.hasPath)
			ToIdleState();
	}

	void ToEngageState()
	{
		animator.SetBool("Walk", true);
		currentState = UnitState.Engage;
	}

	void EngageState()
	{
		if(target == null) ToIdleState();
			
		if(seeTarget)
		{
			if(targetInRange)
			{
				ToAttackState();
			}
			else
			{
				agent.SetDestination(target.position);
			}
		}
		else
		{
			ToIdleState();
		}
	}

	void ToAttackState()
	{
		animator.SetBool("Walk", false);
		agent.ResetPath();
		atkTimer = Time.time + atkCooldown;
		animator.SetTrigger("Attack");
		currentState = UnitState.Attack;
	}

	void AttackState()
	{
		if(target == null) ToIdleState();

		if(Time.time > atkTimer)
		{
			if(!targetInRange)
				ToEngageState();
			if(!seeTarget)
				ToIdleState();
			
			ToAttackState();
		}
	}

	void DieState()
	{
		print(unitName + " died.");
		if(OnDied != null) OnDied();
	}
		
	// Specific actions
	void Kills()
	{
		print(unitName + " kills.");
		if(OnKills != null) OnKills();
	}

	public void TakeDamage(int dmg)
	{
		Health -= dmg;
	}
}

public enum UnitState
{
	None = 0,
	Idle,
	Patrol,
	Engage,
	Chasing,
	Attack,
	Die
}