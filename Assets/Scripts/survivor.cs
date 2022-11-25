using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor : Collectible
{

    public int pointsAmount = 10;
    public Sprite pickedUpSurvivor;

    protected override void OnCollect()
    {
       if(!collected)
       {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = pickedUpSurvivor;
            // +10 points!
            GameManager.instance.ShowText("+" + pointsAmount + " points!",25,Color.yellow,transform.position,Vector3.up * 25, 1.5f);

       }
    }
}
