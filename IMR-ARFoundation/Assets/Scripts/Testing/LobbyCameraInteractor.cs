using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCameraInteractor : MonoBehaviour
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
                SpawnTest spawner = hit.transform.gameObject.GetComponent<SpawnTest>();
                if(spawner != null){
                    spawner.Activate(this.gameObject);
                }
            }

        }
    }
}
