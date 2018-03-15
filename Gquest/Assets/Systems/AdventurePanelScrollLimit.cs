using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurePanelScrollLimit : MonoBehaviour {

	void Update () {
        if ((int)gameObject.GetComponent<Transform>().position.y < 212)
            gameObject.GetComponent<Transform>().SetPositionAndRotation(new Vector3((int)240f, (int)212f, 0), Quaternion.identity);

        //if (gameObject.transform.position.y > gameObject.GetComponentsInChildren<Transform>()[1].position.y)
        //    gameObject.transform.SetPositionAndRotation(new Vector2(0, gameObject.GetComponentsInChildren<Transform>()[1].position.y), Quaternion.identity);

       
    }
}
