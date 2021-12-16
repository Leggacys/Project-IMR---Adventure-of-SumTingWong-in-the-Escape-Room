using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoomPuzzle : MonoBehaviour
{
    public GameObject roomPrefab;
    public GameObject lobby;
    public float xAdjustment,yAdjustment,zAdjustment;
    
    public void Interact(){
        roomPrefab.SetActive(false);
        GameObject camera = GameObject.Find("ARCamera");
        camera.GetComponent<Room4Interactor>().enabled = false;
        lobby.SetActive(true);

        lobby.transform.position = camera.transform.position + new Vector3(xAdjustment,yAdjustment,zAdjustment);


    }
}
