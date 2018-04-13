using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu]
public class ExpManager : ScriptableObject {

    public PStats playerStats;
    public GameObject Experience;
    public GameObject Level;
    public GameObject NextLvl;
    public GameObject ExpBar;


    public void Init()
    {
        ExpForNextLvl();
        LvlUp();
        ExpDisplayUpdate();
        //TestLoad();
        // Load();
    }
    

    public float ExpForNextLvl()
    {
        return Mathf.Round((400 * Mathf.Pow(playerStats.LVL, 1.5f) - 400 * playerStats.LVL) + 400);
    }


    public void LvlUp()
    {
        if (playerStats.Exp >= ExpForNextLvl())
        {
            playerStats.LVL += 1;
            playerStats.Exp = 0f;
            ExpForNextLvl();
        }
    }


    public void ExpDisplayUpdate()
    {
        //try
        {
            GameObject.Find("Level").GetComponent<Text>().text = "Level " + playerStats.LVL;
            GameObject.Find("Experience").GetComponent<Text>().text = ((playerStats.Exp / ExpForNextLvl() * 100)).ToString() + "%";
            //GameObject.Find("NextLvl").GetComponent<Text>().text = "NextLvl " + ExpForNextLvl();
            GameObject.Find("ExpBar").GetComponent<Image>().fillAmount = playerStats.Exp / ExpForNextLvl();
        }
        //catch(System.Exception e)
        //{
        //    Debug.Log(e);
        //}
    }
}
