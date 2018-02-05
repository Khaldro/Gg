using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour {

	void Update () {
        if (gameObject.GetComponent<Transform>().position.y <= 140)
            gameObject.GetComponent<Transform>().position = new Vector3(-270, 140, 0);
    }
}
