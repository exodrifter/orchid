using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D),typeof(PointWonder))]
public class MenuWonder : MonoBehaviour {
	
	public tk2dFontData m_font;
	public string m_name;
	
	private bool m_open;
	private GameObject m_nameText;
	private GameObject m_moneyText;
	
	private Point m_point;

	void Awake() {
		m_open = false;
		m_nameText = MakeText(m_name, new Vector3(0,20,-1));
		m_moneyText = MakeText("", new Vector3(0,10,-1));
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
		
		if(m_open) {
			tk2dTextMesh mesh = m_moneyText.GetComponent<tk2dTextMesh>();
			mesh.text = "Destroy for $" + m_point.money;
			mesh.Commit();
		}
	}
	
	public void SetOpen(bool open) {
		m_open = open;
		m_nameText.SetActive(m_open);
		m_moneyText.SetActive(m_open);
	}
	
	public bool IsOpen() {
		return m_open;
	}
	
	private GameObject MakeText(string text, Vector3 offset) {
		GameObject ret = new GameObject();
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
