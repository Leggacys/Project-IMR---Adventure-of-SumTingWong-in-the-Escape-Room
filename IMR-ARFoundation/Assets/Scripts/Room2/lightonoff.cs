using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightonoff : MonoBehaviour
{

    //public GameObject txtToDisplay;             //display the UI text
    
    private bool PlayerInZone;                  //check if the player is in trigger

    public GameObject lightorobj;
    
    //public GameObject light1, light2, light3, light4, light5;
    public List<GameObject> lightList;

    public GameObject key;

    [HideInInspector]
    public bool isLightTriggered;

    private void Start()
    {

        PlayerInZone = false;                   //player not in zone       
        //txtToDisplay.SetActive(false);
        StartCoroutine("CheckNumberOfLights");
    }
    


    [ContextMenu("Testing Button")]
    public void Interact()
    {
        if (PlayerInZone)
        {
            isLightTriggered = true;
            StartCoroutine("SwitchLight");
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("switch");
            //Debug.Log("Andrei Boss");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")     //if player in zone
        {
            //txtToDisplay.SetActive(true);
            PlayerInZone = true;
        }
    }
    

    private void OnTriggerExit(Collider other)     //if player exit zone
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInZone = false;
            //txtToDisplay.SetActive(false);
        }
    }

    IEnumerator SwitchLight()
    {
        lightorobj.SetActive(!lightorobj.activeSelf);
        for (int i = 0; i < lightList.Count ; i++)
        {
            if (lightList[i] != null)
                lightList[i].SetActive(!lightList[i].activeSelf);
            else
            {
                lightList.RemoveAt(i);
                i--;
            }
        }
        yield return new WaitForSeconds(15);
        lightorobj.SetActive(!lightorobj.activeSelf);
        for (int i = 0; i < lightList.Count ; i++)
        {
            if (lightList[i] != null)
                lightList[i].SetActive(!lightList[i].activeSelf);
            else
            {
                lightList.RemoveAt(i);
                i--;
            }
        }
        isLightTriggered = false;
    }

    IEnumerator CheckNumberOfLights()
    {
        
        while (true)
        {
            if (lightList.Count == 0)
            {
                //Debug.Log("LA MULTI ANI ANDREI!");
                key.SetActive(!key.activeSelf);
                break;
            }

            yield return new WaitForSeconds(5);
        }
    }
}


