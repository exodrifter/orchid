using UnityEngine;
using System.Collections;

public class ExplosionBehaviour : MonoBehaviour {
	
	void Start() {
		gameObject.GetComponent<tk2dSpriteAnimator>().AnimationCompleted += Destroy;
	}
	
	// Update is called once per frame
	void Destroy(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip clip) {
		Destroy(gameObject);
	}
}
