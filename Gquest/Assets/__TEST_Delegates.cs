using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class __TEST_Delegates : MonoBehaviour {

    public delegate void EventHandler();
    public static event EventHandler MyEvent;


    void Start() {
        //OnEventRaised();
    }


    protected virtual void OnEventRaised()
    {
        if (MyEvent != null)
            MyEvent();
    }
    
    //void SomeMethod()
    //{
    //    Debug.Log("Lulz");
    //}

    //MyDelegate del = delegate ()
    //{
    //    Debug.Log("Another Lulz");
    //};
}
