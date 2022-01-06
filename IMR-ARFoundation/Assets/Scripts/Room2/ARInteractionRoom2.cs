using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInteractionRoom2 : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Vector2 touchPosition;
    public Camera arCamera;

    void Update(){

        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;
                
                if(Physics.Raycast(ray, out hit))
                {   
                    lightonoff myLightOnOff = hit.transform.gameObject.GetComponent<lightonoff>();
                    
                if (myLightOnOff != null)
                {
                    if (!myLightOnOff.isLightTriggered)
                    {
                        myLightOnOff.Interact();
                    }
                }

                EndPuzzle ender = hit.transform.gameObject.GetComponent<EndPuzzle>();
                    if(ender != null)
                    {
                        ender.Interact();
                    }
                }

            }


        }

    }
}

