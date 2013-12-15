using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {


    private Point m_source, m_destination;

    public enum UnitType { Ground, Air };

    public float velocity = 100; // pixels per second
    private Vector2 m_direction;

    private SphereCollider m_range;
    public float range = 10;

    public int health = 100;

    public UnitType type = UnitType.Air;

    //Use this for initialization
    void Start() {
        m_direction.x = 1;
        m_direction.y = 0;

        m_range = gameObject.AddComponent("SphereCollider") as SphereCollider;
        m_range.radius = range;
        m_range.isTrigger = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Target(Point target) {
        // at some point assign the target point and make it point in that direction
        m_destination = target;
        m_direction = new Vector2(m_destination.position.x - transform.position.x, m_destination.position.y - transform.position.y);
    }

    void Source(Point source) {
        m_source = source;
    }

    //This function is called every fixed framerate frame
    void FixedUpdate(){
        Vector2 currentPosition = GetPosition();

        float newX = (velocity * m_direction.x * Time.deltaTime) + currentPosition.x;
        float newY = (velocity * m_direction.y * Time.deltaTime) + currentPosition.y;

        Vector2 newPosition = new Vector2(newX, newY);

        transform.position = newPosition;
    }
    
    //returns the current position of the Unit
    Vector2 GetPosition(){
        float myX = transform.position.x;
        float myY = transform.position.y;
        
        return new Vector2(myX, myY);
    }

    //overidable method used to attack an object
    void Attack(Unit target){
       //fire current unity munition at target
      
    }

    void TakeDamage(Munition bullet){
        
    }
   
}
