using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAxisRotate : MonoBehaviour
{
    public float x,y,z;
    public GameObject redirectTo;
    Vector3 previousRotation = new Vector3(-1,-1,-1);
    // Start is called before the first frame update
    private void OnEnable() {
        if(previousRotation != new Vector3(-1,-1,-1))
        {
            if(redirectTo != null)
                redirectTo.transform.eulerAngles = previousRotation;
            else
                transform.eulerAngles = previousRotation;
        }
        else
            if(redirectTo != null)
                previousRotation = redirectTo.transform.eulerAngles;
            else
                previousRotation = transform.eulerAngles;
                
    }

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
