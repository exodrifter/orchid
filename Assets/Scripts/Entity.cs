using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
    public enum Type {bomber, fighter, icbm, point};

	/// <summary>
	/// The owner of this point
	/// </summary>
	public Owner m_owner = Owner.ENEMY;
	
	/// <summary>
	/// The amount of HP that this point has
	/// </summary>
	protected int m_hp;
	
	/// <summary>
	/// The amount of damage that this point has recieved
	/// </summary>
	protected int m_damage;
	
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
	
    public Vector2 position {
        get { return transform.position; }
    }
}
