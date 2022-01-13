using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RayCastManager : MonoBehaviour
{
    private Vector2 touchPosition;
    public Camera arCamera;
    public GameObject room;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool isTeleporting;
    void TeleportToLocation(Vector3 location)
    {
        // float height = arCamera.transform.position.y;
        // location.y = height;
        // arCamera.transform.position= location;
        
        isTeleporting = true;

        float height = room.transform.position.y;
        float x_diff = arCamera.transform.position.x - location.x;
        float z_diff = arCamera.transform.position.z - location.z;

        room.transform.position += new Vector3(x_diff,0,z_diff); 
        isTeleporting = false;
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

                    if(hit.transform.gameObject.tag == "Floor")
                        if(!isTeleporting)
                            TeleportToLocation(hit.point);

                }

            }


        }

    }
}
