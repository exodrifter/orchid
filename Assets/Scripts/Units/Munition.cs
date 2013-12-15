using UnityEngine;
using System.Collections;

public class Munition : MonoBehaviour {

    public Unit.UnitType targetType = Unit.UnitType.Air;

    public Color colour = Color.red;
    
    public float damage = 0.1f;

    public float attack_time = 0.3f;
    public float attack_time_variance = .1f;
    public float accuracy = 0.8f;
}
