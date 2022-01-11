using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room4Interactor : MonoBehaviour
{
    
    private Vector2 touchPosition;
    public Camera arCamera;
    public GameObject room;
    bool isTeleporting;

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
                    LeverInteract lever1 = hit.transform.gameObject.GetComponent<LeverInteract>();
                if(lever1)
                {
                    lever1.Interact();
                }
                EndPuzzle ender = hit.transform.gameObject.GetComponent<EndPuzzle>();
                    if(ender != null)
                    {
                        ender.Interact();
                    }
                if(hit.transform.gameObject.tag == "Floor")
                        if(!isTeleporting)
                            TeleportToLocation(hit.point);

                }

            }


        }

    }



    void TeleportToLocation(Vector3 location)
    {
        // float height = arCamera.transform.position.y;
        // location.y = height;
        // arCamera.transform.position= location;
        
        isTeleporting = true;

        float height = room.transform.position.y;
        float x_diff = arCamera.transform.position.x - location.x;
        float z_diff = arCamera.transform.position.z - location.z;

        room.transform.position += new Vector3(x_diff,0,z_diff); 
        isTeleporting = false;
    }

    // Event PushLever1()
    // {
    //     //33% perete jos
    // }

    // Event PushLever2()
    // {
    //     //33% perete jos
    // }

    // Event PushLever3()
    // {
    //     //33% perete jos
    // }
    // void CorrectOrder(Event e)
    // {
    //     if(e == push_lever_1()){
    //         if(e == push_lever_2()){
    //             if(e == push_lever_2())
    //             {
    //                 //peretele e jos
    //                 Debug.log("We break the wall");
    //             }
    //             else reverse(e);
    //         }
    //         else reverse(e);
    //     }
    //     else reverse(e);
    // }

    // void take_key_and_destroy_it()
    // {
    //     //sunt langa cheie, o iau
    //     //se distruge cheia cand o iau
    //     //se iese din camera
    // }



}
