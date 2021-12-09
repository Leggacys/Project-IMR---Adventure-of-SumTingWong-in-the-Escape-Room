using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyLights : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {   
        if(transform.gameObject.activeSelf)
            Destroy(transform.gameObject);
    }
}
