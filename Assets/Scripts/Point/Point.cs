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

}
