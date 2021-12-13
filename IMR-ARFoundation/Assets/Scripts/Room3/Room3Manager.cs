﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class Room3Manager : MonoBehaviour
{
    // enum State{
    //     STATE_ENTERED,
    //     STATE_BOXFOUND,
    //     STATE_PUZZLESPAWNED,
    //     STATE_GOODEND,
    //     STATE_BADEND

    // };

    // State currentState= State.STATE_ENTERED;
    public float penaltyValue;
    public float secondCount;
    float initialSecondCount = -1;
    public GameObject UIText;
    public GameObject endText;
    public List<GameObject> puzzlePieces;
    public GameObject puzzleToSpawn,ball,roomPrefab;
    Vector3 BallTransform = new Vector3(0.69f,0.69f,0.69f);


    Text UIValue;

    private void OnEnable() {
         UIValue = UIText.GetComponent<Text>();
         if(initialSecondCount != -1)
            secondCount = initialSecondCount;
        else
            initialSecondCount = secondCount;

        if (BallTransform != new Vector3(0.69f,0.69f,0.69f))
            ball.transform.position = BallTransform;
        else
            BallTransform = ball.transform.position;
        
        puzzleToSpawn.SetActive(false);
        ball.SetActive(false);
        endObject.SetActive(false);
        endText.SetActive(false);
        foreach(GameObject obj in puzzlePieces)
            obj.SetActive(true);
        StartCoroutine("UITimer");
        StartCoroutine("PuzzleSpawn");
       
    }

    IEnumerator UITimer(){

        while(secondCount>0){
            UIValue.text = "" + secondCount;
            secondCount -=1;
            yield return new WaitForSeconds(1);
        }
        endText.SetActive(true);
        yield return new WaitForSeconds(3);
        endGame(0);


    }

    IEnumerator PuzzleSpawn(){
        while(true){
        bool canSpawn=true;
        foreach(GameObject obj in puzzlePieces) {
            if(obj.activeSelf){
                canSpawn=false;
                break;
            }
        }
        if(canSpawn)
            {puzzleToSpawn.SetActive(true);
            ball.SetActive(true);
            break;
            }
        yield return new WaitForSeconds(5);
        }



    }

    public void GhostCollided(){
        secondCount -= penaltyValue;
    }

    public GameObject endObject;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Ball")
            endObject.SetActive(true);
            endGame(1);
    }

    void endGame(int final){
        roomPrefab.SetActive(false);
    }


}
