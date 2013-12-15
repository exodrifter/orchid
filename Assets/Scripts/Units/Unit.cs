using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {


    private Point m_source, m_destination;
    private Unit m_target;

    public enum UnitType { Ground, Air };

    public float velocity = 100; // pixels per second
    private Vector2 m_direction;

    private GameObject m_range;
    public float range = 10;

    public GameObject munition;

    public int health = 100;

    public UnitType type = UnitType.Air;

    public int shootFrame, shootCount;

    //Use this for initialization
    void Start()
    {
        m_direction.x = 0;
        m_direction.y = 0;

        shootFrame = 0;
        shootCount = 20;

        InitBody();
        InitRange();
    }

    void InitBody(){
        Rigidbody2D rigidBody2D = gameObject.AddComponent("Rigidbody2D") as Rigidbody2D;
        rigidBody2D.isKinematic = false;
        rigidBody2D.fixedAngle = true;
        rigidBody2D.gravityScale = 0f;


        BoxCollider2D colliderTemp = gameObject.AddComponent<BoxCollider2D>();
        colliderTemp.size = gameObject.GetComponent<tk2dSprite>().GetBounds().size;
        colliderTemp.isTrigger = true;
    }

    void InitRange(){
        //m_range = new GameObject();
        //m_range.name = "UnitRange";
        //m_range.transform.position = transform.position;
        //m_range.transform.parent = transform;
        CircleCollider2D colliderTemp = gameObject.AddComponent<CircleCollider2D>();
        colliderTemp.radius = range;
        colliderTemp.isTrigger = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Target(Point target) {
        // at some point assign the target point and make it point in that direction
        m_destination = target;
        m_direction = new Vector2(m_destination.position.x - transform.position.x, m_destination.position.y - transform.position.y);
        m_direction.Normalize();
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

        if (m_target)
        {
            if (shootFrame == 0)
            {
                Attack(m_target);
                shootFrame++;
            }
            else
            {
                shootFrame++;
                if (shootFrame == shootCount)
                {
                    shootFrame = 0;
                }
            }

        }
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
        //GameObject payloadGameObject = ((GameObject)Instantiate(munition));
        //Munition payloadMunition = payloadGameObject.GetComponent<Munition>();

        //payloadMunition.gameObject.transform.position = transform.position;

        //Vector2 fireDirection = target.GetPosition() - GetPosition();
        //fireDirection.Normalize();

        //payloadMunition.FireAt(transform.position, fireDirection);
    }

    void TakeDamage(Munition bullet){
        
    }

    //OnTriggerEnter is called when the Collider other enters the trigger.
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered by " + other.GetType());
        if (other is BoxCollider2D) {
            m_target = other.gameObject.GetComponent<Unit>();
        }

    }

   
}
