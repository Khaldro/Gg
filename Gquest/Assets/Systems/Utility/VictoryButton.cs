using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class VictoryButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(TapToContinue);
	}

    public void TapToContinue()
    {
        SceneManager.LoadScene("Main");
    }
}
