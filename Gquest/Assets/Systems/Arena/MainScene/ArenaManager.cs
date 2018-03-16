using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArenaManager : MonoBehaviour {
    
    private GameObject loginSignupPanel;
    
    private Button arenaButton;
	
    void Start()
    {
        loginSignupPanel = Resources.Load<GameObject>("LoginSignupPanel");
        arenaButton = Instantiate(Resources.Load<Button>("ArenaButton").GetComponent<Button>(),GameObject.Find("MiddleButtons").transform);

        arenaButton.onClick.AddListener(Arena);
    }

    private void Arena()
    {
        if (!Client.isAuthenticated)
        {
            Debug.Log("not authenticated");
            //Client.Connect();

            Instantiate(loginSignupPanel, transform);
        }
        else
        {
            if (Client.isConnected)
            SceneManager.LoadScene("ArenaScene");
            return;
        }
    }
}