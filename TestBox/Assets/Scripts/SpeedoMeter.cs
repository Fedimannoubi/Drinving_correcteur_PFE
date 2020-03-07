using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedoMeter : MonoBehaviour
{
    RectTransform rectTransform;
    GameObject thePlayer;
    Movement playerScript;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        //get the car gameobject
        thePlayer = GameObject.Find("car");
        //get the script
        playerScript = thePlayer.GetComponent<Movement>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, -( playerScript.getSpeed()/27));
        //rectTransform.Rotate(new Vector3(0, 0, playerScript.getSpeed()));
    }
}
