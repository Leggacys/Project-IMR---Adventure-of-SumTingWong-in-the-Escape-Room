using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalBehaviour : MonoBehaviour
{

    public Material[] materials;

    public GameObject[] doors;
    

    
    private void Start()
    {
        if (Constants.instance.firstTime)
        {
            foreach (var material in materials) 
            {
                material.SetInt("_StencilTest",(int)CompareFunction.Equal); 
            }
        }
        else
        {
            foreach (var material in materials) 
            {
                material.SetInt("_StencilTest",(int)CompareFunction.NotEqual); 
            } 
        }
        
        
        CheckProgress();
    }


    private void CheckProgress()
    {

    int numbersOfKeys=0;
        bool[] keys = Constants.instance.roomsKey;

        for (int i = 0 ; i < 4; i++)
        {
            if (keys[i])
            {
                numbersOfKeys++;
                doors[i].gameObject.SetActive(false);
            }
        }

        if (numbersOfKeys == 4)
        {
            GameObject.FindWithTag("WinText").transform.GetChild(0).gameObject.SetActive(true);
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
