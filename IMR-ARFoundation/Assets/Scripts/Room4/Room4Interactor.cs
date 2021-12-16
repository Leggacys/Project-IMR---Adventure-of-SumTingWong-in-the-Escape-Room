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
                EndRoomPuzzle ender = hit.transform.gameObject.GetComponent<EndRoomPuzzle>();
                if(ender != null)
                {
                    ender.Interact();
                }
            }

        }
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
