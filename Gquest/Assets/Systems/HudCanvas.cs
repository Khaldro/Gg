/* //------------------------------------------------
 * Main Menu UI Buttons Manager
 */ //----------------------------------------------- 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class HudCanvas : MonoBehaviour
{
    public Button MainMenuButton, EquipmentButton, InventoryButton, ShopButton;

    public static HudCanvas instance;
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

    void Start () {
        //MainMenuButton.GetComponent<Button>().onClick.AddListener(BackToMainMenu);
        //EquipmentButton.GetComponent<Button>().onClick.AddListener(OpenEquipment);
        //InventoryButton.GetComponent<Button>().onClick.AddListener(OpenInventory);
    }

    private void OpenInventory()
    {
        GameObject.Find("Camera").transform.position = new Vector3(-271,400,-10);
        if (SceneManager.GetActiveScene().name == "Victory")
             SceneManager.LoadScene("Main");
        
    }

    private void OpenEquipment()
    {
        GameObject.Find("Camera").transform.position = new Vector3(758, 400, -10);
        if (SceneManager.GetActiveScene().name == "Victory")
            SceneManager.LoadScene("Main");

    }
    
    private void BackToMainMenu()
    {
        SceneManager.LoadScene("Main");
    }

    private void AdventureTask()
    {
        //SceneManager.LoadScene("Adventure");
                     Debug.Log("Adventure");
        
        //if (GameObject.Find("Area1Canvas"))
        //{
        //    GameObject.Find("Area1Canvas").GetComponent<load>().Unload();
        //}
    }
}