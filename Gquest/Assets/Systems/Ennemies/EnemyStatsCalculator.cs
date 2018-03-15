using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsCalculator {

    public int DamageCalculation(int m_lvl)
    {
        int baseDamage = 10;
        float exponent = 1.1f;

        int calculatedDamage = (int)Mathf.Pow(baseDamage * (m_lvl * 0.5f), exponent);
       
        return m_lvl == 1 ? baseDamage: calculatedDamage;

    }

    public int DefenseCalculation(int m_lvl)
    {
        int baseDefense = 5;
        float exponent = 1.1f;

        int CalculatedDefense = (int)Mathf.Pow(baseDefense * (m_lvl * 0.5f), exponent);

        return m_lvl == 1 ? baseDefense : CalculatedDefense;
    }

    public int ExpCalculation(int m_lvl)
    {
        int baseExp = 100;
        float exponent = 1.1f;

        int CalculatedExp = (int)Mathf.Pow(baseExp * (m_lvl * 0.5f), exponent);

        return m_lvl == 1 ? baseExp : CalculatedExp;
    }
}