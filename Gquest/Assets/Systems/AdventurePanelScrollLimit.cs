using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurePanelScrollLimit : MonoBehaviour {

	void Update () {
        if (gameObject.GetComponent<Transform>().position.y <= 290)
            gameObject.GetComponent<Transform>().position = new Vector3(240f, 290f, 0);
    }
}
