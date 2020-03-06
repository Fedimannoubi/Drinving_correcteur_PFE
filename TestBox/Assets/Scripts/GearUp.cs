using UnityEngine;
using UnityEngine.EventSystems;

public class GearUp : MonoBehaviour, IPointerClickHandler
{
    Movement playerScript;
    GameObject thePlayer;

    void Start()
    {
        //get the car gameobject
        thePlayer = GameObject.Find("car");
        //get the script
        playerScript = thePlayer.GetComponent<Movement>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        playerScript.GearChange("Up");
    }
}