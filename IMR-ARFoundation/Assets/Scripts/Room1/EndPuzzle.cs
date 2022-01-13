using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPuzzle : MonoBehaviour
{
    
    public void Interact()
    { 
        DecodeScene();
        SceneManager.LoadScene("SampleScene");
    }

    
    private void DecodeScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        Constants.instance.roomsKey[scene.buildIndex-1] = true;
    }
}
