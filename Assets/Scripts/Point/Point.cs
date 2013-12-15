using UnityEngine;
using System.Collections;

/// <summary>
/// Generic point class for all of the locations on the map that the player can
/// interact with.
/// </summary>
public abstract class Point : MonoBehaviour {
	
	/// <summary>
	/// The amount of HP that this point has
	/// </summary>
	protected int m_hp;
	
	/// <summary>
	/// The amount of damage that this point has recieved
	/// </summary>
	protected int m_damage;
	
	/// <summary>
	/// The amount of money that this point should reward the attacker when destroyed
	/// </summary>
	protected int m_money;
	
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
	
	public int money {
		get { return m_money; }
	}

    public Vector2 position {
        get { return transform.position; }
    }
}
