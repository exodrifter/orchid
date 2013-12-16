using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitQueuUI : MonoBehaviour {

    public tk2dFontData m_font = State.instance.defaultFont;
    public GameObject unitPrefab;
    private GameObject m_titleText;

    private Transform m_parent;
    private Vector2 m_offset;

    private List<GameObject> m_spawnList;
    
    void Awake(){
        SetPosition();
        m_parent = transform;
        m_titleText = MakeText("title-text", "Unit Queue", new Vector3(20, 8, 0));
        m_spawnList = new List<GameObject>();
        m_offset = new Vector3(0, 0, 0);
    }

    void SetPosition() {
		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(20, 20, 0));
		transform.position = pos;
		
		// Reset the local z position value
		pos = transform.localPosition;
		pos.z = 0;
		transform.localPosition = pos;
	}

    public void AddUnit(Entity.Type type){
        GameObject unit = Instantiate(unitPrefab) as GameObject;
        unit.transform.parent = transform;
        unit.transform.localPosition = m_offset;


        switch (type)
        {
            case Entity.Type.bomber:
                unit.GetComponent<tk2dSprite>().SetSprite("SmallFighter");
                break;
            case Entity.Type.fighter:
                unit.GetComponent<tk2dSprite>().SetSprite("SmallBomber");
                break;
            //case Entity.Type.icbm:
            //    sprite.GetComponent<tk2dSprite>().SetSprite("SmallFighter");
            //    break;
            default:
                break;
        }
        m_offset.x += unit.GetComponent<tk2dSprite>().GetBounds().size.x + 3;

        unit.SetActive(false);
        m_spawnList.Add(unit);
    }

    void Update(){
        if(m_spawnList.Count > 0){
            m_titleText.SetActive(true);
            foreach (GameObject unit in m_spawnList){
                unit.SetActive(true);
            }
        } else{
            m_titleText.SetActive(false);
            foreach (GameObject unit in m_spawnList){
                unit.SetActive(false);
            }
        }
    }

    public void Clear(){
        foreach (GameObject unit in m_spawnList){
            Destroy(unit);
        }
        m_spawnList.Clear();
        m_offset = new Vector3(0, 0, 0);
    }

    public void SetParent(Transform parent){
        m_parent = parent;
    }

    public void SetOffset(Vector2 offset){
        m_offset = offset;
    }

    private GameObject MakeText(string name, string text, Vector3 offset) {        
        GameObject ret = new GameObject();		
		ret.transform.parent = m_parent;
		ret.transform.localPosition = offset;
        ret.name = name;
		
		
		tk2dTextMesh mesh = ret.AddComponent<tk2dTextMesh>();
		mesh.font = m_font;
		mesh.text = text;
		mesh.maxChars = 20;
		mesh.anchor = TextAnchor.MiddleCenter;
		mesh.Commit();
		
		return ret;
	}
}
