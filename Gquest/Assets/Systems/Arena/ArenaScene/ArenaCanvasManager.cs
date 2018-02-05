using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaCanvasManager : MonoBehaviour
{
    Button BattleButton;
    Button RefreshButton;

    public GameObject SelectPlayersToFightPanel;

	void Start ()
    {
        BattleButton = GameObject.Find("BattleButton").GetComponent<Button>();
        BattleButton.onClick.AddListener(SelectPlayersToFightPanelState);


    }

    private void RefreshPlayersToFight()
    {

        Client.RequestPlayersToFight();
    }

    private void SelectPlayersToFightPanelState()
    {
        if(SelectPlayersToFightPanel.gameObject.activeSelf==false)
        {
            SelectPlayersToFightPanel.gameObject.SetActive(true);
            RefreshButton = GameObject.Find("RefreshButton").GetComponent<Button>();
            RefreshButton.onClick.AddListener(RefreshPlayersToFight);
            

            Client.RequestPlayersToFight();
        }
    }

    
}
