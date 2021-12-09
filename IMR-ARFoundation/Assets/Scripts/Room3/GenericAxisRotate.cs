using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAxisRotate : MonoBehaviour
{
    public float x,y,z;
    public GameObject redirectTo;
    // Start is called before the first frame update
    public void Interact(){
        if(redirectTo!=null){
            Vector3 newRotation = new Vector3(redirectTo.transform.localRotation.eulerAngles.x + x, redirectTo.transform.localRotation.eulerAngles.y+y,redirectTo.transform.localRotation.eulerAngles.z+z);
            LeanTween.rotate(redirectTo.transform.gameObject,newRotation,0.5f);

        }
        else{
            Vector3 newRotation = new Vector3(transform.localRotation.eulerAngles.x + x, transform.localRotation.eulerAngles.y+y,transform.localRotation.eulerAngles.z+z);
            LeanTween.rotate(transform.gameObject,newRotation,0.5f);
        }

    }
}
