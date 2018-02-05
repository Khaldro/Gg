using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemData : MonoBehaviour, IPointerClickHandler {
    public Item item;
    public int amount;

    private void Start()
    {
        //gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Items" + item.SLUG);
    }

    //public void StatsUpdate()
    //{
    //    GameObject.Find("Sword").GetComponent<EquippedWeapon>().weaponPrefab.w_dmg += item.DMG;
    //    GameObject.Find("Sword").GetComponent<EquippedWeapon>().StatInit();
    //    GameObject.Find("Sword").GetComponent<EquippedWeapon>().ApplyStatsToPlayer();
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        if(item.TITLE == "Weapon Shard")
        {
            //StatsUpdate();
        }
    }
}