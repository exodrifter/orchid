using UnityEngine;
using System.Collections.Generic;

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

		// Reset AI variables
		m_playerCities = new List<PointCity>();
		m_playerFabs = new List<PointFab>();
		m_playerWonders = new List<PointWonder>();
		
		m_enemyCities = new List<PointCity>();
		m_enemyFabs = new List<PointFab>();
		m_enemyWonders = new List<PointWonder>();
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
	
	#region AI
	
	private List<PointCity>   m_playerCities;
	private List<PointFab>    m_playerFabs;
	private List<PointWonder> m_playerWonders;
	
	private List<PointCity>   m_enemyCities;
	private List<PointFab>    m_enemyFabs;
	private List<PointWonder> m_enemyWonders;
	
	public List<PointCity> PlayerCities {
		get { return m_playerCities; }
	}
	
	public List<PointFab> PlayerFabs {
		get { return m_playerFabs; }
	}
	
	public List<PointWonder> PlayerWonders {
		get { return m_playerWonders; }
	}
	
	public List<PointCity> EnemyCities {
		get { return m_enemyCities; }
	}
	
	public List<PointFab> EnemyFabs {
		get { return m_enemyFabs; }
	}
	
	public List<PointWonder> EnemyWonders {
		get { return m_enemyWonders; }
	}
	
	public void RegisterPointForAI(Point p) {
		Debug.Log(p);
		if(p is PointCity) {
			if(p.m_owner == Owner.PLAYER) {
				m_playerCities.Add(p as PointCity);
			} else {
				m_enemyCities.Add(p as PointCity);
			}
		} else if(p is PointFab) {
			if(p.m_owner == Owner.PLAYER) {
				m_playerFabs.Add(p as PointFab);
			} else {
				m_enemyFabs.Add(p as PointFab);
			}
		} else if(p is PointWonder) {
			if(p.m_owner == Owner.PLAYER) {
				m_playerWonders.Add(p as PointWonder);
			} else {
				m_enemyWonders.Add(p as PointWonder);
			}
		}
	}
	
	#endregion
}
