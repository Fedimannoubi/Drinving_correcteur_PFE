using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float maxSpeed;
    public float rotateSpeed;
    public Text speedText;
    public Joystick joystick;
    public float breaksForce;
    //public bool enginStall = true;

    private float speed;
    private float horizontalMove;
    private float verticalMove;
    
   


    private void Start()
    {
        maxSpeed    /= 10;
    }

    void Update()
    {
        //horizontalMove = Input.GetAxis("Horizontal");
        //verticalMove   = Input.GetAxis("Vertical");

        if (joystick.Vertical * maxSpeed  > verticalMove)
        {
            //acceleration speed and momentum
            verticalMove = joystick.Vertical * maxSpeed;
        }
        else if ((joystick.Vertical<0) && (speed>=0))
        {
            //breaks
            verticalMove -= -joystick.Vertical * breaksForce * Time.deltaTime;
        }
        
        horizontalMove = joystick.Horizontal * verticalMove * rotateSpeed;


        speed = verticalMove*10;
        speedText.text = speed.ToString("n2");

        //acceleration action
        transform.Translate(0f,0f, verticalMove * Time.deltaTime);

        //rotation action
        transform.Rotate(0f, horizontalMove * Time.deltaTime,  0f);
    }
}
