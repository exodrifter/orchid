using UnityEngine;
using System.Collections;

public class MenuUI : MonoBehaviour {

    public tk2dFontData m_font = State.instance.defaultFont;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    public IEnumerator HideEffect()
    {
        for (int i = 0; i < 30; i++)        {
            transform.position = transform.position - new Vector3(0, -1, 0);
            yield return 30;
        }        
    }

    private GameObject MakeText(string name, string text, Vector3 offset, Color color, float scale = 1) {
		GameObject ret = new GameObject();
		ret.name = name;
		ret.transform.parent = this.transform;
		ret.transform.localPosition = offset;
		ret.SetActive(false);
		
		tk2dTextMesh mesh = ret.AddComponent<tk2dTextMesh>();
		mesh.font = m_font;
		mesh.text = text;
        mesh.color = color;
        mesh.scale = new Vector3(scale, scale, 1);
		mesh.maxChars = 20;
		mesh.anchor = TextAnchor.MiddleCenter;
		mesh.Commit();
		
		return ret;
	}
}
