
[UnityEngine.CreateAssetMenu]
public class CharacterStats : UnityEngine.ScriptableObject {
    public TempEnemy tempEnemy;

    public string NAME      { get; set ; }
    public int MAXHP = 100;
    public int CURRHP = 100;
    public int DMG = 50;
    public int DEF = 10;
    // --------- NOT IMPLEMENTED ----------
    public int EVASION      { get; set; }
    public int ACCURACY     { get; set; }
    public int CRITCHANCE   { get; set; }
    // ------------------------------------
    public int LVL = 1;
    public float EXP = 0;
    public int LIFEDRAIN = 0;

    public void Attack()
    {
        tempEnemy.enemyToFight.CURRHP -= DMG - tempEnemy.enemyToFight.Defense;

    }
}
