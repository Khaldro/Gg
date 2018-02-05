using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour {
    public GameObject Slot;
    public GameObject Weapon;
    public Item EquippedWeapon;
    

	void Start () {



        //GameObject.Find("Sword").GetComponent<ItemData>().item = EquippedWeapon;

        // EquippedWeapon = ItemDatabase.instance.WeaponToEquip;

        // WeaponObj.GetComponent<Image>().sprite = EquippedWeapon.SPRITE;
        InitWeapon();
    }

    public void InitWeapon()
    {
        GameObject WeaponSlot = Instantiate(Slot, GameObject.Find("WeaponPlaceHolder").transform);
        WeaponSlot.transform.position = GameObject.Find("WeaponPlaceHolder").transform.position;

        GameObject WeaponObj = Instantiate(Weapon, WeaponSlot.transform);

        WeaponObj.name = "Sword";
    }
}
