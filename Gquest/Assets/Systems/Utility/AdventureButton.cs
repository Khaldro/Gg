using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdventureButton : MonoBehaviour {
    public Button Adventure;
    public GameObject AdventureCanvas;
    // Use this for initialization
    void Start () {
        Adventure.GetComponent<Button>().onClick.AddListener(AdventureTask);
    }

    void AdventureTask()
    {
        AdventureCanvas.SetActive(true);
        //SceneManager.LoadScene("Adventure");

    }
}
