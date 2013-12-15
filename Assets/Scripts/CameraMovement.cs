using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	public Vector2 m_moveSpeed = new Vector2(.5f,.5f);
	
	// Update is called once per frame
	void Update () {
		Vector2 delta = m_moveSpeed;
		delta.x *= Input.GetAxis("Horizontal");
		delta.y *= Input.GetAxis("Vertical");
		
		Vector3 newPos = (transform.position + (Vector3)delta);
		transform.position = newPos;
	}
}
