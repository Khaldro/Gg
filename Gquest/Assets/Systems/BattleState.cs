using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class BattleState : MonoBehaviour {

    public PStats player;
    public ExpManager expManager;
    public TempEnemy tempEnemy;
    private EnemyToFight enemyToFight;
    private float battleSpeed = 0.4f;

    void Start()
    {
        try
        {
            enemyToFight = tempEnemy.enemyToFight;
            Client.SendBattleParameters(player.NAME, enemyToFight.Name);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        if(tempEnemy.enemyToFight.IsArenaPlayer)
        Debug.Log(tempEnemy.enemyToFight.IsArenaPlayer);
        //Debug.Log(SceneTracker.ActiveScene);
        resetHp();
        StartBattle();
    }

    
    private IEnumerator Battle()
    {
        yield return new WaitForSeconds(0f);
        EnemyHpUpdate();
        PlayerHpUpdate();

        Start:
        
              
        /////////////////////////////////////////////////////
        ///Player Turn
        if (enemyToFight.CURRHP > 0 && player.CURRHP > 0)
        {
            yield return new WaitForSeconds(battleSpeed);
            player.Attack();
            EnemyHpUpdate();

            if (IsEnemyDead())
            {
                EndBattle();
            }
            /////////////////////////////////////////////////////////
            ///Enemy Turn
            else if (!IsPlayerDead() && !IsEnemyDead()) // Enemy attacks
            {
                yield return new WaitForSeconds(battleSpeed);
                player.CURRHP -= enemyToFight.Damage;
                Debug.Log(enemyToFight.Damage);
                PlayerHpUpdate();
                ////////////////////////////////////////////////////////////


                if (IsPlayerDead())
                {
                    GameOverScene();
                }

                goto Start;

            }
        }
    }


    private bool IsEnemyAlive()
    {
        return enemyToFight.CURRHP >= 0;
    }


    private bool IsPlayerDead()
    {
        return player.CURRHP <= 0;
    }


    private bool IsEnemyDead()
    {
        return enemyToFight.CURRHP <= 0;
    }


    private void EndBattle()
    {

        player.Exp += enemyToFight.ExpAmount;

        try
        {
            Inventory.instance.AddDroppedItems();
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        //HeroDefine.instance.Save();

        VictoryScene();
    }

    private void resetHp()
    {
        enemyToFight.CURRHP = enemyToFight.MaxHp;
        player.CURRHP = player.MAXHP;
    }
    private void StartBattle()
    {
        StartCoroutine(Battle());
    }
    private void VictoryScene()
    {
        SceneManager.LoadScene("Victory");
    }
    private void GameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
   
    private void EnemyHpUpdate()
    {
        GameObject.Find("EnemyHP").GetComponent<Image>().fillAmount = (float)enemyToFight.CURRHP / (float)enemyToFight.MaxHp;
        GameObject.Find("EHpAmount").GetComponent<Text>().text = enemyToFight.CURRHP.ToString();
        GameObject.Find("EnemyName").GetComponent<Text>().text = enemyToFight.Name + " Lvl " + enemyToFight.Lvl;
    }


    private void PlayerHpUpdate()
    {
        GameObject.Find("HeroHP").GetComponent<Image>().fillAmount = (float)player.CURRHP / (float)player.MAXHP;
        GameObject.Find("HHpAmount").GetComponent<Text>().text = player.CURRHP.ToString();
        GameObject.Find("HeroName").GetComponent<Text>().text = player.NAME + " Lvl " + player.LVL;
    }


}