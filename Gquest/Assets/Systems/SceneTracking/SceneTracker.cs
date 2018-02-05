using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour {

    private static string activeScene = string.Empty;
    private static string previousScene = string.Empty;

    public static string ActiveScene { get { return activeScene; } private set { activeScene = value; } }
    public static string PreviousScene { get { return previousScene; } private set { previousScene = value; } }


    void Start () {
        var sceneTrackerFields = Resources.Load<SceneTrackerFields>("_SceneTrackerFields");

        activeScene = sceneTrackerFields.ActiveScene;
        previousScene = sceneTrackerFields.PreviousScene;

        
        PreviousScene = ActiveScene;

        ActiveScene = SceneManager.GetActiveScene().name;
        //SceneManager.activeSceneChanged += OnSceneChange;

        
    }


    private void OnSceneChange(Scene arg0, Scene arg1)
    {
        PreviousScene = ActiveScene;
        Debug.Log("SceneChanged!");
        ActiveScene = arg1.name;
    }
}
