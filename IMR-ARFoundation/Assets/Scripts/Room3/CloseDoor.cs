using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public GameObject obj;
    bool FirstTime=true;
    // Start is called before the first frame update
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if(FirstTime){
        LeanTween.rotate(obj, new Vector3(0f,-180f,0f), 0.5f);

        FirstTime = false;
        }
    }
    

    
}
