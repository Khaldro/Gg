using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyToFight : ScriptableObject
{
    StatsCalculator enemyStatsCalculator;
    private void OnEnable()
    {
        CalculateStats(Lvl);
    }

    private bool isArenaPlayer;
    private float currHp = 0;

    [SerializeField]
    private float maxHp = 100;
    [SerializeField]
    private string name1 = string.Empty;
    [SerializeField]
    private int lvl = 0;
    [SerializeField]
    private int damage = 0;
    [SerializeField]
    private int defense = 0;
    [SerializeField]
    private int expAmount = 0;
    [SerializeField]
    private List<int> dropId = new List<int>();


    public bool IsArenaPlayer { get { return isArenaPlayer; }  set { isArenaPlayer = value; } }
    public int ExpAmount { get { return expAmount; }  set { expAmount = value; } }
    public int Defense { get { return defense; }  set { defense = value; } }
    public float CURRHP { get { return currHp; }  set { currHp = value; } }
    public int Damage { get { return damage; }  set { damage = value; } }
    public float MaxHp { get { return maxHp; }  set { maxHp = value; } }
    public string Name { get { return name1; }  set { name1 = value; } }
    public int Lvl { get { return lvl; }  set { lvl = value; } }

    
    private void CalculateStats(int m_lvl)
    {
        Damage = StatsCalculator.DamageCalculation(m_lvl);
        Defense = StatsCalculator.DefenseCalculation(m_lvl);
        MaxHp = StatsCalculator.HealthCalculation(m_lvl);
        ExpAmount = StatsCalculator.ExpCalculation(m_lvl);
    }

    public int DropId(int i)
    {
        return dropId[i];
    }
    public int DropIdCount()
    {
        return dropId.Count;
    }
}
