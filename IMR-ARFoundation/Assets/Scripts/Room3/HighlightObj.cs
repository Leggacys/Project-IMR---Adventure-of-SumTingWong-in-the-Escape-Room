using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObj : MonoBehaviour
{

    public Material highlight;

    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine("Highlight");
    }

    IEnumerator Highlight(){
        while(true){
            Material backup;
            backup = rend.material;
            rend.material = highlight;
            yield return new WaitForSeconds(Random.Range(1f,2f));
            rend.material = backup;

            yield return new WaitForSeconds(10);
            
        }


    }

    
}
