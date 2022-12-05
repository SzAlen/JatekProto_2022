using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
   //damage
   public int damage = 5 ;
   public float pushForce = 3;

   protected override void OnCollide(Collider2D coll)
   {
        if(coll.tag == "Hero" && coll.name == "Player")
        {
            Damage dmg = new Damage
            {
                damageAmount = 4,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("RecieveDamage", dmg);
        }
   }
}
