using UnityEngine;
using System.Collections;

public class UIUpgrade : MonoBehaviour {
	
	public int m_index = 0;
	
	private GameObject m_lvlText, m_helpText;
	public tk2dFontData m_font;
	private tk2dTextMesh m_lvlTextMesh, m_helpTextMesh;
	
	private Vector3 m_anchoredPosition;

    private bool m_showText;

    public UnitFactory m_unitFactory;

    public AudioClip m_buySound;
    public AudioClip m_failSound;
    public AudioClip m_hoverSound;

    MoneyEffect m_moneyEffect;

    private int count = 0;
	
	void Awake() {
		SetPosition(m_index);

		m_lvlText = MakeText("text-lvl", "", new Vector3(0, -5, -2), new Color(0.098f, 0.0784f, 0.0667f), 0.7f);
        m_helpText = MakeText("text-help", "$", new Vector3(0, 25, -2), Color.white);

        m_showText = false;

        m_lvlTextMesh = m_lvlText.GetComponent<tk2dTextMesh>();
        m_helpTextMesh = m_helpText.GetComponent<tk2dTextMesh>();

    }

    void Start(){
        m_moneyEffect = gameObject.AddComponent<MoneyEffect>();
    }

	
	void Update() {
        if(count >= 3){
            m_helpText.SetActive(false);
        }
        if(m_showText){
            switch (m_index){
                case 0:
                    m_lvlTextMesh.text = "Lvl " + m_unitFactory.m_icbmLevel;
                    m_helpTextMesh.text = "$" + State.COST_ICBM_UPGRADE; 
                    break;
                case 1:
                    m_lvlTextMesh.text = "Lvl " + m_unitFactory.m_bomberLevel;
                    m_helpTextMesh.text = "$" + State.COST_BOMBER_UPGRADE; 
                    break;
                case 2:
                    m_lvlTextMesh.text = "Lvl " + m_unitFactory.m_fighterLevel;
                    m_helpTextMesh.text = "$" + State.COST_FIGHTER_UPGRADE; 
                    break;
                default:
                    Debug.LogError("Invalid Upgrade UI index given for draw.");
                    break;
	        }
            m_lvlTextMesh.Commit();
        }
	}
	
	void OnMouseEnter() {
		transform.localPosition = m_anchoredPosition + new Vector3(0,10,0);
        m_showText = true;
        m_lvlText.SetActive(true);
        m_helpText.SetActive(true);
        AudioSource.PlayClipAtPoint(m_hoverSound,transform.position,0.7f);
	}

    void OnMouseDown(){
        switch (m_index){
            case 0:
                if(State.PlayerMoney > State.COST_ICBM_UPGRADE && count < 3){
                    m_unitFactory.m_icbmLevel++;
                    State.PlayerMoney -= State.COST_ICBM_UPGRADE;
                    AudioSource.PlayClipAtPoint(m_buySound,transform.position,0.7f);

                    count++;
                    m_moneyEffect.StartEffect(-State.COST_ICBM_UPGRADE);
                }
                else{
                    AudioSource.PlayClipAtPoint(m_failSound,transform.position,0.7f);
                }
                break;
            case 1:
                if(State.PlayerMoney > State.COST_BOMBER_UPGRADE  && count < 3){
                    m_unitFactory.m_bomberLevel++;
                    
                    State.PlayerMoney -= State.COST_BOMBER_UPGRADE;
                    AudioSource.PlayClipAtPoint(m_buySound,transform.position,0.7f);

                    count++;
                    m_moneyEffect.StartEffect(-State.COST_BOMBER_UPGRADE);
                }
                else{
                    AudioSource.PlayClipAtPoint(m_failSound,transform.position,0.7f);
                }
                break;
            case 2:
                if(State.PlayerMoney > State.COST_FIGHTER_UPGRADE  && count < 3){
                    m_unitFactory.m_fighterLevel++;
                    State.PlayerMoney -= State.COST_FIGHTER_UPGRADE;
                    AudioSource.PlayClipAtPoint(m_buySound,transform.position,0.7f);

                    count++;
                    m_moneyEffect.StartEffect(-State.COST_FIGHTER_UPGRADE);
                }
                else{
                    AudioSource.PlayClipAtPoint(m_failSound,transform.position,0.7f);
                }
                break;
            default:
                Debug.LogError("Invalid Upgrade UI index given for draw.");
                break;
	    }
    }
	
	void OnMouseExit() {
		transform.localPosition = m_anchoredPosition;
        m_showText = false;
        m_lvlText.SetActive(false);
        m_helpText.SetActive(false);
	}
	
	void SetPosition(int index) {
		m_anchoredPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-45-(60*index),10,0));
		transform.position = m_anchoredPosition;
		
		// Reset the local z position value
		m_anchoredPosition = transform.localPosition;
		m_anchoredPosition.z = 0;
		transform.localPosition = m_anchoredPosition;
		
		// Save the anchored position
		m_anchoredPosition = transform.localPosition;
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
