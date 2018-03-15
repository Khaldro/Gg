using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginSignup : MonoBehaviour {

    public InputField AccountField;
    public InputField PasswordField;

    public Text serverStatus;
    public Button login;
    public Button signup;

    Button[] ButtonsInBg;

    private void Awake()
    {
        ButtonsInBg = GameObject.Find("Panel").GetComponentsInChildren<Button>();
    }
    void Start () {
        

        if (Client.isConnected)
        {
            serverStatus.text = "(Local) Server Online";
            login.onClick.AddListener(Login);
        }
        else if(!Client.isConnected)
        {
            Client.Connect();
            serverStatus.text = "(Local) Server Online";
            login.onClick.AddListener(Login);
        }

	}

    private void Login()
    {
        //client.Connect();
        
        //if (Client.isStarted)
        {

            //Client.LoginRequest(AccountField.text, PasswordField.text);
            Client.SendData("auth|" + AccountField.text + "|" + PasswordField.text + "|");
        }
    }

    private void SetButtonsState(bool state)
    {
        for (int i = 0; i < ButtonsInBg.Length; i++)
            ButtonsInBg[i].interactable = state;
    }

    private void OnEnable()
    {
        SetButtonsState(false);
    }
    private void OnDestroy()
    {
        SetButtonsState(true);
    }
}
