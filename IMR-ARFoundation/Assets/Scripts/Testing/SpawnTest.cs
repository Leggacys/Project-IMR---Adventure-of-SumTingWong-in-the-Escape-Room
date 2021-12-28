using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    public int roomNumber;
    public GameObject roomPrefab;
    public float xAdjustment,yAdjustment,zAdjustment;
    public GameObject lobby;
    public GameObject flashlight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(GameObject camera){

        switch(roomNumber){
            case 1:
                camera.GetComponent<RayCastManager>().enabled = true;
                flashlight.SetActive(true);
                break;
            case 2:
                camera.GetComponent<ARInteractionRoom2>().enabled =true;
                break;


            case 3:
                camera.GetComponent<Room3ARInteractor>().enabled =true;
                break;
            case 4:
                camera.GetComponent<Room4Interactor>().enabled = true;
                break;
         
            

        }

        roomPrefab.SetActive(true);
        roomPrefab.transform.position = camera.transform.position + new Vector3 (xAdjustment,yAdjustment,zAdjustment);
        lobby.gameObject.SetActive(false);



    }
}
