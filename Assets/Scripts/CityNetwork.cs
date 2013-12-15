using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityNetwork : MonoBehaviour {
	
	private List<PointCity> m_list = new List<PointCity>();
	
	private float m_spawnTime = 5.0f;
	private float m_spawnTimeVariance = 5.0f;
	private Timer m_spawnTimer = new Timer(5);
	
	void Start() {
		m_spawnTimer.Reset();
		foreach(PointCity point in GetComponentsInChildren<PointCity>()) {
			m_list.Add(point);
		}
	}
	
	void Update() {
		m_spawnTimer.elapsed += Time.deltaTime;
		while(m_spawnTimer.HasElapsed()) {
			int index = Random.Range(0,m_list.Count-1);
			m_list[index].exists = true;
			m_spawnTimer.SetBack();
			m_spawnTimer.time = m_spawnTime + Random.Range(0,m_spawnTimeVariance);
		}
	}
}
