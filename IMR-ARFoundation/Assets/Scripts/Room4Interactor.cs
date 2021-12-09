using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room4Interactor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H)){
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit,100))
            { 
                LeverInteract lever1 = hit.transform.gameObject.GetComponent<LeverInteract>();
                if(lever1)
                {
                    lever1.Interact();
                }
            }

        }
    }
}
