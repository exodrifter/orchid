using UnityEngine;
using System.Collections;

public class Timer {
	
	private float m_time;
	private float m_elapsed;
	
	public float time {
		get {return m_time; }
	}
	
	public float elapsed {
		get { return m_elapsed; }
		set { m_elapsed = value; }
	}
	
	public Timer(float time = 0, float elapsed = 0) {
		m_time = time;
		m_elapsed = elapsed;
	}
	
	public bool HasElapsed() {
		return m_elapsed >= m_time;
	}
	
	/// <summary>
	/// Resets the elapsed time to 0.
	/// </summary>
	public void Reset() {
		m_elapsed = 0;
	}
	
	/// <summary>
	/// Subtracts the time amount from the elapsed time.
	/// </summary>
	public void SetBack() {
		m_elapsed -= m_time;
	}
}
