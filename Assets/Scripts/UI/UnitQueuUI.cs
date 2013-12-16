using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitQueuUI : MonoBehaviour {

    public tk2dFontData m_font = State.instance.defaultFont;
    public GameObject unitPrefab;
    private GameObject m_titleText;

    private Transform m_parent;
    private Vector2 m_offset;

    private List<GameObject> m_spawnList = new List<GameObject>();
    
    void Awake(){
        m_parent = transform;
        m_titleText = MakeText("title-text", "Unit Queue", new Vector3(0, 10.0f, 0));
    }

    public void AddUnit(Entity.Type type){
        GameObject unit = Instantiate(prefab) as GameObject;
        

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
        unit.SetActive(false);
        m_spawnList.Add(unit);
    }

    void Update(){
        if(m_spawnList.Count > 0){
            foreach (GameObject unit in m_spawnList){
                unit.SetActive(true);
            }
        } else{
            foreach (GameObject unit in m_spawnList){
                unit.SetActive(false);
            }
        }
    }

    public void Clear(){
        m_spawnList.Clear();
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
		ret.transform.localPosition = m_offset;
        ret.name = name;
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
