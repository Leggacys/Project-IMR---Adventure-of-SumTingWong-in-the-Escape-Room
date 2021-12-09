using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInteractionRoom2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                lightonoff myLightOnOff = hit.transform.gameObject.GetComponent<lightonoff>();
                if (myLightOnOff != null)
                {
                    if (!myLightOnOff.isLightTriggered)
                    {
                        myLightOnOff.Interact();
                    }
                }
            }
        }
    }
}

