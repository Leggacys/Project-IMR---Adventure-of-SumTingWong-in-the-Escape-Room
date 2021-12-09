using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    Light currentLight;
    public List<GameObject> syncWith;
    List<Light> lightSync = null;
    public float lightFlickerMin;
    public float lightFlickerMax;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentLight = GetComponent<Light>();
        currentLight.intensity = 2;
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

           
                
                currentLight.intensity = 0;
                if(lightSync!= null){
                        foreach(Light obj in lightSync) {
                            obj.intensity = currentLight.intensity;
                        }
                }
            yield return new WaitForSeconds(Random.Range(0.05f,0.1f));
            

        currentLight.intensity = initial;
            if(lightSync!= null){
                foreach(Light obj in lightSync) {
                    obj.intensity = currentLight.intensity;
                }
            }
        }
        
        yield return new WaitForSeconds(Random.Range(lightFlickerMin,lightFlickerMax));
        }


    }



    
}
