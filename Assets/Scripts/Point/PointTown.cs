using UnityEngine;
using System.Collections;

public class PointTown : Point {
	
	private int m_population;
	private Timer m_timer;
	
	public int population {
		get { return m_population; }
	}
	
	void Awake() {
		m_hp = 50;
		m_money = 2;
		m_population = 1;
	}
	
	void Update() {
		if(!dead) {
			m_timer.elapsed += Time.deltaTime;
			while(m_timer.HasElapsed()) {
				m_population++;
				m_hp = m_population * 50;
				m_money = m_population * 2;
				m_timer.SetBack();
			}
		}
	}
}
