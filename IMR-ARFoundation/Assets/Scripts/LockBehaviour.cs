using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LockBehaviour : MonoBehaviour
{
    public Text digit;

    // Start is called before the first frame update
    void Start(){
    
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            IncreaseDigit();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            DecreaseDigit();
        }

    }

    public void IncreaseDigit(){
        int value = Int32.Parse(digit.text);
        if (value < 9)
            value += 1;
        else if (value == 9)
            value = 0;
        digit.text = value.ToString();
    }

    public void DecreaseDigit(){
        int value = Int32.Parse(digit.text);
        if (value > 0)
        {
            value -= 1;
        }
        else
        {
            value = 9;
        }
        digit.text = value.ToString();
    }

}
