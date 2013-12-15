using UnityEngine;
using System.Collections;

public class UnitFactory : MonoBehaviour {
	
	public int m_fighterLevel = 0;
	public int m_bomberLevel = 0;
	
	public GameObject fighterSmall;
	public GameObject fighterMedium;
	public GameObject fighterBig;
	
	public GameObject bomberSmall;
	public GameObject bomberMedium;
	public GameObject bomberBig;
	
	public GameObject SpawnUnit(Entity.Type type) {
		GameObject prefab = null;
		switch(type) {
		case Entity.Type.fighter:
			if(m_fighterLevel < 1) {
				prefab = fighterSmall;
			} else if(m_fighterLevel < 2) {
				prefab = fighterMedium;
			} else {
				prefab = fighterBig;
			}
			break;
		case Entity.Type.bomber:
			if(m_bomberLevel < 1) {
				prefab = bomberSmall;
			} else if(m_bomberLevel < 2) {
				prefab = bomberMedium;
			} else {
				prefab = bomberBig;
			}
			break;
		}
		return Instantiate(prefab) as GameObject;
	}
}
