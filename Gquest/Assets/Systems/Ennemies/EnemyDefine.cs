using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefine : MonoBehaviour {

    public static EnemyDefine instance;

    public BaseEnemy enemy1;
    public BaseEnemy enemy2;
    public BaseEnemy enemy3;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
            Destroy(gameObject);

        enemy1 = new BaseEnemy(100, 35, 10, "Enemy1",new int[] {0,1,2},100);
        enemy2 = new BaseEnemy(100, 10, 5, "Enemy2", new int[] {10},100);  
    }
}

public class BaseEnemy
{
    public float MAXHP  { get; set; }
    public float CURRHP { get; set; }
    public int DMG      { get; set; }
    public int DEF      { get; set; }
    public string NAME  { get; set; }
    public int[] DROPID { get; set; }
    public int GIVEEXP  { get; set; }

    public BaseEnemy(int maxHp, int dmg, int def, string name,int[] dropid, int giveexp)
    {
        MAXHP = maxHp;
        CURRHP = MAXHP;
        DMG = dmg;
        DEF = def;
        NAME = name;
        GIVEEXP = giveexp;
        DROPID = dropid;
    }
    public void OnKill()
    {
        
    }
    
}