using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {
	
	private static int m_playerMoney = 0;
	public static int PlayerMoney {
		get { return m_playerMoney; }
		set { m_playerMoney = value; }
	}
	
	private static int m_enemyMoney = 0;
	public static int EnemyMoney {
		get { return m_playerMoney; }
		set { m_playerMoney = value; }
	}
}
