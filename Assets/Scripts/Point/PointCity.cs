using UnityEngine;
using System.Collections;

public class PointCity : Point {
	
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
		m_timer = new Timer(10.0f);
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
			}
		} else {
			exists = false;
		}
	}
	
	void Reset() {
		m_hp = 50;
		m_money = 2;
		m_population = 1;
		m_timer.Reset();
	}
}
