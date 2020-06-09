using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Path
{
    public float startingPosiotionX;
    public float startingPosiotionZ;
    public float startingRotaionY;
    public List<Transform> Roads = new List<Transform>();
}
