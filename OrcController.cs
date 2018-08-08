using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OrcController : MonoBehaviour, IDamage
{
	public enum OrcState {Idle, Run, Walk, Attack};
	public LayerMask groundLayer;

	NavMeshAgent agent;
	Animator anim;
	Canvas can;

	OrcState curState = OrcState.Idle;
	public Transform curTarget;
	public float rangeToTarget;
	bool targetInRange;
	public float atkRangeSqr = 25.00f;
	public float atkCooldown = 0.5f;

	int health = 1000;
	public int Health
	{
		get { return health;}
		set {
			health = value;
			if(health < 0)
			{
				health = 0;
				Die();
			}
		}
	}

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
	}

//	void Update()
//	{
//		if(Input.GetMouseButtonDown(0))
//		{
//			Action();
//		}
//
//		if(curTarget != null)
//		{
//			rangeToTarget = (curTarget.position - transform.position).sqrMagnitude;
//			if( rangeToTarget < atkRange)
//			{
//				targetInRange = true;
//			}
//			else
//			{
//				targetInRange = false;
//			}
//
//			if(targetInRange)
//			{
//				Attack(curTarget);
//			}
//			else
//			{
//				Chase(curTarget);
//			}
//		}
//		txt.text = "Sqrt Range:" + rangeToTarget.ToString();
//	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.S))
		{
			agent.ResetPath();
		}

		if(Input.GetMouseButtonDown(0))
		{
			if(!EventSystem.current.IsPointerOverGameObject())
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray, out hit, 1000.00f, groundLayer, QueryTriggerInteraction.Ignore))
				{
					if(hit.collider.tag == "Ground")
					{
						curTarget = null;
						agent.SetDestination(hit.point);
					}
					else if(hit.collider.tag == "Enemy")
					{
						curTarget = hit.transform;
					}
				}
			}
		}

		if(curTarget)
		{
			rangeToTarget = (curTarget.transform.position - transform.position).sqrMagnitude;
			if(rangeToTarget > atkRangeSqr)
			{
				agent.SetDestination(curTarget.position);
			}
			else
			{
				agent.ResetPath();
				anim.SetTrigger("Attack");
				IDamage unit = curTarget.GetComponent<IDamage>();
				unit.TakeDamage(100);
			}
		}

		if(!agent.hasPath) anim.SetBool("Run", false);
		else anim.SetBool("Run", true);
	}

//	void Action()
//	{
//		RaycastHit hit;
//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		if(Physics.Raycast(ray, out hit))
//		{
//			if(hit.collider.tag == "Ground")
//			{
//				Debug.Log("moving");
//				curTarget = null;
//				Move(hit.point);
//				anim.SetBool("Run", true);
//			}
//			else if(hit.collider.tag == "Enemy")
//			{
//				Debug.Log("attack");
//				curTarget = hit.collider.transform;
//			}
//		}
//	}

	void Move(Vector3 dest)
	{
		agent.SetDestination(dest);
	}

	void Attack(Transform trgt)
	{
		anim.SetTrigger("Attack");
	}

	void Chase(Transform trgt)
	{
		Move(curTarget.position);
	}

	#region IDamage implementation

	public void TakeDamage(int dmg)
	{
		throw new System.NotImplementedException ();
	}

	public void Die()
	{
		print("Player has died");
	}

	#endregion
}
