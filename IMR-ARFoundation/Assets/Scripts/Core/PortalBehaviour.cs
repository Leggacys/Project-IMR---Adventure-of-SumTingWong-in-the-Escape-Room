using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalBehaviour : MonoBehaviour
{

    public Material[] materials;
    

    
    private void Start()
    {
        foreach (var material in materials)
        {
            material.SetInt("_StencilTest",(int)CompareFunction.Equal);
        }
    }

    
    private void OnTriggerStay(Collider other)
    {
        
        if (other.name != "AR Camera")
            return;

        //Outside of the portal
        if (transform.position.z < other.transform.position.z)
        {

            foreach (var material in materials)
            {
                material.SetInt("_StencilTest",(int)CompareFunction.Equal);
            }
        }
        //Inside the portal
        else
        {
            foreach (var material in materials)
            {
                material.SetInt("_StencilTest",(int)CompareFunction.NotEqual);
            }
        }
    }

}
