using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLVL : MonoBehaviour
{
    private Vector2 touchPosition;
    public Camera camera;
    
    void Update()
    {

        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = camera.ScreenPointToRay(touch.position);
                RaycastHit hit;
                
                if(Physics.Raycast(ray, out hit))
                {
                    GameObject gameObject = hit.transform.gameObject;
                    if (gameObject.tag == "Room1")
                    {
                        SceneManager.LoadScene("Room 1");
                        SetBoolFirstTime();
                    }
                    if (gameObject.tag == "Room2")
                    {
                        SceneManager.LoadScene("Room 2");
                        SetBoolFirstTime();
                    }
                    if (gameObject.tag == "Room3")
                    {
                        SceneManager.LoadScene("Room 3");
                        SetBoolFirstTime();
                    }
                    if (gameObject.tag == "Room4")
                    {
                        SceneManager.LoadScene("Room 4");
                        SetBoolFirstTime();
                    }

                }

            }


        }
    }


    private void SetBoolFirstTime()
    {
        Constants.instance.firstTime = false;
    }
    

}
