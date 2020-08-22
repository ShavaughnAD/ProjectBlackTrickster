using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Resistances", menuName = "Damage Resistances")]
public class DamageResistance : ScriptableObject
{
    [System.Serializable]
    public struct Resistance
    {
        public DamageType damageType;
        public float resistPercentage; //100 = Base Damage, 0 = Immune
    }

    public List<Resistance> resistances = new List<Resistance>();

    public float CalculateDamageResistance(float damage, DamageType damageType)
    {
        for (int i = 0; i < resistances.Count; i++)
        {
            return ((damage * resistances[i].resistPercentage) / 100);
        }
        return 0;
    }
}
