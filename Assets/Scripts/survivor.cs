using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor : Collectible
{

    public int grantedPointsAmount = 10;
    public int survivorsSaved;
    public Sprite pickedUpSurvivor;

    protected override void OnCollect()
    {
       if(!collected)
       {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = pickedUpSurvivor;
            // +10 points!
            GameManager.instance.ShowText("+" + grantedPointsAmount + " points!",25,Color.yellow,transform.position,Vector3.up * 25, 1.5f);
            GameManager.instance.points += grantedPointsAmount;
            // +1 survivorsaved
            GameManager.instance.ShowText("+ 1 Survivor saved!", 25, Color.blue, transform.position, Vector3.up * 25, 1.5f);
            GameManager.instance.survivorsSaved += 1;
       }
    }
}
