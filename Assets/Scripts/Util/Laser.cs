using UnityEngine;
using System.Collections;

public class Laser{
    private GameObject m_gameObject;
    private LineRenderer m_renderer;
    private Color m_OGColour;

    public IEnumerator Fade()
    {
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = m_OGColour;
            c.a = f;
            m_renderer.startColor = c;
            m_renderer.endColor = c;
            yield return 0;
        }
        GameObject.Destroy(m_gameObject);
    }

    
    public Laser(Vector2 start, Vector2 end, Color colour)
    {
        m_gameObject = new GameObject();
        m_renderer = m_gameObject.AddComponent<LineRenderer>();
        m_renderer.material = Resources.Load("Line") as Material;   

        m_renderer.SetPosition(0, start);
        m_renderer.SetPosition(1, end);

        m_renderer.startWidth = 1;
        m_renderer.endWidth = 1;

        m_OGColour = colour;
        m_renderer.startColor = colour;
        m_renderer.endColor = colour;
    }


}
