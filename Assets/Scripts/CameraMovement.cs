using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	public Vector2 m_moveSpeed = new Vector2(.5f,.5f);
	
	public Vector2 m_minBounds;
	public Vector2 m_maxBounds;
	
	// Update is called once per frame
	void Update () {
		Vector2 delta = m_moveSpeed;
		delta.x *= Input.GetAxis("Horizontal");
		delta.y *= Input.GetAxis("Vertical");
		
		Vector3 newPos = (transform.position + (Vector3)delta);
		if(newPos.x > m_maxBounds.x) {
			newPos.x = m_maxBounds.x;
		} else if(newPos.x < m_minBounds.x) {
			newPos.x = m_minBounds.x;
		}
		
		if(newPos.y > m_maxBounds.y) {
			newPos.y = m_maxBounds.y;
		} else if(newPos.y < m_minBounds.y) {
			newPos.y = m_minBounds.y;
		}
		
		transform.position = newPos;
	}
}
