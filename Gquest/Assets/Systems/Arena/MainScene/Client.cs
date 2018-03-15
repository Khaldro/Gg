using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.UI;
using System;

public class Client : MonoBehaviour
{

    private const int MAX_CONNECTIONS = 100;

    public static int myConnectionId =-1;
    
    private static int hostId;
    private static int reliableChannel;
    private static int unreliableChannel;
    private static byte error;

    public static bool isStarted = false;
    public static bool isConnected = false;
    public static bool isAuthenticated;

    private PlayerToFight playerToFight;
    public static PStats thisPlayer;



    public static List<string> PlayersToFightList = new List<string>();
    
    public static Client instance;
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
            Destroy(gameObject);
    }

    public void Start()
    {
        //__TEST_Delegates.MyEvent += EventSubTest;


        thisPlayer = Resources.Load<PStats>("pStats");
        playerToFight = Resources.Load<PlayerToFight>("_PlayerToFight");
    }

    //void EventSubTest()
    //{
    //    Debug.Log("RAISED!");
    //}



    public static void Connect()
    {
        if (isStarted)
            return;

        Application.runInBackground = true;
        // Init
        NetworkTransport.Init();

        // Config
        ConnectionConfig config = new ConnectionConfig();
        reliableChannel = config.AddChannel(QosType.Reliable);
        unreliableChannel = config.AddChannel(QosType.Unreliable);

        // Topology
        HostTopology topology = new HostTopology(config, MAX_CONNECTIONS);

        // Host (socket)
        hostId = NetworkTransport.AddHost(topology, 0);
        myConnectionId = NetworkTransport.Connect(hostId, "192.168.0.10", 8080, 0, out error);
        Debug.Log("connection error code: " + error);
        //isConnected = true;
        isStarted = true;
    }

    private void Update()
    {
        //TODO Listening
        if (!isStarted)
            return;

        int recHostId;
        int recConnectionId;
        int channelId;
        byte[] recBuffer = new byte[1024];
        int bufferSize = 1024;
        int dataSize;
        byte error;
        NetworkEventType recData = NetworkTransport.Receive(out recHostId, out recConnectionId,
            out channelId, recBuffer, bufferSize, out dataSize, out error);

        
        switch (recData)
        {
            
            case NetworkEventType.ConnectEvent:
                if (recHostId == hostId &&
                    recConnectionId == myConnectionId &&
                    (NetworkError)error == NetworkError.Ok)
                {
                    Debug.Log("Connected");
                    isConnected = true;
                }
                break;


            case NetworkEventType.DataEvent:       //3
                ReceiveData(recBuffer, recBuffer.Length);
                break;


            case NetworkEventType.DisconnectEvent: //4
                break;
        }
    }



    #region Send/Receive
    private void ReceiveData(byte[] buffer, int bufferLength)
    {
        byte[] receivedBuffer = buffer;

        string str = Encoding.Unicode.GetString(receivedBuffer, 0, bufferLength);
        str = str.Trim();
        string[] msg = str.Split('|');

        Routing(msg);
    }


    public static void SendData(string message)
    {
        int HostId = hostId;
        int connectionId = myConnectionId;

        byte[] sendBuffer = new byte[100];
        string str = message;
        sendBuffer = Encoding.Unicode.GetBytes(str);


        NetworkTransport.Send(HostId, myConnectionId, reliableChannel, sendBuffer, str.Length * sizeof(char), out error);
        Debug.Log("Data Sent : Error code " + error + "| Connection id: " + connectionId);
    }
    #endregion

    


    public void Routing( string[] msg)
    {
        
        switch (msg[0])
        {
            case "auth":
                IsLoggedIn(msg);
                break;
            case "rptf":
                AddRequestedPlayersToList(msg);
                break;
            case "shtdwn":
                Debug.Log(msg[0]);
                break;
            case "gptf":
                LoadArenaBattle(msg);
                break;
        }
    }

    private static void AddRequestedPlayersToList(string[] msg)
    {
        for (int i = 1; i < msg.Length; i++)
        {
            if (msg[i] != "")
                PlayersToFightList.Add(msg[i]);
        }
        PlayerPlaceHolder.Start();
        PlayerPlaceHolder.TempPlayersToFightList = PlayersToFightList;
    }

    private void LoadArenaBattle(string[] msg)
    {
        for (int i = 1; i < msg.Length - 1; i++)
        {
            playerToFight.stats.Add(msg[i]);
            Debug.Log(playerToFight.stats[i - 1]);
        }

        var TempEnemy = Resources.Load<TempEnemy>("_TempEnemy");
        TempEnemy.enemyToFight.Name = msg[1];
        TempEnemy.enemyToFight.MaxHp = int.Parse(msg[2]);
        TempEnemy.enemyToFight.Damage = int.Parse(msg[3]);
        TempEnemy.enemyToFight.Defense = int.Parse(msg[4]);
        TempEnemy.enemyToFight.Lvl = int.Parse(msg[5]);
        TempEnemy.enemyToFight.IsArenaPlayer = true;

        UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene1");
    }

    public static void SendBattleParameters(string thisPlayerName, string EnemyToFightName)
    {
        string message = string.Format("bp|{0}|{1}|", thisPlayerName, EnemyToFightName);
        SendData(message);
    }

    public static void LoginRequest(string Account, string Password)
    {
        SendData("auth|" + Account + "|" + Account + "|");
    }


    private void IsLoggedIn(string[] msg)
    {
        if (msg[1] == "success")
        {

            thisPlayer.NAME = msg[2];
            LoadArenaSceneUponLogin(isAuthenticated = true);
            SendThisPlayerStatsToServer();
        }
        else
        {
            if (msg[1] == "loggedin")
                LoadArenaSceneUponLogin(isAuthenticated = true);
        }
    }


    void SendThisPlayerStatsToServer()
    {
        SendData("rps|" + thisPlayer.name + "|" + thisPlayer.MAXHP.ToString() + "|" + thisPlayer.DMG.ToString() +
                    "|" + thisPlayer.DEF.ToString() +  "|" + thisPlayer.LVL.ToString() + "|" + thisPlayer.Exp.ToString() + "|");
    }


    public static void RequestPlayersToFight()
    {
        SendData("rptf|" + thisPlayer.NAME + "|" + thisPlayer.LVL + "|");
    }
    
    public static void GetPlayerToFight(string playerToFight)
    {
        SendData("gptf|" + playerToFight + "|" );
    }

    void LoadArenaSceneUponLogin(bool IsAuthenticated)
    {
        if (IsAuthenticated)
            UnityEngine.SceneManagement.SceneManager.LoadScene("ArenaScene");
    }

    private void OnApplicationQuit()
    {
        NetworkTransport.Shutdown();
    }
}