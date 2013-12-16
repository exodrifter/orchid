using UnityEngine;
using System.Collections;

public class PointFab : Point {
	
	new void Awake() {
        base.Awake();
		m_hp = 10;
		m_money = 10;
	}
}
