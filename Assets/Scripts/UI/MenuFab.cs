using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class MenuFab : MonoBehaviour {
	
	private string m_theme = "placeholder-";
	
	private bool m_open;
	private GameObject m_fighterButton;
	private GameObject m_bomberButton;
	private GameObject m_icbmButton;
	private int m_xMargin = 15;
	private int m_yMargin = 15;
	
	void Awake() {
		m_open = false;
		m_fighterButton = CreateButton("fighter", new Vector2(-m_xMargin,m_yMargin));
		m_bomberButton = CreateButton("bomber", new Vector2(0,m_yMargin));
		m_icbmButton = CreateButton("icbm", new Vector2(m_xMargin,m_yMargin));
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
	
	public void SetOpen(bool open) {
		m_open = open;
		m_fighterButton.SetActive(m_open);
		m_bomberButton.SetActive(m_open);
		m_icbmButton.SetActive(m_open);
	}
	
	public bool IsOpen() {
		return m_open;
	}
	
	private GameObject CreateButton(string type, Vector2 offset) {
		GameObject ret = new GameObject();
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
