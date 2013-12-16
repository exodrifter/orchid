using UnityEngine;
using System.Collections;

public class MoneyEffect : MonoBehaviour {

    public tk2dFontData m_font = State.instance.defaultFont;
    public Color getColour = Color.green;
    public Color giveColour = Color.red;


    public IEnumerator Effect(GameObject effect)
    {
        //Color color = effect.GetComponent<tk2dTextMesh>().color;
        effect.SetActive(true);
        for (int i = 0; i < 30; i++)        {
            effect.transform.position = effect.transform.position + new Vector3(0, .3f, 0);
            
            //Color color = effect.GetComponent<tk2dTextMesh>().color;
            //color.a = color.a - 1/30;
            //effect.GetComponent<tk2dTextMesh>().color = color;
            //effect.GetComponent<tk2dTextMesh>().Commit();

            yield return 30;
        }
        GameObject.Destroy(effect);
    }

    public void StartEffect(int amount){
        GameObject effect = MakeText(amount);
        StartCoroutine(Effect(effect));
    }

    GameObject MakeText(int amount) {
		string amountString = (amount > 0 ? "+ " : "") + amount;
        
        GameObject ret = new GameObject();		
		ret.transform.parent = this.transform;
		ret.transform.localPosition = new Vector3(0, 0, 0);
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
