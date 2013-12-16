using UnityEngine;
using System.Collections;

public class UIUnit : MonoBehaviour {
	
	public AudioClip m_buySound;
	
	private UIFab m_fab;
	private Entity.Type m_type;
	
    public MoneyEffect m_moneyEffect;

	public UIFab fab {
		get { return m_fab; }
		set { m_fab = value; }
	}
	
	public Entity.Type type {
		get { return m_type; }
		set { m_type = value; }
	}

    void Start(){
        m_moneyEffect = gameObject.AddComponent<MoneyEffect>();
    }

	
	void OnMouseDown() {
		if(State.PlayerMoney >= State.GetCostOf(m_type)) {
			State.PlayerMoney -= State.GetCostOf(m_type);
			m_fab.AddToSpawnList(m_type);
			AudioSource.PlayClipAtPoint(m_buySound,transform.position,0.7f);
            m_moneyEffect.StartEffect(-State.GetCostOf(m_type));
        }
	}
}
