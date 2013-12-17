using UnityEngine;
using System.Collections;

public class PointCity : Point {
	
	private const float GROWTH_TIME = 60.0f;
	
	private int m_population;
	private Timer m_timer;
	
	public bool m_startActive = false;
	
	public int population {
		get { return m_population; }
	}
	
	void Awake() {
		m_timer = new Timer(GROWTH_TIME);
		gameObject.SetActive(m_startActive);
		Reset();
	}
	
	new void Start() {
        base.Start();
		Reset();
	}
	
	new void Update() {
		base.Update();
		if(!dead) {
			m_timer.elapsed += Time.deltaTime;
			while(m_timer.HasElapsed()) {
				m_population = m_population > 9 ? m_population : m_population++;
                if(m_owner == Owner.PLAYER){
				    State.PLAYER_GPT++;
                }
                else if(m_owner == Owner.ENEMY){
                     State.ENEMY_GPT++;
                }
                m_hp = m_population * 20;
				m_money = m_population * 15;
				m_timer.SetBack();
				
				if(9 < population) {
					GetComponent<tk2dSprite>().SetSprite("BigCity");
				} else if(4 < population) {
					GetComponent<tk2dSprite>().SetSprite("MedCity");
				} else {
					GetComponent<tk2dSprite>().SetSprite("SmallCity");
				}
			}
		}
        else{
            if(9 < population) {
                GetComponent<tk2dSprite>().SetSprite("BigRubble");
            } else if(4 < population) {
                GetComponent<tk2dSprite>().SetSprite("MedRubble");
            } else {
                GetComponent<tk2dSprite>().SetSprite("SmallRubble");
            }
        }
	}
	
	void Reset() {
		GetComponent<tk2dSprite>().SetSprite("SmallCity");
		GetComponent<tk2dSprite>().color = m_owner == Owner.PLAYER ? Color.white : new Color(1,.3f,.3f);
		m_hp = 50;
		m_money = 2;
		m_population = 1;
		m_timer.Reset();
	}
}
