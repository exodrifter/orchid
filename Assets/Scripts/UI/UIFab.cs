using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class UIFab : PointUI {
	
	private string m_theme = "placeholder-";
	
	private GameObject m_fighterButton;
	private GameObject m_bomberButton;
	private GameObject m_icbmButton;
	
	void Awake() {
		int m_xMargin = 15;
		int m_yMargin = 15;
		m_fighterButton = CreateButton("button-fighter","fighter", new Vector2(-m_xMargin,m_yMargin));
		m_bomberButton = CreateButton("button-bomber","bomber", new Vector2(0,m_yMargin));
		m_icbmButton = CreateButton("button-icbm","icbm", new Vector2(m_xMargin,m_yMargin));
		m_children.Add(m_fighterButton);
		m_children.Add(m_bomberButton);
		m_children.Add(m_icbmButton);
	}
	
	void Update() {
		if(Input.GetMouseButtonDown(0)) {
			Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			// Check if the click was on the point
			if(collider2D.OverlapPoint(clickPos)) {
				SetOpen(!IsOpen());
			}
			// Check if it collides with any children
			else if(!m_fighterButton.collider2D.OverlapPoint(clickPos)
					&& !m_bomberButton.collider2D.OverlapPoint(clickPos)
					&& !m_icbmButton.collider2D.OverlapPoint(clickPos)) {
				SetOpen(false);
			}
		}
	}
	
	private GameObject CreateButton(string name, string type, Vector2 offset) {
		GameObject ret = new GameObject();
		ret.name = name;
		ret.transform.parent = this.transform;
		ret.transform.localPosition = offset;
		ret.SetActive(false);
		
		tk2dSprite sprite = ret.AddComponent<tk2dSprite>();
		sprite.SetSprite(GetComponent<tk2dSprite>().Collection, m_theme + type);
		
		BoxCollider2D box = ret.AddComponent<BoxCollider2D>();
		box.size = sprite.GetBounds().size;
		box.isTrigger = true;
		
		return ret;
	}
}
