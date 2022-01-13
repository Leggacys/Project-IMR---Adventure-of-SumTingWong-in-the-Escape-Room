using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    #region Singletone

    public static Constants instance;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(this);
    
    }


    #endregion
    
    public bool firstTime = true;
    public bool[] roomsKey;
}
