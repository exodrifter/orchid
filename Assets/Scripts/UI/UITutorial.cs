using UnityEngine;
using System.Collections;

public class UITutorial : MonoBehaviour {
	
	public Vector3 m_moveTo;
	public float m_waitTime = 0f;
	public float m_showTime = 6f;
	public bool m_autohide = true;
	public AudioClip m_sound;
	
	void Start() {
		GetComponent<Renderer>().enabled = false;
		StartCoroutine(DelayedStart());
	}
	
	IEnumerator DelayedStart() {
		yield return new WaitForSeconds(m_waitTime);
		
		transform.position = m_moveTo;
		GetComponent<Renderer>().enabled = true;
		if(m_sound != null) {
			AudioSource source = gameObject.AddComponent<AudioSource>();
			source.loop = false;
			source.clip = m_sound;
			source.Play();
		}
		
		if(m_autohide)
			StartCoroutine(DelayedKill());
	}
	
	IEnumerator DelayedKill() {
		yield return new WaitForSeconds(m_showTime);
		Destroy(this.gameObject);
	}
}
