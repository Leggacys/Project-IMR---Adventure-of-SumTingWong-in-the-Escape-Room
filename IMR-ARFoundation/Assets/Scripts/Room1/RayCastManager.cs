using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RayCastManager : MonoBehaviour
{
    private Vector2 touchPosition;
    public Camera arCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){

        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;
                
                if(Physics.Raycast(ray, out hit))
                {   
                    GameObject gameObject = hit.transform.gameObject;
                    if (gameObject.tag == "Button")
                    {
                        gameObject.GetComponent<Button>().onClick.Invoke();
                    }

                    EndPuzzle ender = hit.transform.gameObject.GetComponent<EndPuzzle>();
                    if(ender != null)
                    {
                        ender.Interact();
                    }

                }

            }


        }

    }
}
