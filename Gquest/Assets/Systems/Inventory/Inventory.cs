using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour {

    ItemDatabase itemDatabaseInstance;
    GameObject inventoryPanel;
    GameObject slotPanel;
    EnemyToFight enemyToFight;

    public GameObject inventorySlot;
    public GameObject inventoryItem;

    public List<Item> items = new List<Item>();
    public List<Item> DroppedItems = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    public Button delete;
    public Item item;
    //private bool DeleteItem = false;

    public static Inventory instance;
    

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
        if (DroppedItems != null)
            DroppedItems.Clear();

        UnityEngine.SceneManagement.SceneManager.activeSceneChanged += OnVictorySceneLoad;
        enemyToFight = Resources.Load<TempEnemy>("_TempEnemy").enemyToFight;
        ItemDatabase.Initialize();
        InitInventorySlots();
        //AddItem(1);
    }

    private void OnVictorySceneLoad(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.Scene arg1)
    {
        string activeScene = arg1.name;

        if (activeScene == "Victory")
        {
            ItemDrops();
            AddDroppedItems();
            DroppedItems.Clear();
        }
    }

    private void DeleteItems()
    {
       //         TODOOOOOOOOOO
        
        //Debug.Log(items[0].SLUG.ToString());
    }

    
    public void AddItem(int id)
    {
        Item itemToAdd = ItemDatabase.FetchItemByID(id);
        // add stackables - when deleting check if stackable and reduce amount, if amount 0 then delete item
        if (itemToAdd.STACKABLE && IsIteminInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.transform.GetChild(0).GetComponent<Text>().enabled = true;
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.GetComponent<Image>().sprite = itemToAdd.SPRITE;
                    itemObj.transform.position = Vector2.zero;
                    itemObj.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                    itemObj.GetComponent<RectTransform>().offsetMax = Vector2.zero;
                    itemObj.name = itemToAdd.TITLE;
                    break;
                }
            }
        }
    }


    public void InitInventorySlots()
    {
        int slotAmount = 20;
        inventoryPanel = GameObject.Find("InventoryPanel");
        slotPanel = inventoryPanel.transform.Find("SlotPanel").gameObject;

        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
        }
    }

    private void Update()
    {
        //Debug.Log(UnityEngine.EventSystems.EventSystem.current);
    }
        
    public void AddDroppedItems()
    {
        if (DroppedItems != null)
            for (int i = 0; i < DroppedItems.Count; i++)
                AddItem(DroppedItems[i].ID);
    }


    bool IsIteminInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i].ID == item.ID)
                return true;
        return false;
    } 

    private void ItemDrops()
    {
        try
        {
            for (int i = 0; i < enemyToFight.DropId.Count; i++)
            {
                int common = UnityEngine.Random.Range(0, 2);
                int uncommon = UnityEngine.Random.Range(0, 4);
                int rare = UnityEngine.Random.Range(0, 5);
                int legend = UnityEngine.Random.Range(0, 6);
                int epic = UnityEngine.Random.Range(0, 7);

                if (ItemDatabase.FetchItemByID(enemyToFight.DropId[i]).RARITY == "common")
                {

                    if (common == 1)
                    {
                        Inventory.instance.DroppedItems.Add(ItemDatabase.FetchItemByID
                            (enemyToFight.DropId[i]));
                    }
                }
                if (ItemDatabase.FetchItemByID(enemyToFight.DropId[i]).RARITY == "uncommon")
                {
                    
                    if (uncommon == 1)
                    {
                        Inventory.instance.DroppedItems.Add(ItemDatabase.FetchItemByID
                            (enemyToFight.DropId[i]));
                    }
                }
                if (ItemDatabase.FetchItemByID(enemyToFight.DropId[i]).RARITY == "rare")
                {
                   
                    if (rare == 1)
                    {
                        Inventory.instance.DroppedItems.Add(ItemDatabase.FetchItemByID
                            (enemyToFight.DropId[i]));
                    }
                }
                if (ItemDatabase.FetchItemByID(enemyToFight.DropId[i]).RARITY == "legend")
                {
                    
                    if (legend == 1)
                    {
                        Inventory.instance.DroppedItems.Add(ItemDatabase.FetchItemByID
                            (enemyToFight.DropId[i]));
                    }
                }
                if (ItemDatabase.FetchItemByID(enemyToFight.DropId[i]).RARITY == "epic")
                {
                    
                    if (epic == 1)
                    {
                        Inventory.instance.DroppedItems.Add(ItemDatabase.FetchItemByID
                            (enemyToFight.DropId[i]));
                    }
                }
            }
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
    }
}

public interface IInventory
{
    
    void AddDroppedItems();
}