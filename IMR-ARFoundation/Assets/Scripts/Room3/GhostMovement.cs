using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 5f;
    public float upPower;
    public float Angle;
    public float torqueMin;
    public float torqueMax;
    public float turnChance;
    float initialY;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        //m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        initialY = transform.position.y;
    }

    void FixedUpdate()
    {
        
        m_Rigidbody.MovePosition(transform.position + transform.forward * m_Speed * Time.deltaTime);

        if(initialY> transform.position.y)
            m_Rigidbody.AddForce(Vector3.up * upPower *(initialY-transform.position.y));

        float decider = Random.Range(0f,1f);
        if(decider>(1-turnChance))
            TurnLeft();
        else{
            decider = Random.Range(0f,1f);
            if(decider>(1-turnChance))
                TurnRight();
        }
    }

    public void TurnLeft(){
            float torque = Random.Range(torqueMin,torqueMax);
            
            transform.Rotate(Vector3.up,-Angle * torque * Time.deltaTime) ;
    }

    public void TurnRight(){
        float torque = Random.Range(torqueMin,torqueMax);
        transform.Rotate(Vector3.up,Angle * torque * Time.deltaTime); 
    }
}
