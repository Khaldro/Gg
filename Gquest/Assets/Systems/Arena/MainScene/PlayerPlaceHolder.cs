using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlaceHolder {
    public static PStats PlayertoFightOne;
    public static PStats PlayertoFightTwo;
    public static PStats PlayertoFightThree;

    public static GameObject PlayerPlaceHolderOne;
    public static GameObject PlayerPlaceHolderTwo;
    public static GameObject PlayerPlaceHolderThree;

    static Text PlayerOneLevel;
    static Text PlayerTwoLevel;
    static Text PlayerThreeLevel;

    static Text PlayerOneName;
    static Text PlayerTwoName;
    static Text PlayerThreeName;

    static Button GOone;
    static Button GOtwo;
    static Button GOthree;
    
    public static List<string> TempPlayersToFightList = new List<string>();

    public static void Start()
    {
        PlayerPlaceHolderOne = GameObject.Find("PlayerPlaceHolderOne");
        PlayerPlaceHolderTwo = GameObject.Find("PlayerPlaceHolderTwo");
        PlayerPlaceHolderThree = GameObject.Find("PlayerPlaceHolderThree");

        PlayerOneLevel = PlayerPlaceHolderOne.GetComponentsInChildren<Text>()[0];
        PlayerTwoLevel = PlayerPlaceHolderTwo.GetComponentsInChildren<Text>()[0];
        PlayerThreeLevel = PlayerPlaceHolderThree.GetComponentsInChildren<Text>()[0];

        PlayerOneName = GameObject.Find("PlayerPlaceHolderOne").GetComponentsInChildren<Text>()[1];
        PlayerTwoName = GameObject.Find("PlayerPlaceHolderTwo").GetComponentsInChildren<Text>()[1];
        PlayerThreeName = GameObject.Find("PlayerPlaceHolderThree").GetComponentsInChildren<Text>()[1];

        GOone = PlayerPlaceHolderOne.GetComponentInChildren<Button>();
        GOtwo = PlayerPlaceHolderTwo.GetComponentInChildren<Button>();
        GOthree = PlayerPlaceHolderThree.GetComponentInChildren<Button>();

        DisposeListeners();
        GOone.onClick.AddListener(GetPlayerToFightOne);
        GOtwo.onClick.AddListener(GetPlayerToFightTwo);
        GOthree.onClick.AddListener(GetPlayerToFightThree);

        UpdatePlayersToFight();
    }





    
#region Get Players to fight Names || Go Buttons Implementation ---------------------------------

    public static void GetPlayerToFightOne()
    {
        Client.GetPlayerToFight(PlayerOneName.text);

    }

    private static void GetPlayerToFightTwo()
    {
        Client.GetPlayerToFight(PlayerTwoName.text);
    }

    private static void GetPlayerToFightThree()
    {
        Client.GetPlayerToFight(PlayerThreeName.text);
    }
#endregion --------------------------------------------------

    private static void RefreshPlayersToFight()
    {
        Client.RequestPlayersToFight();
    }
    
    private static void DisposeListeners()
    {
        GOone.onClick.RemoveListener(GetPlayerToFightOne);
        GOtwo.onClick.RemoveListener(GetPlayerToFightTwo);
        GOthree.onClick.RemoveListener(GetPlayerToFightThree);
    }
    
    public static void UpdatePlayersToFight()
    {
        ResetPlaceHolders();

        TempPlayersToFightList = Client.PlayersToFightList;

        if (Client.PlayersToFightList.Count == 2 || Client.PlayersToFightList.Count == 3)
        {
            PlayerOneName.text = Client.PlayersToFightList[0];
            PlayerOneLevel.text = "Lvl " + Client.PlayersToFightList[1];
        }
        else if (Client.PlayersToFightList.Count == 4 || Client.PlayersToFightList.Count == 5)
        {
            PlayerOneName.text = Client.PlayersToFightList[0];
            PlayerOneLevel.text = "Lvl " + Client.PlayersToFightList[1];
            PlayerTwoName.text = Client.PlayersToFightList[2];
            PlayerTwoLevel.text = "Lvl " + Client.PlayersToFightList[3];
        }
        else if (Client.PlayersToFightList.Count >= 6)
        {
            PlayerOneName.text = Client.PlayersToFightList[0];
            PlayerOneLevel.text = "Lvl " + Client.PlayersToFightList[1];
            PlayerTwoName.text = Client.PlayersToFightList[2];
            PlayerTwoLevel.text = "Lvl " + Client.PlayersToFightList[3];
            PlayerThreeName.text = Client.PlayersToFightList[4];
            PlayerThreeLevel.text = "Lvl " + Client.PlayersToFightList[5];
        }
        else Debug.Log("Error in UpdatePlayersToFight() 'if'...'else' conditions");

        Client.PlayersToFightList.RemoveRange(0, Client.PlayersToFightList.Count);
    }
    
    internal static void ResetPlaceHolders()
    {

        PlayerOneName.text = "xxx";
        PlayerOneLevel.text = "xxx";
        PlayerTwoName.text = "xxx";
        PlayerTwoLevel.text = "xxx";
        PlayerThreeName.text = "xxx";
        PlayerThreeLevel.text = "xxx";
    }
}
