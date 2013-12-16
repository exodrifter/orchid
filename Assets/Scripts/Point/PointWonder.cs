using UnityEngine;
using System.Collections;

public class PointWonder : Point {
	
	new void Awake() {
        base.Awake();
		m_hp = 100;
		m_money = 10;
	}

    new void Update() {
		base.Update();
        if(dead){
            GetComponent<tk2dSprite>().SetSprite("MedCrater");
        }
    }
}
