using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCompleteChecker : MonoBehaviour
{
    public GameObject endObject;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Ball")
            endObject.SetActive(true);
    }
    
}
