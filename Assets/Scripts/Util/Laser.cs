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
            m_renderer.SetColors(c, c);
            yield return 0;
        }
        GameObject.Destroy(m_gameObject);
    }

    
    public Laser(Vector2 start, Vector2 end, Color colour)
    {
        m_gameObject = new GameObject();
        m_renderer = m_gameObject.AddComponent<LineRenderer>();
        m_renderer.material = new Material(Shader.Find("Particles/Additive (Soft)"));

        m_renderer.SetPosition(0, start);
        m_renderer.SetPosition(1, end);

        m_renderer.SetWidth(.3f, .1f);

        m_OGColour = colour;
        m_renderer.SetColors(colour, colour);
    }


}
