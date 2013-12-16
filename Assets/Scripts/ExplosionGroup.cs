using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionGroup : MonoBehaviour {
	public float EXPLOSION_TIME = .75f;
	public float EXPLOSION_FREQ = .1f;
	public float EXPLOSION_FREQ_VARIANCE = .1f;
	
	public List<GameObject> m_explosions;
	public Vector2 m_range;
	private Timer m_timer;
	private bool m_spawningAllowed;
	
	void Awake() {
		m_timer = new Timer();
		m_spawningAllowed = true;
	}
	
	void Start() {
		RestartTimer();
		StartCoroutine(DelayedKill());
	}
	
	IEnumerator DelayedKill() {
		yield return new WaitForSeconds(EXPLOSION_TIME);
		m_spawningAllowed = false;
		yield return new WaitForSeconds(EXPLOSION_TIME);
		Destroy(this.gameObject);
	}
	
	void Update () {
		if(!m_spawningAllowed) {
			return;
		}
		
		m_timer.elapsed += Time.deltaTime;
		if(m_timer.HasElapsed()) {
			GameObject go = Instantiate(m_explosions[Random.Range(0,m_explosions.Count-1)]) as GameObject;
			go.transform.parent = this.transform;
			Vector3 pos = this.transform.position;
			pos.x = go.transform.position.x + Random.Range(-m_range.x, m_range.x);
			pos.y = go.transform.position.y + Random.Range(-m_range.y, m_range.y);
			pos.z = go.transform.position.z;
			go.transform.position = pos;
		}
	}

	void RestartTimer() {
		m_timer.time = Random.Range(EXPLOSION_FREQ, EXPLOSION_FREQ_VARIANCE);
	}
}
