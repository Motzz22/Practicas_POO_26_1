using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : Item
{
    public override void Recoger()
    {
        Debug.Log("El huevo de dragon, parece ser calido es un dragon de lava!");
        Destroy(gameObject);
    }
}
