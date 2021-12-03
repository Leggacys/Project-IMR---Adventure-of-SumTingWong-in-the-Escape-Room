﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LockBehaviour : MonoBehaviour
{
    public Text digit1;
    public Text digit2;
    public Text digit3;
    public int index;
    // Start is called before the first frame update
    void Start(){
    
    }

    // Update is called once per frame
    void Update(){

    }

    //Test buttons functionality
    [ContextMenu("TestButton")]

    public void TestButton()
    {
        DecreaseDigit(index);
    }

    public void IncreaseDigit(int index)
    {
        switch (index)
        {
            case 1:
                IncreaseDigit(digit1);
                break;
            case 2:
                IncreaseDigit(digit2);
                break;
            case 3:
                IncreaseDigit(digit3);
                break;
        }
            
    }

    public void DecreaseDigit(int index)
    {
        switch (index)
        {
            case 1:
                DecreaseDigit(digit1);
                break;
            case 2:
                DecreaseDigit(digit2);
                break;
            case 3:
                DecreaseDigit(digit3);
                break;
        }

    }

    private void IncreaseDigit(Text button){
        int value = Int32.Parse(button.text);
        if (value < 9)
            value += 1;
        else if (value == 9)
            value = 0;
        button.text = value.ToString();
    }

    private void DecreaseDigit(Text button){
        int value = Int32.Parse(button.text);
        if (value > 0)
            value -= 1;
        else if (value == 0)
            value = 9;
        button.text = value.ToString();
    }

}
