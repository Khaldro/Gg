using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        if (GameObject.Find("Main Camera").GetComponent<Camera>().gameObject.activeSelf==true)
            GameObject.Find("Main Camera").SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
