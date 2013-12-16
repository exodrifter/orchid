using UnityEngine;
using System.Collections;

public class MenuUI : MonoBehaviour {

    public tk2dFontData m_font = State.instance.defaultFont;

    public AudioClip m_hoverSound;
    public AudioClip m_leaveSound;
    public AudioClip m_clickSound;

    private enum state{off, hover, clicked};
    state m_buttonState = state.off;

	// Use this for initialization
	void Start () {
	    BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();
	    boxCollider.size = gameObject.GetComponent<tk2dSprite>().GetBounds().size;
    }

    void Update() {
        switch (m_buttonState)
        {
            case state.off:
                GetComponent<tk2dSprite>().SetSprite("start-button-default");
                break;
            case state.hover:
                GetComponent<tk2dSprite>().SetSprite("start-button-hover");
                break;
            case state.clicked:
                GetComponent<tk2dSprite>().SetSprite("start-button-click");
                break;
            default:
                break;
        }
    }
	
    public IEnumerator LoadLevel()
    {
        for (int i = 0; i < 30; i++)        {
            yield return 0;
        }
        Application.LoadLevel("test");
    }

    void OnMouseDown(){
        if(m_buttonState != state.clicked){
            AudioSource.PlayClipAtPoint(m_clickSound,transform.position,0.7f);
            m_buttonState = state.clicked;
        }
        StartCoroutine(LoadLevel());
    }

	void OnMouseEnter(){
        if(m_buttonState != state.clicked){
            AudioSource.PlayClipAtPoint(m_hoverSound,transform.position,0.7f);
            m_buttonState = state.hover;
        }
    }

    void OnMouseExit(){
        if(m_buttonState != state.clicked){
            AudioSource.PlayClipAtPoint(m_leaveSound,transform.position,0.7f);
            m_buttonState = state.off;
        }
    }
}
