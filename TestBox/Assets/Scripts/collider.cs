using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class collider : MonoBehaviour
{
	public int red;
	public int yellow;
	public int green;
    public Text redText;
    public Text yellowText;
    public Text greenText;
    public Text stopText;

    public float waitTime;
    private Boolean safeToPass;

    private void Start()
    {
        //fill the score board
        redText.text = red.ToString();
        yellowText.text = yellow.ToString();
        greenText.text = green.ToString();

        safeToPass=false;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
    	//to get the parent of child object
    	//print(collisionInfo.collider.gameObject.transform.parent.gameObject.name);

    	//to get the tag of the object
    	switch (collisionInfo.collider.gameObject.tag){

    		case "Red":
    			print("Hiting a Red object");
    			red--;
                Subtract(redText,red);
                break;

    		case "Yellow":
    			print("Hiting a Yellow object");
    			yellow--;
                Subtract(yellowText,yellow);
                break;

    		case "Green":
    			print("Hiting a green object");
    			green--;
                Subtract(greenText,green);
                break;

            case "WaitZone":
                print("WaitZone");
                StartCoroutine(ExampleCoroutine());
                break;

            case "StopLine":
                print("StopLine");
                if (!safeToPass)
                {
                    red--;
                    Subtract(redText, red);
                }
                else
                {
                    safeToPass=false;
                    stopText.text = "Stop";
                    stopText.color = Color.red;
                }
                break;

        }

    	//rest the scene
    	if ( (red < 1) || (yellow < 1) || (green < 1) ) 
    	{
    		SceneManager.LoadScene("SampleScene");
        }
    }

    private void Subtract(Text givingText,int score)
    {
        givingText.text= (score).ToString();
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started timestamp");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(waitTime);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished timestamp");
        //or call getCarIsSleep
        if (gameObject.GetComponent<Rigidbody>().IsSleeping())
        {
            safeToPass = true;
            stopText.text = "GO";
            stopText.color = Color.green;
        }
        else
        {
            Debug.Log("moving");
        }
    }
}