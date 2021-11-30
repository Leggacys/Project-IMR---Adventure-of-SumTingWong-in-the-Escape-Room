using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    Light currentLight;
    public List<GameObject> syncWith;
    List<Light> lightSync = null;
    // Start is called before the first frame update
    void Start()
    {
        currentLight = GetComponent<Light>();

        if(syncWith.Count>0){
        
        lightSync = new List<Light>();
            foreach(GameObject obj in syncWith) {
                lightSync.Add(obj.GetComponent<Light>());
            
            }
        }

        StartCoroutine("Flicker");
        //currentLight.intensity=200;
    }

    IEnumerator Flicker(){
        float initial=currentLight.intensity;
        
        while(true){
        
        int counts = Random.Range(2,8);
        
        for(int i = 0; i < counts; i++) {

            while (currentLight.intensity>0.001){
                float step = Random.Range(0.005f,0.1f);
                currentLight.intensity-=step;
                if(lightSync!= null){
                        foreach(Light obj in lightSync) {
                            obj.intensity = currentLight.intensity;
                        }
                }
            yield return new WaitForSeconds(Random.Range(0.0005f,0.05f));
            }

        currentLight.intensity = initial;
            if(lightSync!= null){
                foreach(Light obj in lightSync) {
                    obj.intensity = currentLight.intensity;
                }
            }
        }
        
        yield return new WaitForSeconds(Random.Range(5,10));
        }


    }



    
}
