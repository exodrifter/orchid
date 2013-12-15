using UnityEngine;
using System.Collections;

public class Laser {
    private GameObject m_gameObject;
    private LineRenderer m_renderer;

    public Laser(Vector2 start, Vector2 end, Color colour)
    {
        m_gameObject = new GameObject();
        m_renderer = m_gameObject.AddComponent<LineRenderer>();

        m_renderer.SetPosition(0, start);
        m_renderer.SetPosition(1, end);

        m_renderer.SetWidth(.1f, .1f);

        m_renderer.SetColors(colour, colour);

        GameObject.Destroy(m_gameObject, 1.0f);
    }
}
