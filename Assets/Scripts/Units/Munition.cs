using UnityEngine;
using System.Collections;

public class Munition : MonoBehaviour {

    public float velocity = 100; // pixels per second
    private Vector2 m_direction;
    
    public Unit.UnitType targetType = Unit.UnitType.Air;
    public float damage = 10; // 10 damage

    private float z = 1.35f;

    //Use this for initialization
    void Awake()
    {
        Rigidbody2D rigidBody2D = gameObject.AddComponent("Rigidbody2D") as Rigidbody2D;
        rigidBody2D.isKinematic = true;
        rigidBody2D.fixedAngle = true;
        rigidBody2D.gravityScale = 0f;
        //m_direction.x = 1;
        //m_direction.y = 0;
	}
	
    //This function is called every fixed framerate frame
	void FixedUpdate () {
        //Vector2 currentPosition = transform.position;
        

        //float newX = (velocity * m_direction.x * Time.deltaTime) + currentPosition.x;
        //float newY = (velocity * m_direction.y * Time.deltaTime) + currentPosition.y;


        //Vector3 newPosition = new Vector3(newX, newY, z);

        //transform.position = newPosition;
    }

    public void FireAt(Vector2 position, Vector2 targetDirection) {
        transform.position = new Vector3(position.x, position.y, 1.35f);
        gameObject.GetComponent<Rigidbody2D>().velocity = targetDirection * velocity;
    }
}
