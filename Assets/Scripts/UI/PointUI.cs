using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Floating UI meant for use with points on the map.
/// </summary>
public class PointUI : MonoBehaviour {
	
	protected List<GameObject> m_children = new List<GameObject>();
	private bool m_open;
	
	void Awake() {
		m_open = false;
	}
	
	public void SetOpen(bool open) {
		m_open = open;
		foreach(GameObject go in m_children) {
			go.SetActive(m_open);
		}
	}
	
	public bool IsOpen() {
		return m_open;
	}
}
