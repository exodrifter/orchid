using UnityEngine;
using System.Collections;

public class Munition : MonoBehaviour {

    public Unit.UnitType targetType = Unit.UnitType.Air;

    public Color colour = Color.red;
    
    public float damage = 10.0f;

    public float attack_time = 1.0f;
    public float attack_time_variance = 1.0f;
}
