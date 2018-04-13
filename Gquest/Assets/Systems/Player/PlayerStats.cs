using UnityEngine;

[UnityEngine.CreateAssetMenu]
public class CharacterStats : UnityEngine.ScriptableObject {

    private void OnEnable()
    {
        CalculateStats(lvl);
    }

    public TempEnemy tempEnemy;

    [SerializeField]
    private string name      { get; set ; }
    [SerializeField]
    private int maxHp = 100;
    private int currHp = 100;
    [SerializeField]
    private int damage = 50;
    [SerializeField]
    private int defense = 10;
    //------ NOT IMPLEMENTED ----------
    [SerializeField]
    private int evasion      { get; set; }
    [SerializeField]
    private int accuracy     { get; set; }
    [SerializeField]
    private int critChance   { get; set; }
    //---------------------------------
    [SerializeField]
    private int lvl = 1;
    [SerializeField]
    private float exp = 0;
    [SerializeField]
    private int lifedrain = 0;

    public string Name { get { return name; } set { name = value; } }
    public int MaxHp { get { return maxHp; } set { maxHp = value; } }
    public int CurrHp { get { return currHp; } set { currHp = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public int Defense { get { return defense; } set { defense = value; } }
    public int Evasion { get { return evasion; } set { evasion = value; } }
    public int Accuracy { get { return accuracy; } set { accuracy = value; } }
    public int CritChance { get { return critChance; } set { critChance = value; } }
    public int Lvl { get { return lvl; } set { lvl = value; } }
    public float Exp { get { return exp; } set { exp = value; } }
    public int Lifedrain { get { return lifedrain; } set { lifedrain = value; } }


    public void Attack()
    {
        tempEnemy.enemyToFight.CURRHP -= damage - tempEnemy.enemyToFight.Defense;
    }

    private void CalculateStats(int m_lvl)
    {
        Damage = StatsCalculator.DamageCalculation(m_lvl);
        Defense = StatsCalculator.DefenseCalculation(m_lvl);
        MaxHp = StatsCalculator.HealthCalculation(m_lvl);

    }
}
