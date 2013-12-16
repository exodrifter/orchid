using UnityEngine;
using System.Collections;

/// <summary>
/// Generic point class for all of the locations on the map that the player can
/// interact with.
/// </summary>
public abstract class Point : Entity {
	
	public AudioClip m_destructionSound;
	public bool m_canRespawn = false;
	
	private bool m_rewardGiven;
	
	/// <summary>
	/// The amount of money that this point should reward the attacker when destroyed
	/// </summary>
	protected int m_money;
	
    protected MoneyEffect m_moneyEffect;

    protected void Awake(){
         
    }

    void Start(){
        m_moneyEffect = gameObject.AddComponent<MoneyEffect>();
    }

	public int money {
		get { return m_money; }
	}
	
	protected void Update() {
		if(dead) {
			if(!m_rewardGiven) {
				AudioSource.PlayClipAtPoint(m_destructionSound,this.transform.position,0.6f);
				if(m_owner == Owner.PLAYER) {
					State.EnemyMoney += m_money;
				} else {
					State.PlayerMoney += m_money;
                    Debug.Log("Giving Money");
                    m_moneyEffect.StartEffect(m_money);
				}
				m_rewardGiven = true;
			}
            //gameObject.SetActive(false);
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.name + " triggered by " + other.GetType());
        if (other is BoxCollider2D)
        {
            Entity possibleTarget = other.gameObject.GetComponent<Entity>();
            if(possibleTarget.type == Type.bomber || possibleTarget.type == Type.fighter){
                Unit possibleUnit = (Unit) possibleTarget;
                if(possibleUnit.destination.position == this.position){
                    possibleUnit.ReachedDestination();
                }
                else if(possibleUnit.source.position == this.position){
                    possibleUnit.FinishMission();
                }
            }
        }
    }

}
