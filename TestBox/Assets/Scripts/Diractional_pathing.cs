using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diractional_pathing : MonoBehaviour
{

    public GameObject player;

    [SerializeField]
    private Vector3 targetPostion;

    [SerializeField]
    private List<Path> paths = new List<Path>();

    private List<Transform> Roads = new List<Transform>();

    private Random rnd = new Random();

    private int random;

    private void Start()
    {

        random = Random.Range(0, paths.Count);

        Roads = paths[random].Roads;

        player.transform.position = new Vector3(paths[random].startingPosiotionX, 2.4f, paths[random].startingPosiotionZ);
        player.transform.rotation = Quaternion.Euler(0, paths[random].startingRotaionY, 0);
       //get the X.Y.Z of the original target
       targetPostion = Roads[0].position;

        //change the y to the y of the arrow
        targetPostion.y = transform.position.y;

        //print(target.transform.position.y);
    }
    void Update()
    {

        transform.LookAt(targetPostion);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Roads.Count > 1)
        {
            Roads.RemoveAt(0);
            targetPostion = Roads[0].position;
            print("x :"+ Roads[0].gameObject.name);
        }
        
    }

}
