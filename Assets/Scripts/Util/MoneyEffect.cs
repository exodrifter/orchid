using UnityEngine;
using System.Collections;

public class MoneyEffect : MonoBehaviour {

    public tk2dFontData m_font = State.instance.defaultFont;
    public Color getColour = Color.green;
    public Color giveColour = Color.red;

    private Transform m_parent;
    private Vector2 m_offset;
    
    public IEnumerator Effect(GameObject effect)
    {
        effect.SetActive(true);
        for (int i = 0; i < 30; i++)        {
            effect.transform.position = effect.transform.position + new Vector3(0, .3f, 0);

            yield return 30;
        }
        GameObject.Destroy(effect);
    }

    public void StartEffect(int amount){
        GameObject effect = MakeText(amount);
        StartCoroutine(Effect(effect));
    }

    void Awake(){
        m_parent = transform;
    }

    public void SetParent(Transform parent){
        m_parent = parent;
    }

     public void SetOffset(Vector2 offset){
        m_offset = offset;
    }

    GameObject MakeText(int amount) {
		string amountString = (amount > 0 ? "+ " : "") + amount;
        
        GameObject ret = new GameObject();		
		ret.transform.parent = m_parent;
		ret.transform.localPosition = m_offset;
        ret.name = amountString;
		ret.SetActive(false);
		
		tk2dTextMesh mesh = ret.AddComponent<tk2dTextMesh>();
		mesh.font = m_font;
		mesh.text = amountString;
        mesh.color = amount > 0 ? getColour : giveColour;
		mesh.maxChars = 20;
		mesh.anchor = TextAnchor.MiddleCenter;
		mesh.Commit();
		
		return ret;
	}
}
