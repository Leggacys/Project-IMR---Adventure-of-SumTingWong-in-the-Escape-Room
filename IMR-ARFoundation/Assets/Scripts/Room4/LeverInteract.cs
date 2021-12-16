using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteract : MonoBehaviour
{
    public float id;
    public GameObject interactionResult;

    public void Interact()
    {
        if(interactionResult != null)
        {
            interactionResult.GetComponent<Animator>().SetTrigger("Play");
        }
        gameObject.GetComponent<Animator>().SetTrigger("Play");
        //Debug.Log("Am intrat in IF");
    }
}
