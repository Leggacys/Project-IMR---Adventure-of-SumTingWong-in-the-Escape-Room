using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3ARInteractor : MonoBehaviour
{
    private Vector2 touchPosition;
    public Room3Manager roomManager;
    public GameObject room;
    bool isTeleporting;
    void Start(){
        
    }

    

    public Camera arCamera;

    // void Update(){

    //         if(Input.GetMouseButtonDown(0)){
    //             Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
    //             RaycastHit hit;
                
    //             if(Physics.Raycast(ray, out hit))
    //             {   
    //                 GenericAxisRotate objRotator = hit.transform.gameObject.GetComponent<GenericAxisRotate>();
    //                 if (objRotator != null)
    //                     objRotator.Interact();
                
    //                 PieceFoundDeactivator objPiece = hit.transform.GetComponent<PieceFoundDeactivator>();
    //                 if(objPiece != null)
    //                     objPiece.Interact();

    //                 if(hit.transform.gameObject.tag == "Floor")
    //                     if(!isTeleporting)
    //                         TeleportToLocation(hit.point);

    //             }

    //         }

            

    // }

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
                    GenericAxisRotate objRotator = hit.transform.gameObject.GetComponent<GenericAxisRotate>();
                    if (objRotator != null)
                        objRotator.Interact();
                
                    PieceFoundDeactivator objPiece = hit.transform.GetComponent<PieceFoundDeactivator>();
                    if(objPiece != null)
                        objPiece.Interact();

                    if(hit.transform.gameObject.tag == "Floor")
                        if(!isTeleporting)
                            TeleportToLocation(hit.point);

                }

            }


        }

    }
    

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag =="Ghost" )
            roomManager.GhostCollided();
    }
}

