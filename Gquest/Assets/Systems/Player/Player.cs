using LitJson;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PStats player;
    public ExpManager expManager;
    public FirstGameLaunch firstGameLaunch;

    void Awake()
    {
        //FirstInit();
        expManager.Init();
    }
//    private void FirstInit()
//    {
//#if UNITY_EDITOR 
//        //firstGameLaunch.isFirstLaunch = true;
//#endif
        
//        if (!firstGameLaunch.isFirstLaunch == true) {
//            return;
//        }
            
//            player.MAXHP = 100;
//            player.CURRHP = 100;
//            player.DMG = 50;
//            player.DEF = 10;
//            player.LVL = 1;
//            player.Exp = 0;
//            player.CURRHP = player.MAXHP;
//            firstGameLaunch.isFirstLaunch = false;
//            Debug.Log(player.DMG);
            
//    }

    
#region Save/Load tests
    // ----------------------- Save Testing ------------------

    //public void JsonSave()
    //{
    //    JsonData data;

    //    data = JsonMapper.ToJson(player);
    //    File.WriteAllText(Application.persistentDataPath + "/playerdData.json", data.ToString());
    //}



    public string json;
    

    public void TestSave()
    {
      

        PlayerData data = new PlayerData();

        //data.invItemID[0] = Inventory.instance.items[0].ID;
       
         json = JsonUtility.ToJson(data);
        Debug.Log(json);
    }

    //public void TestLoad()
    //{
    //    Inventory.instance.items.Add(JsonUtility.FromJson<Item>(json));
    //    Debug.Log(Inventory.instance.items[0].SLUG);
    //}


    public void Save()
    {
        // C:\Users\Khaldro\AppData\LocalLow\DefaultCompany\Gquest

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.lvl = player.LVL;
      
        
        //data.item = Inventory.instance.items[0];
        
        //data.invItemID[0] =(Inventory.instance.items[0].ID);

        //for (int i = 0; i < DroppedItemsList.instance.DroppedItems.Count; i++)
        //{
        //    data.invItemID[0] = DroppedItemsList.instance.DroppedItems[i].ID;
        //}

        //Inventory.instance = data.inv;
        //data.item = Inventory.instance.items[0];
        //data.items = DroppedItemsList.instance.DroppedItems;

        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Save lvl " + data.lvl);
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            player.LVL = data.lvl;
            
            
            //Inventory.instance.items.Add(data.item);

            // Inventory.instance.AddItem(data.invID[0]);
            //for (int i = 0; i < data.invItemID.Length; i++)
            //{
            //    Inventory.instance.AddItem(data.invItemID[i]);
            //    Debug.Log(data.invItemID[i]);
            //}

            //Inventory.instance = data.inv;
            //Inventory.instance.items[0] = data.item;

            //Inventory.instance.AddDroppedItems();
            Debug.Log("load lvl " + data.lvl);
        }
        else
            Debug.Log("could not find save file");
    }
}

[Serializable]
class PlayerData
{
    public int lvl;
    //public int[] invItemID = new int[10];
    //public Item item = new Item();
    //public Weapon weapon = new Weapon();
}
#endregion
// -----------------------------------------------------------------


