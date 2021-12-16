using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPuzzle : MonoBehaviour
{
    public GameObject roomPrefab;
    public GameObject lobby;
    public float xAdjustment,yAdjustment,zAdjustment;
    
    public void Interact(){
        roomPrefab.SetActive(false);
        GameObject camera = GameObject.Find("ARCamera");
        camera.GetComponent<RayCastManager>().enabled = false;
        lobby.SetActive(true);

        lobby.transform.position = camera.transform.position + new Vector3(xAdjustment,yAdjustment,zAdjustment);
        camera.transform.LookAt(lobby.transform,Vector3.up);


    }
}
