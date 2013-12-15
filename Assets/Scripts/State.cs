using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {
	
	private const float GPT_TIME = 5.0f;
	private const int PLAYER_GPT = 2;
	private const int ENEMY_GPT = 3;
	
	private static Timer m_gptTimer;

	private static int m_playerMoney = 20;
	public static int PlayerMoney {
		get { return m_playerMoney; }
		set { m_playerMoney = value; }
	}
	
	private static int m_enemyMoney = 20;
	public static int EnemyMoney {
		get { return m_playerMoney; }
		set { m_playerMoney = value; }
	}
	
	void Awake() {
		m_gptTimer = new Timer(GPT_TIME);
	}
	
	void Start() {
		m_gptTimer.Reset();
	}
	
	void Update() {
		m_gptTimer.elapsed += Time.deltaTime;
		while(m_gptTimer.HasElapsed()) {
			State.m_playerMoney += PLAYER_GPT;
			State.m_enemyMoney += ENEMY_GPT;
			m_gptTimer.SetBack();
		}
	}
}
