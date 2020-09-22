using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
    public enum Type {bomber, fighter, icbm, point};
	
    public AudioClip m_destructionSound;
    public ExplosionGroup m_explosion;

	/// <summary>
	/// The owner of this point
	/// </summary>
	public Owner m_owner = Owner.ENEMY;
	
	/// <summary>
	/// The amount of HP that this point has
	/// </summary>
	public int m_hp;
	
	/// <summary>
	/// The amount of damage that this point has recieved
	/// </summary>
	public int m_damage;

    /// <summary>
	/// The amount of money that this point should reward the attacker when destroyed
	/// </summary>
	public int m_money;

	private bool m_rewardGiven = false;

    /// <summary>
	/// The type of the entity
	/// </summary>
    public Type m_type;

    protected MoneyEffect m_moneyEffect;
    protected HealthBar m_healthBar;
	
	public int hp {
		get { return m_hp; }
	}
	
	public int damage {
		get { return m_damage; }
		set { m_damage = value; }
	}
	
	public bool dead {
		get { return m_damage >= m_hp; }
	}

    public Type type {
		get { return m_type; }
	}

    public int money {
		get { return m_money; }
	}
	
    public Vector2 position {
        get { return transform.position; }
    }

    public IEnumerator HitEffect()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        for (int i = 0; i < 2; i++)
        {
            yield return 0;
        }
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    protected void Start(){
        m_moneyEffect = gameObject.AddComponent<MoneyEffect>();
        m_healthBar = gameObject.AddComponent<HealthBar>();

        m_healthBar.maxHealth = m_hp;
        m_healthBar.currentHealth = m_hp;
    }

    protected void Update(){
        m_healthBar.currentHealth = m_hp - damage;
    }

    public void TakeDamage(int damage)
    {
		// Deal damage
		if(!dead) {
			StartCoroutine(HitEffect());
			m_damage += damage;
		}
		// If the entity is now dead, play death stuff and reward correct player
		if(dead && !m_rewardGiven) {
			m_rewardGiven = true;
			
			AudioSource.PlayClipAtPoint(m_destructionSound, this.transform.position,0.6f);
			if(m_owner == Owner.PLAYER) {
				State.EnemyMoney += m_money;
            } else {
				State.PlayerMoney += m_money;
				m_moneyEffect.StartEffect(m_money);
			}
			
			// Explosion!
			Explode();

		}
	}

    public void Explode(){
    	GameObject go = Instantiate(m_explosion.gameObject) as GameObject;
		go.transform.position = this.transform.position + new Vector3(0,0,-1);
        gameObject.GetComponent<Renderer>().enabled = false;
		if(Type.point != m_type) {
			go.GetComponent<ExplosionGroup>().m_range*=.3f;
            Destroy(gameObject, 0.2f);
		} else {
            State.instance.UnregisterPoint(this as Point);
        }
    }
}
