using UnityEngine;
using System.Collections;

/// <summary>
/// Generic point class for all of the locations on the map that the player can
/// interact with.
/// </summary>
public abstract class Point : Entity {
		
	/// <summary>
	/// The amount of money that this point should reward the attacker when destroyed
	/// </summary>
	protected int m_money;
	
	public int money {
		get { return m_money; }
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
