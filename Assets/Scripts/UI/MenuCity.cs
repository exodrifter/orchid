using UnityEngine;
using System.Collections;

public class MenuCity : MonoBehaviour {
	
	public tk2dFontData m_font;
	
	private bool m_open;
	private GameObject m_popText;
	
	private PointCity m_point;
	
	void Start () {
		m_popText = MakeText("", new Vector3(0,-10,-1));
		m_point = GetComponent<PointCity>();
	}
	
	void Update () {
		// Check if the mouse is hovering
		Vector3 hoverPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if(collider2D.OverlapPoint(hoverPos)) {
			SetOpen(true);
		} else {
			SetOpen(false);
		}
		
		tk2dTextMesh mesh = m_popText.GetComponent<tk2dTextMesh>();
		if(m_open) {
			mesh.text = "Population: " + m_point.population;
		} else {
			mesh.text = ""+m_point.population;
		}
		mesh.Commit();
	}
	
	public void SetOpen(bool open) {
		m_open = open;
	}
	
	public bool IsOpen() {
		return m_open;
	}
	
	private GameObject MakeText(string text, Vector3 offset) {
		GameObject ret = new GameObject();
		ret.transform.parent = this.transform;
		ret.transform.localPosition = offset;
		ret.SetActive(true);
		
		tk2dTextMesh mesh = ret.AddComponent<tk2dTextMesh>();
		mesh.font = m_font;
		mesh.text = text;
		mesh.maxChars = 20;
		mesh.anchor = TextAnchor.MiddleCenter;
		mesh.Commit();
		
		return ret;
	}
}
