using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyToFight : ScriptableObject
{

    private bool isArenaPlayer;
    private string name1 = string.Empty;
    private float maxHp = 100;
    private int expAmount = 0;
    private float cURRHP = 0;
    private int defense = 0;
    private int damage = 0;
    private int lvl = 0;

    public List<int> DropId = new List<int>();



    public bool IsArenaPlayer { get { return isArenaPlayer; } set { isArenaPlayer = value; } }
    public int ExpAmount { get { return expAmount; } set { expAmount = value; } }
    public int Defense { get { return defense; } set { defense = value; } }
    public float CURRHP { get { return cURRHP; } set { cURRHP = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public float MaxHp { get { return maxHp; } set { maxHp = value; } }
    public string Name { get { return name1; } set { name1 = value; } }
    public int Lvl { get { return lvl; } set { lvl = value; } }

}
