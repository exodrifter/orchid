using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D),typeof(PointWonder))]
public class UIWonder : PointUI {
	
	public tk2dFontData m_font;
	public string m_name;
	
	private GameObject m_nameText;
	private GameObject m_moneyText;
	
	private PointWonder m_point;

	void Awake() {
		m_nameText = MakeText("text-name",m_name, new Vector3(0,10,-1));
		m_moneyText = MakeText("text-money","", new Vector3(0,-10,-1));
		m_children.Add(m_nameText);
		m_children.Add(m_moneyText);
		m_point = GetComponent<PointWonder>();
	}
	
	void Update() {
		// Check if the mouse is hovering
		Vector3 hoverPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if(collider2D.OverlapPoint(hoverPos)) {
			SetOpen(true);
		} else {
			SetOpen(false);
		}
		
		if(IsOpen()) {
			if(m_point.m_owner == Owner.ENEMY) {
				tk2dTextMesh mesh = m_moneyText.GetComponent<tk2dTextMesh>();
				mesh.text = "Reward $" + m_point.money;
				mesh.Commit();
			}
		}
	}
	
	private GameObject MakeText(string name, string text, Vector3 offset) {
		GameObject ret = new GameObject();
		ret.name = name;
		ret.transform.parent = this.transform;
		ret.transform.localPosition = offset;
		ret.SetActive(false);
		
		tk2dTextMesh mesh = ret.AddComponent<tk2dTextMesh>();
		mesh.font = m_font;
		mesh.text = text;
		mesh.maxChars = 20;
		mesh.anchor = TextAnchor.MiddleCenter;
		mesh.Commit();
		
		return ret;
	}
}
