using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsInit : MonoBehaviour {

    GameObject slotPanel;
    public GameObject inventorySlot;
    GameObject inventoryPanel;
    public List<Item> items = new List<Item>();
    public static List<GameObject> slots = new List<GameObject>();

    private void Start()
    {
        InitInventorySlots();
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
            slots[i].transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
