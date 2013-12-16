using UnityEngine;
using System.Collections;

public class UIMoney : MonoBehaviour {
	
	public tk2dFontData m_font;
	private tk2dTextMesh m_mesh;
	
	void Awake() {
		SetPosition();
		m_mesh = gameObject.AddComponent<tk2dTextMesh>();
		m_mesh.font = m_font;
		m_mesh.maxChars = 20;
		m_mesh.anchor = TextAnchor.UpperRight;
	}
	
	void Update() {
		m_mesh.text = "$" + State.PlayerMoney;
		m_mesh.Commit();
	}
	
	void SetPosition() {
		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-10, Screen.height-10,0));
		transform.position = pos;
		
		// Reset the local z position value
		pos = transform.localPosition;
		pos.z = 0;
		transform.localPosition = pos;
	}
}
