using UnityEngine;
using System.Collections;

/// <summary>
/// Generic point class for all of the locations on the map that the player can
/// interact with.
/// </summary>
public abstract class Point : Entity {
	
	
	public bool m_canRespawn = false;
	
	private bool m_rewardGiven;
	
	protected void Update() {
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

    public void UnitReturned(int value){
        State.PlayerMoney += value; //TODO this needs to be checked
        m_moneyEffect.StartEffect(value);
    }

}
