using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginSignup : MonoBehaviour {

    public InputField AccountField;
    public InputField PasswordField;

    public Button login;
    public Button signup;
    public Text serverStatus;
    

	void Start () {
        if (Client.isConnected)
        {
            serverStatus.text = "(Local) Server Online";
            login.onClick.AddListener(Login);
            
        }
        else 
        {
            serverStatus.text = "(Local) Server Offline";

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
}
