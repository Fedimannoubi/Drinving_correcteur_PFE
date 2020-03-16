using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float maxSpeed;
    public float rotateSpeed;
    public Text gearText;
    public Joystick joystick;
    public float breaksForce;
    public float enginebraking;
    public float acceleration;
    public int StallLimite;



    //gears settings
    private int curentGear = 1;
    private string[] gearsLabel = {"R", "N", "1" , "2", "3", "4", "5" };
    private int[] gearsSpeed    = { 20,  0 ,  20 ,  40,  60,  80,  100};
    private int[] gearsMinSpeed = { 5 ,  0 ,  5  ,  20,  40,  60,  80 };
    bool reverse = false;
    private float speed;
    private float horizontalMove;
    private float verticalMove;
    private bool enginStall = false;


    


    void Update()
    {
        //inout from keyboard
        //horizontalMove = Input.GetAxis("Horizontal");
        //verticalMove   = Input.GetAxis("Vertical");

        if (joystick.Vertical * (maxSpeed/10)  > verticalMove)
        {
            //acceleration speed and momentum
            if (verticalMove < joystick.Vertical * (maxSpeed / 10))
            {
                verticalMove += (joystick.Vertical * (maxSpeed / 10) * acceleration/100)/10;
            }
        }
        else if ((joystick.Vertical<0) && (speed>=0))
        {
            //breaks
            verticalMove -= -joystick.Vertical * breaksForce * Time.deltaTime;
            StallCheck();
        }
        else //Engine braking
        {
            if (speed > gearsMinSpeed[curentGear])
            {
                verticalMove -= enginebraking / 1000;
                //print(verticalMove);
            } 
        }
        
        horizontalMove = joystick.Horizontal * verticalMove * rotateSpeed;


        speed = verticalMove*10;

        
        //acceleration action
        if (reverse)
        {
            transform.Translate(0f, 0f, -verticalMove * Time.deltaTime);
        }
        else
        {
            transform.Translate(0f, 0f, verticalMove * Time.deltaTime );
        }
        

        //rotation action
        transform.Rotate(0f, horizontalMove * Time.deltaTime,  0f);
    }

    public void GearChange(string gear)
    {
        // change the 6 to 5
        if ((gear == "Up") && (curentGear < 6))
        {
            if (curentGear == 1)
            {
                reverse = false;
            }
            curentGear++;
            maxSpeed = gearsSpeed[curentGear];
            gearText.text = gearsLabel[curentGear];
        }
        else if ((gear == "Down") && (curentGear > 0))
        {
            curentGear--;
            if (curentGear == 0)
            {
                reverse = true;
            }
            maxSpeed = gearsSpeed[curentGear];
            gearText.text = gearsLabel[curentGear];
        }
        else
        {
            // 5 gear is not allowed
            //SceneManager.LoadScene("SampleScene");
        }
    }

    private void StallCheck()
    {
        //if stall 
        //the car stall if the speed of the car is - the gear min speed + a thresh hold (StallLimite)
        //curentGear != 2 so the car dont stall in the first gear
        if ( ( (speed + StallLimite) < gearsMinSpeed[curentGear]) && (enginStall == false) && (curentGear != 2))
        {
            curentGear = 2;
            GearChange("Down");
            print("stall");
            enginStall = true;
            shake();
        }
    }

    private void shake()
    {
        // need to add qhake animation

        //stop the car for now
        verticalMove = 0;

        //enginStall = false;
    }

    public float getSpeed()
    {
        return speed;
    }
}
