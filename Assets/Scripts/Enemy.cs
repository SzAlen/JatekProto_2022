using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    
    public float triggerLength = 5;
    public float chaseLength = 3;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        //a közelben van e a player
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
                chasing = true;

            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
                
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }
            if (hits[i].tag == "Hero" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            hits[i] = null;
        }
    }
}
