using System.Collections;
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
    public GameObject UIText;
    public GameObject endText;
    public List<GameObject> puzzlePieces;
    public GameObject puzzleToSpawn,ball;


    Text UIValue;

    private void OnEnable() {
         UIValue = UIText.GetComponent<Text>();
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


}
