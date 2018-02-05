using UnityEngine;
using UnityEngine.UI;

public class AdventureBtnManager : MonoBehaviour {
    public Button Btn_Area1, Btn_Area2, Btn_Area3;
    public GameObject Area_1;

    void Start ()
    {
        Btn_Area1.GetComponent<Button>().onClick.AddListener(LoadArea);
    }

    void LoadArea()
    {
        Area_1.SetActive(true);
    }
   
}
