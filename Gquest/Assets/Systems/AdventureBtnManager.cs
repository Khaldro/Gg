using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class AdventureBtnManager : MonoBehaviour {
    public Button Area1, Area2, Area3;

	void Start () {

        Area1.onClick.AddListener(LoadArea);
	}


    private void Area1Task()
    {
        SceneManager.LoadScene("BattleScene1");
    }
    void LoadArea()
    {
        SceneManager.LoadScene("Area1");
    }
   
}
