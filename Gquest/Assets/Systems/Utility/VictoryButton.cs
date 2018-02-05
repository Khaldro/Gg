using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class VictoryButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(TapToContinue);
	}

    private void TapToContinue()
    {
        SceneManager.LoadScene("Main");
    }
}
