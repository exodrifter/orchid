using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class PointButton : MonoBehaviour {
	
	void Update () {
		
	}
	
	void OnMouseOver() {
		Debug.Log("Hello");
	}
}
