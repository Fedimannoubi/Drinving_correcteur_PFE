using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float maxSpeed;
    public float rotateSpeed;
    public float speed;
    public float horizontalMove;
    public float verticalMove;
    public Joystick joystick;
    public Text speedText;


    private void Start()
    {
        maxSpeed    /= 10;
    }

    void Update()
    {
        //horizontalMove = Input.GetAxis("Horizontal");
        //verticalMove   = Input.GetAxis("Vertical");

        verticalMove = joystick.Vertical * maxSpeed;
        horizontalMove = joystick.Horizontal * verticalMove * rotateSpeed;


        speed = verticalMove*10;
        speedText.text = speed.ToString("n2");

        //acceleration
        transform.Translate(0f,0f, verticalMove * Time.deltaTime);

        //rotation
        transform.Rotate(0f, horizontalMove * Time.deltaTime,  0f);
    }
}
