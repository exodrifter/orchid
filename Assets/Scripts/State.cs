using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {
	
	public const float GPT_TIME = 5.0f;
	public static int PLAYER_GPT = 2;
	public static int ENEMY_GPT = 3;
	
	public const int COST_FIGHTER = 4;
	public const int COST_BOMBER = 8;
	public const int COST_ICBM = 16;

    public const int COST_FIGHTER_UPGRADE = 50;
    public const int COST_BOMBER_UPGRADE = 100;

    public tk2dFontData defaultFont;
    public static State instance;
	
	private static Timer m_gptTimer;
    private static MoneyEffect m_moneyEffect;
	
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
        instance = this;
	}
	
	void Start() {
		m_gptTimer.Reset();

        m_moneyEffect = gameObject.AddComponent<MoneyEffect>();        
        m_moneyEffect.SetParent(GameObject.Find("counter-money").transform);
        m_moneyEffect.SetOffset(new Vector2(-7, -20));
	}
	
	void Update() {
		m_gptTimer.elapsed += Time.deltaTime;
		while(m_gptTimer.HasElapsed()) {
			State.m_playerMoney += PLAYER_GPT;
            m_moneyEffect.StartEffect(PLAYER_GPT);

			State.m_enemyMoney += ENEMY_GPT;
			m_gptTimer.SetBack();
		}
	}

	public static int GetCostOf(Entity.Type type) {
		switch(type) {
		case Entity.Type.fighter:
			return COST_FIGHTER;
		case Entity.Type.bomber:
			return COST_BOMBER;
		case Entity.Type.icbm:
			return COST_ICBM;
		default:
			return -1;
		}
	}
}
