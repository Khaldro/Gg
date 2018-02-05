using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName =("GUIButtonsImplementation"), menuName = "GUIButtonsImplementation")]
public class ButtonsImplementation : ScriptableObject {

    
    GameObject Adventure;
    GameObject LoginPanel;
    
    private void OnEnable()
    {
        
    }


    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void BackToMainMenu()
    {
        if( GetActiveSceneName() != "Main" )
            LoadScene("Main");
        else
        {
            DisplayMainMenu();
        }
    }
    public void OpenInventory()
    {
        int x = -271;
        int y = 400;

        SetCameraPosition(x,y);
        if (GetActiveSceneName() == "Victory")
            LoadScene("Main");
    }


    public void OpenEquipment()
    {
        int x = 758;
        int y = 400;

        SetCameraPosition(x, y);

        if (GetActiveSceneName() == "Victory")
            LoadScene("Main");
    }

    public void ActivateAdventureCanvas()
    {
        Adventure.gameObject.SetActive(true);
        //SceneManager.LoadScene("Adventure");

    }

    #region Private Functions
    private void DisplayMainMenu()
    {

        //var Adventure = GameObject.FindGameObjectWithTag("Adventure").transform.GetChild(0).gameObject;
        LoginPanel = GameObject.FindGameObjectWithTag("LoginPanel");
        Adventure = GameObject.FindGameObjectWithTag("Adventure").transform.GetChild(0).gameObject;
        if (Adventure.activeSelf)
                Adventure.SetActive(false);
            if (LoginPanel)
                Destroy(LoginPanel);
            if (getCameraPosition() != new Vector2((int)240, (int)400))
            {
                SetCameraPosition(240,400);
            }
        
        
    }

    #region Helper Functions
    private string GetActiveSceneName(){
        return SceneManager.GetActiveScene().name;}
    private void SetCameraPosition(int X, int Y){
        GameObject.Find("Camera").transform.position = new Vector3(X, Y, -10);}
    private Vector2 getCameraPosition()
    {
        var cameraPosition = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        int x = Mathf.RoundToInt(cameraPosition.x);
        int y = Mathf.RoundToInt(cameraPosition.y);

        return new Vector2(x, y);
    }
    #endregion
    #endregion
}