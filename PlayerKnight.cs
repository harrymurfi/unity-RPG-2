using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerKnight : MonoBehaviour, IDamage
{
	public LayerMask groundLayer;

	NavMeshAgent agent;
	Animator anim;
	Canvas canvas;

	public Transform curTarget;
	public float rangeToTarget;
	bool targetInRange;
	public float atkRangeSqr = 25.00f;
	public float atkCooldown = 0.5f;
	public int maxHp = 1000;
	int health = 1000;

	public int Health
	{
		get { return health; }
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
		anim = GetComponentInChildren<Animator>();
		Health = maxHp;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			Destroy(gameObject);
		}

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
				if(Physics.Raycast(ray, out hit))
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
					else if(hit.collider.tag == "NPC")
					{
						
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
				unit.TakeDamage(0);
			}
		}

		if(!agent.hasPath) anim.SetBool("Run", false);
		else anim.SetBool("Run", true);
	}

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

	public void TakeDamage (int dmg)
	{
		print("Player take " + dmg + " damage");
		Health -= dmg;
	}

	public void Die ()
	{
		print("Player has died");
		//Destroy(gameObject);
		Health = maxHp;
	}

	#endregion
}
