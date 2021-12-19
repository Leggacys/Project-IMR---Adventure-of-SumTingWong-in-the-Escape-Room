using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLVL : MonoBehaviour
{
    private Vector2 touchPosition;
    public Camera camera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Da");
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitObject;
            if (Physics.Raycast(ray, out hitObject))
            {
                GameObject gameObject = hitObject.transform.gameObject;
                if (gameObject.tag == "Room")
                {
                    SceneManager.LoadScene("Room 1");
                }
            }
        }
    }
}
