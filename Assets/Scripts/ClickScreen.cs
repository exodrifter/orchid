using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickScreen : MonoBehaviour {

	public string m_level = "menu";

	public float m_delay = 0;
	bool m_canAdvance = false;

	void Start () {
		StartCoroutine(WaitActivate());
	}
	
	// Update is called once per frame
	void Update () {
		if(m_canAdvance && Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene(m_level);
		}
	}

	IEnumerator WaitActivate() {
		yield return new WaitForSeconds(m_delay);
		m_canAdvance = true;
	}
}
