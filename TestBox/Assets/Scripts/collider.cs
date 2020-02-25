using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collider : MonoBehaviour
{
	public int red;
	public int yellow;
	public int green;
    public Text redText;
    public Text yellowText;
    public Text greenText;

    private void Start()
    {
        //fill the score board
        redText.text = red.ToString();
        yellowText.text = yellow.ToString();
        greenText.text = green.ToString();
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
}