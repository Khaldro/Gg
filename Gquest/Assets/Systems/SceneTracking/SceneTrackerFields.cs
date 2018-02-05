using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneTrackerFields : ScriptableObject {

    private string activeScene = string.Empty;
    private string previousScene = string.Empty;

    public string ActiveScene { get { return activeScene; } private set { activeScene = value; } }
    public string PreviousScene { get { return previousScene; } private set { previousScene = value; } }
}
