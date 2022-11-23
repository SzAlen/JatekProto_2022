using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class survivor : Collectible
{

    public int pointsAmount = 10;
    public Sprite pickedUpSurvivor;

    protected override void OnCollect()
    {
       if(!collected)
       {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = pickedUpSurvivor;
            Debug.Log("Grant " + pointsAmount + " points!");

       }
    }
}
