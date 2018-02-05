using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquippedWeapon : MonoBehaviour, IPointerClickHandler {
    
    Item weapon;
    public CharacterStats player;
    public Weapon weaponPrefab = new Weapon();

void Start () {

        //weapon = GameObject.Find("EquipmentPanel").GetComponent<Equipment>().EquippedWeapon;
        //player = HeroDefine.instance.player;
        //player = GameObject.Find("Player").GetComponent<Player>().player;

        weaponPrefab.w_dmg = 10;

        player.DMG += weaponPrefab.w_dmg;
        StatInit();


        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Items/" + weaponPrefab.w_Sprite);
	}

    public void StatInit()
    {
        
        weaponPrefab.w_title = "Sword";
        weaponPrefab.w_Quality = "Poor";
        weaponPrefab.w_Sprite = "bronze_sword";

        GameObject.Find("WeaponText").GetComponent<Text>().text = weaponPrefab.w_Quality + " " + weaponPrefab.w_title
           + "\nDamage " + weaponPrefab.w_dmg;
    }

    public void ApplyStatsToPlayer()
    {
        player.DMG += weaponPrefab.w_dmg;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log(weapon.RARITY + " " + weapon.TITLE );
        StatInit();
    }
}

//[Serializable]
public class Weapon
{
    public string w_title { get; set; }
    public string w_Quality { get; set; }
    public int w_dmg { get; set; }
    public int w_crit { get; set; }
    public int w_acc { get; set; }

    public string w_Sprite { get; set; }
}
