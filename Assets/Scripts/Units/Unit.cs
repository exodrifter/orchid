using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour {


    private Point m_source, m_destination;
    private Unit m_attackTarget;

    public enum UnitType { Ground, Air };

    public float velocity = 100; // pixels per second

    private GameObject m_range;
    public float range = 10;

    private Munition m_munition;
    private LineRenderer m_lineRenderer;

    public float health = 100;

    public UnitType type = UnitType.Air;

    private Timer m_attackTimer;

    public Vector2 position
    {
        get { return transform.position; }
    }

    //Use this for initialization
    void Start()
    {
        InitBody();
        InitRange();

        //This is for testing
            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(1,0)) * velocity;
        ///////////////////////

        m_munition = gameObject.AddComponent<Munition>();
        m_lineRenderer = gameObject.AddComponent<LineRenderer>();
        
        m_attackTimer = new Timer();
        m_attackTimer.time = m_munition.attack_time + Random.Range(0, m_munition.attack_time_variance);
    }

    void InitBody(){
        Rigidbody2D rigidBody2D = gameObject.AddComponent<Rigidbody2D>();
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
	void Update ()
    {
        if (m_attackTarget)
        { 
            m_attackTimer.elapsed += Time.deltaTime;
            while (m_attackTimer.HasElapsed())
            {
                Attack(m_attackTarget);

                m_attackTimer.SetBack();
                m_attackTimer.time = m_munition.attack_time + Random.Range(0, m_munition.attack_time_variance);
            }
        }
	}

    void Target(Point target)
    {
        // at some point assign the target point and make it point in that direction
        m_destination = target;

        Vector2 direction = m_destination.position - m_source.position;
        gameObject.GetComponent<Rigidbody2D>().velocity = direction.normalized * velocity;
    }

    //TODO this needs a better name
    void Source(Point source)
    {
        m_source = source;
    }

    //overidable method used to attack an object
    void Attack(Unit target)
    {
        float damage = m_munition.damage;

        Laser laser = new Laser(position, target.position, m_munition.colour);


        target.TakeDamage(damage);
    }

    void TakeDamage(float damage)
    {
        health -= damage;
    }

    //OnTriggerEnter is called when the Collider other enters the trigger.
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.name + " triggered by " + other.GetType());
        if (other is BoxCollider2D)
        {
            m_attackTarget = other.gameObject.GetComponent<Unit>();
        }

    }   
}
