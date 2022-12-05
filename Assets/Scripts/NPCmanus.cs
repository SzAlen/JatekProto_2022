using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmanus : Collidable
{
    public string message;
    private float cooldown = 1.5f;
    private float lastShout = -1.5f;

    protected override void OnCollide(Collider2D coll)
    {
        if(Time.time - lastShout > cooldown)
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message, 25, Color.blue, transform.position + new Vector3(0,0.36f,0), Vector3.zero, cooldown);
        }
        
    }
}
