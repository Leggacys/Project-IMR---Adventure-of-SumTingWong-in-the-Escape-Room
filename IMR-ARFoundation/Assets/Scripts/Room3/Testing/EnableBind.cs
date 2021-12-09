using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBind : MonoBehaviour
{
    
    public GameObject obj;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.L))
            obj.SetActive(true);
        if (Input.GetKey (KeyCode.P))
            obj.SetActive(false);
    }
}
