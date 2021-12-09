using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RayCastManager : MonoBehaviour
{
    private Vector2 touchPosition;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Da");
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    GameObject gameObject = hitObject.transform.gameObject;
                    if (gameObject.tag == "Button")
                    {
                        gameObject.GetComponent<Button>().onClick.Invoke();
                    }
                }
        }
    }
}
