using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class AdventureBtnManager : MonoBehaviour {
    //public Button Area1, Area2, Area3, Area4, Area5, Area6, Area7, Area8, Area9;
    public GameObject Area1Panel;
    
    public List<Button> AreaButtons = new List<Button>();

    void Start () {
        foreach (var item in AreaButtons)
        {
            int i = 0;
            AreaButtons[i].onClick.AddListener(LoadArea);
            i++;
        }
    }

    private void Area1Task()
    {
        SceneManager.LoadScene("BattleScene1");
    }
    private void LoadArea()
    {
        if(Area1Panel.activeSelf == false)
        {
            Area1Panel.SetActive(true);
        }
    }
}