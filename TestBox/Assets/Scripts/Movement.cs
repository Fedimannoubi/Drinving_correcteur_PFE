using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        //acceleration
        transform.Translate(0f,0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
        //rotation
        transform.Rotate(0f, rotateSpeed * Input.GetAxis("Horizontal") * Time.deltaTime,  0f);
    }
}
