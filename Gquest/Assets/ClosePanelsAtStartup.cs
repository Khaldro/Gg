using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelsAtStartup : MonoBehaviour {

    GameObject adventurePanel, inventoryPanel, equipmentPanel;
    GameObject[] areaPanel;
    List<GameObject> PanelsToClose = new List<GameObject>();

    private void Start()
    {
        adventurePanel = GameObject.FindGameObjectWithTag("Adventure");
        inventoryPanel = GameObject.FindGameObjectWithTag("Inventory");
        equipmentPanel = GameObject.FindGameObjectWithTag("Equipment");
        areaPanel      = GameObject.FindGameObjectsWithTag("Area");

        PanelsToClose.Add(adventurePanel);
        PanelsToClose.Add(inventoryPanel);
        PanelsToClose.Add(equipmentPanel);

        foreach (var panel in areaPanel)
        {
            PanelsToClose.Add(panel);
        }

        for (int i = 0; i < PanelsToClose.Count; i++)
        {
            if(PanelsToClose[i] != null)
            PanelsToClose[i].SetActive(false);
        }
    }
}
