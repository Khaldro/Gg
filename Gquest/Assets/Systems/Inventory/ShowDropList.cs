using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowDropList : MonoBehaviour {
    public GameObject item;
    
    void Start () {
        try
        {
            for (int i = 0; i < Inventory.instance.DroppedItems.Count; i++)
            {
                GameObject ItemToDisplay = Instantiate(item);
                ItemToDisplay.transform.SetParent(GameObject.Find("DropList").transform);
                ItemToDisplay.GetComponent<Image>().sprite = Inventory.instance.DroppedItems[i].SPRITE;

            }
        }
        catch(System.Exception e)
        {
            Debug.Log(e);
        }
    }
}