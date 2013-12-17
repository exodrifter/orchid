using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
    
    private LineRenderer m_renderer;
    private float m_maxHealth;
    private float m_currentHealth;

    public float currentHealth{
        get { return m_currentHealth; }
        set { m_currentHealth = value; }
    }

    public float maxHealth{
        get { return m_maxHealth; }
        set { m_maxHealth = value; }
    }

	// Use this for initialization
    private float m_maxLength;
	void Start () {
        m_renderer = gameObject.AddComponent<LineRenderer>();
        m_renderer.material = new Material(Shader.Find("Particles/Additive (Soft)"));   

        tk2dSprite sprite = gameObject.GetComponent<tk2dSprite>();
        
        m_maxLength = sprite.GetBounds().extents.x * 2;

        m_renderer.SetPosition(0, gameObject.transform.position + new Vector3(-m_maxLength/2,-10, 0));
        m_renderer.SetPosition(1, gameObject.transform.position + new Vector3(m_maxLength/2,-10, 0));
                
        m_renderer.SetWidth(2f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
        m_renderer.SetPosition(0, gameObject.transform.position + new Vector3(-m_maxLength/2,-10, 0));
        m_renderer.SetPosition(1, gameObject.transform.position + new Vector3((-m_maxLength/2) + m_maxLength * (m_currentHealth/m_maxHealth),-10, 0));

        Color colour = new Color(1 - (m_currentHealth/m_maxHealth), (m_currentHealth/m_maxHealth),0 );
        m_renderer.SetColors(colour, colour);
    }
}
