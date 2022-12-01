using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Hero 
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;
    protected float characterSpeed = 5.5f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        //reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        //swap sprite direction
        if(moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if(moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        //push vector is kell neki
        moveDelta += pushDirection;

        pushDirection  = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //castolunk egy dobozt amerre mennenk,ha null akkor mehetunk
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime * characterSpeed), LayerMask.GetMask("Actor","Blocking"));

        if (hit.collider == null)
        {
        //make movement
            transform.Translate(0, moveDelta.y * Time.deltaTime * characterSpeed, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime * characterSpeed), LayerMask.GetMask("Actor","Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime * characterSpeed, 0 , 0);
        }
    }
}
