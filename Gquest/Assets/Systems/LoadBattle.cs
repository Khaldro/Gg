using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadBattle : MonoBehaviour {

    public Button mob1, mob2, mob3;
    public TempEnemy tempEnemy;


    void Start () {
        mob1.GetComponent<Button>().onClick.AddListener(Mob1);
        mob2.GetComponent<Button>().onClick.AddListener(Mob2);
    }


    void Mob1()
    {
        LoadEnemyToFight("_Enemy1");
        SceneManager.LoadScene("BattleScene1");
    }
    void Mob2()
    {
        LoadEnemyToFight("_Enemy2");
        SceneManager.LoadScene("BattleScene1");
    }


    void LoadEnemyToFight(string name)
    {
        try
        {
            if (tempEnemy.enemyToFight != null)
                tempEnemy.enemyToFight = null;

                tempEnemy.enemyToFight = Resources.Load<EnemyToFight>(name);
            tempEnemy.enemyToFight.IsArenaPlayer = false;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }
    

    public void Unload(){
        Destroy(gameObject);
    }
}
