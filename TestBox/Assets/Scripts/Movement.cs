using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float maxSpeed;
    public float rotateSpeed;
    public Text speedText;
    public Text gearText;
    public Joystick joystick;
    public float breaksForce;
    //public bool enginStall = true;


    //gears settings
    private int curentGear = 1;
    private string[] gearsLabel = {"R", "N", "1", "2", "3", "4", "5", };
    private int[] gearsSpeed    = { 20,  0 ,  20 , 40,  60,  80,  100 };
    bool reverse = false;
    private float speed;
    private float horizontalMove;
    private float verticalMove;


    public void GearChange (string gear)
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
        else if ((gear == "Down") && (curentGear>0) )
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


    void Update()
    {
        //horizontalMove = Input.GetAxis("Horizontal");
        //verticalMove   = Input.GetAxis("Vertical");

        if (joystick.Vertical * (maxSpeed/10)  > verticalMove)
        {
            //acceleration speed and momentum
            verticalMove = joystick.Vertical * (maxSpeed / 10);
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
        if (reverse)
        {
            transform.Translate(0f, 0f, -verticalMove * Time.deltaTime);
        }
        else
        {
            transform.Translate(0f, 0f, verticalMove * Time.deltaTime);
        }
        

        //rotation action
        transform.Rotate(0f, horizontalMove * Time.deltaTime,  0f);
    }
}
