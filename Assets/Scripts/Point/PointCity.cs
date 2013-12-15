using UnityEngine;
using System.Collections;

public class PointCity : Point {
	private const float GROWTH_TIME = 10.0f;
	
	private int m_population;
	public bool m_exists;
	private Timer m_timer;
	
	public int population {
		get { return m_population; }
	}
	
	public bool exists {
		get { return m_exists; }
		set {
			m_exists = value; 
			renderer.enabled = value;
		}
	}
	
	void Awake() {
		m_timer = new Timer(GROWTH_TIME);
		renderer.enabled = exists;
		Reset();
	}
	
	void Update() {
		if(!m_exists) {
			return;
		}
		
		if(!dead) {
			m_timer.elapsed += Time.deltaTime;
			while(m_timer.HasElapsed()) {
				m_population++;
				m_hp = m_population * 50;
				m_money = m_population * 2;
				m_timer.SetBack();

				if(9 < population) {
					GetComponent<tk2dSprite>().SetSprite("BigCity");
				} else if(4 < population) {
					GetComponent<tk2dSprite>().SetSprite("MedCity");
				} else {
					GetComponent<tk2dSprite>().SetSprite("SmallCity");
				}
			}
		} else {
			exists = false;
		}
	}
	
	void Reset() {
		GetComponent<tk2dSprite>().SetSprite("SmallCity");
		m_hp = 50;
		m_money = 2;
		m_population = 1;
		m_timer.Reset();
	}
}
