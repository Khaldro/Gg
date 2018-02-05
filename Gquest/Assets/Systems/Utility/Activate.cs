using UnityEngine;
using UnityEngine.UI;

public class Activate : MonoBehaviour {

	void Start () {
        var toDisable = gameObject.GetComponentsInChildren<Button>();
        for (int i = 0; i < toDisable.Length; i++)
        {
            if(toDisable[i].interactable == false)
            toDisable[i].interactable = true;
        }
    }	
}