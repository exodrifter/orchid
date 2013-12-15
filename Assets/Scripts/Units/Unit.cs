using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    //TODO need to get these from darwin
        //SourcePoint
        //DestinationPoint

    public enum UnitType { Ground, Air };

    public float velocity = 100; // pixels per second
    private Vector2 m_direction;

    public int health = 100;

    public UnitType type = UnitType.Air;

    //Use this for initialization
    void Start()
    {
        m_direction.x = 1;
        m_direction.y = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Target() {
        // at some point assign the target point and make it point in that direction
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
