using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCanvas : MonoBehaviour {

    public static EquipmentCanvas instance;
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
            Destroy(gameObject);
    }
}
