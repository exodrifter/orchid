using UnityEngine;
using System.Collections;

public class PointWonder : Point {
	
	void Awake() {
		m_hp = 100;
		m_money = 10;
	}
	
	new void Update() {
		base.Update();
        if(dead) {
			GetComponent<tk2dSprite>().SetSprite("BigCrater");
		}
	}
}
