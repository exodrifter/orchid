using UnityEngine;
using System.Collections;

public class Munition : MonoBehaviour {

    public float velocity = 100; // pixels per second
    private Vector2 m_direction;
    
    public Unit.UnitType targetType = Unit.UnitType.Air;
    public float damage = 10; // 10 damage

    //Use this for initialization
    void Start()
    {
        m_direction.x = 1;
        m_direction.y = 0;
	}
	
    //This function is called every fixed framerate frame
	void FixedUpdate () {
	    float newX = velocity * m_direction.x * Time.deltaTime;
        float newY = velocity * m_direction.y * Time.deltaTime;
	}
}
