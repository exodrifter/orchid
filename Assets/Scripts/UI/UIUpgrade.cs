using UnityEngine;
using System.Collections;

public class UIUpgrade : MonoBehaviour {
	
	public int m_index = 0;
	
	public tk2dFontData m_font;
	private tk2dTextMesh m_mesh;
	
	private Vector3 m_anchoredPosition;
	private GameObject m_text;
	
	void Awake() {
		SetPosition(m_index);
		m_text = new GameObject();
		m_text.transform.parent = this.transform;
		m_mesh = m_text.AddComponent<tk2dTextMesh>();
		m_mesh.font = m_font;
		m_mesh.maxChars = 20;
		m_mesh.anchor = TextAnchor.LowerRight;
	}
	
	void Update() {
		//m_mesh.text = "$" + State.PlayerMoney;
		//m_mesh.Commit();
	}
	
	void OnMouseEnter() {
		transform.localPosition = m_anchoredPosition + new Vector3(0,10,0);
	}
	
	void OnMouseExit() {
		transform.localPosition = m_anchoredPosition;
	}
	
	void SetPosition(int index) {
		m_anchoredPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-45-(60*index),10,0));
		transform.position = m_anchoredPosition;
		
		// Reset the local z position value
		m_anchoredPosition = transform.localPosition;
		m_anchoredPosition.z = 0;
		transform.localPosition = m_anchoredPosition;
		
		// Save the anchored position
		m_anchoredPosition = transform.localPosition;
	}
}
