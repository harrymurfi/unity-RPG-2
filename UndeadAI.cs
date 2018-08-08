using UnityEngine;

public class UndeadAI : MonoBehaviour, IDamage
{
	public Texture2D atkCursor;
	public static Player player;

	int health = 1000;
	public int Health
	{
		get { return health; }
		set {
			health = value;
			if(health < 0)
			{
				Debug.Log("Die");
				Die();
			}
		}
	}

	void Start()
	{
		player = FindObjectOfType<Player>();
	}

	void OnMouseEnter()
	{
		Cursor.SetCursor(atkCursor, Vector2.zero, CursorMode.Auto);

		if(Input.GetMouseButtonDown(0))
		{
			
		}
	}

	#region IDamage implementation

	public void TakeDamage(int dmg)
	{
		Health -= dmg;
	}

	public void Die()
	{
		print(gameObject.name + " has died");
		player.curTarget = null;
		Destroy(this.gameObject);
	}

	#endregion
}
