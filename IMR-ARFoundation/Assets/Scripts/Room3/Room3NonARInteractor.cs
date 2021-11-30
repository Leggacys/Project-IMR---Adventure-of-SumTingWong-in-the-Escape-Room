using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3NonARInteractor : MonoBehaviour
{
    


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
}
