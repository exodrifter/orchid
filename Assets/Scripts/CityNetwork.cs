using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityNetwork : MonoBehaviour {
	private const float SPAWN_TIME = 5.0f;
	private const float SPAWN_TIME_VARIANCE = 5.0f;
	
	private List<PointCity> m_list = new List<PointCity>();
	
	private Timer m_spawnTimer;
	
	void Awake() {
		m_spawnTimer = new Timer();
		m_spawnTimer.time = SPAWN_TIME + Random.Range(0,SPAWN_TIME_VARIANCE);
	}
	
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
			m_spawnTimer.time = SPAWN_TIME + Random.Range(0,SPAWN_TIME_VARIANCE);
		}
	}
}
