using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3NonARInteractor : MonoBehaviour
{
    
    public Room3Manager roomManager;

    void Start(){
        roomManager=GameObject.Find("PuzzleManager").GetComponent<Room3Manager>();
    }

    /*

    public Camera arCamera;

    void Update(){

        if(Input.touchCount>0)
        {
            Touch touch = Input,GetTouch(0);

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

                }

            }


        }

    }
    */

    void Update()
    {
        if (Input.GetKey(KeyCode.H)){
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit,100))
            {
            GenericAxisRotate objRotator = hit.transform.gameObject.GetComponent<GenericAxisRotate>();
            if (objRotator != null)
                objRotator.Interact();
                
            PieceFoundDeactivator objPiece = hit.transform.GetComponent<PieceFoundDeactivator>();
            if(objPiece != null)
                objPiece.Interact();

            }
			
    
		}
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag =="Ghost" )
            roomManager.GhostCollided();
    }
}
