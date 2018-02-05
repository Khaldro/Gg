using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System;
public class ItemDatabase {

    //public static ItemDatabase instance;
    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        DontDestroyOnLoad(gameObject);
    //        instance = this;
    //    }
    //    else if (instance != null)
    //        Destroy(gameObject);
    //}

    private static List<Item> database = new List<Item>();
    public Item WeaponToEquip;

    //private JsonData itemData;
    //WWW www;

    public static void Initialize () {

        //StartCoroutine(data());

        //Debug.Log(Application.persistentDataPath);
        //itemData = JsonMapper.ToObject(File.ReadAllText(Application.streamingAssetsPath + "/Items.json"));
        ConstructItemDatabase();
        //WeaponToEquip = database[0];
        
    }

     public static Item FetchItemByID(int id)
    {
        ConstructItemDatabase();
        for (int i = 0; i < database.Count; i++)
            if (database[i].ID == id)
                return database[i];
            return null;
    }

    private static void ConstructItemDatabase()
    {
        //var json = Resources.Load("/StreamingAssets/Items.json") as TextAsset;
        //var itemData = JsonMapper.ToObject(json.text);

        database.Add(new Item(0, "Bronze Sword", "bronze_sword", 5, true, "common"));
        database.Add(new Item(1, "Silver Sword", "silver_sword", 7, false, "uncommon"));
        database.Add(new Item(2, "Golden Sword", "golden_sword", 10, false, "rare"));

        database.Add(new Item(10, 20, "Weapon Shard", "weapon_shard", "common"));

        //for (int i = 0; i < itemData.Count; i++)
        //{
        //    database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(),
        //                               itemData[i]["slug"].ToString(), (int)itemData[i]["dmg"], (bool)itemData[i]["stackable"],
        //                               itemData[i]["rarity"].ToString()));

        //}
    }
    
    //IEnumerator data()
    //{
    //    //string filePath = "jar:file://" + Application.dataPath + "!/assets/Items.json";
    //    //var www = new WWW(filePath);
    //    //yield return www;
    //    //if (!string.IsNullOrEmpty(www.error))
    //    //{
    //    //    Debug.LogError("Can't read");
    //    //}

    //    //www = new WWW("jar:file://" + Application.dataPath + "!/assets/Items.json");
    //    //yield return www;
    //    //if (www.isDone == true)
    //    //{
    //    //    File.WriteAllBytes(Application.persistentDataPath + "/Items.json", www.bytes);

    //    //}
    //    //else
    //    //    Debug.Log("can't find");
    //}
}
//Defining Items

   // [Serializable]
public class Item
{
    public int ID           { get; set; }
    public string TITLE     { get; set; }
    public string SLUG      { get; set; }
    public int DMG          { get; set; }
    public int DEFENSE      { get; set; }
    public bool STACKABLE   { get; set; }
    public string RARITY    { get; set; }
    public Sprite SPRITE    { get; set; }

    public Item(int id, string title, string slug,int dmg, bool stackable, string rarity)
   
    {
        ID = id;
        TITLE = title;
        SLUG = slug;
        DMG = dmg;
        RARITY = rarity;
        STACKABLE = stackable;
       
        SPRITE = Resources.Load<Sprite>("Sprites/Items/" + slug);

    }

    // Weapon enchancer
    public Item(int id, int dmg, string title, string slug, string rarity)
    {
        ID = id;
        DMG = dmg;
        TITLE = title;
        SLUG = slug;
        RARITY = rarity;
        SPRITE = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }
    public Item()
    {
        ID = -1;
    }
}