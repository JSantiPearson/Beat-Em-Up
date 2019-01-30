using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 6f;
    bool facingRight = true;
 
    Animator anim;
 
    void Start ()
    {
        anim = GetComponent<Animator> ();
    }
 
    void FixedUpdate ()
    {
        float moveH = Input.GetAxisRaw ("Horizontal");
        float moveV = Input.GetAxisRaw ("Vertical");
 
        anim.SetFloat ("Speed", Mathf.Abs (moveH*moveV+(moveV+moveH)));
 
        GetComponent<Rigidbody2D>().velocity = new Vector2 (moveH * maxSpeed, moveV * maxSpeed);
 
        if (moveH > 0 && !facingRight)
            Flip ();
        else if (moveH < 0 && facingRight)
            Flip ();
    }
 
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 TheScale = transform.localScale;
        TheScale.x *= -1;
        transform.localScale = TheScale;
    }
}
