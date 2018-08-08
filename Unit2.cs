using UnityEngine;

public class Unit2 : MonoBehaviour
{
	public UnitState currentState;
	public Transform target;
	public float atkRange;
	public bool seeTarget;
	public bool inRange;

	NavMeshAgent agent;
	Animator animator;

	float idleTimer;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
		currentState = UnitState.Idle;
	}

	void Update()
	{
		switch(currentState)
		{
		case UnitState.Idle: Idle(); break;
		case UnitState.Patrol: Patrol(); break;
		case UnitState.Chasing: Chasing(); break;
		case UnitState.Attack: Attack(); break;
		default: Idle(); break;
		}
	}

	void ToIdle()
	{
		animator.SetBool("Walk", false);
		agent.ResetPath();
		currentState = UnitState.Idle;
	}

	void Idle()
	{
		if(seeTarget)
			ToChasing();
	}

	void ToPatrol()
	{
		currentState = UnitState.Patrol;
	}

	void Patrol()
	{
		if(target)
			ToChasing();
	}

	void ToChasing()
	{
		animator.SetBool("Walk", true);
		currentState = UnitState.Chasing;
	}

	void Chasing()
	{
		if(target)
		{
			if(Vector3.Distance(transform.position, target.position) <= 3)
			{
				ToAttack();
			}
			else
			{
				if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
				{
					agent.SetDestination(target.position);
				}
			}
		}
		else
		{
			ToIdle();
		}
	}

	void ToAttack()
	{
		agent.ResetPath();
		animator.SetBool("Walk", false);
		currentState = UnitState.Attack;
	}

	void Attack()
	{
		if(target)
		{
			if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
			{
				if(Vector3.Distance(transform.position, target.position) > 3)
					ToChasing();
				else
				{
					animator.SetTrigger("Attack");
				}
			}
		}
		else
		{
			ToIdle();
		}
	}
}
