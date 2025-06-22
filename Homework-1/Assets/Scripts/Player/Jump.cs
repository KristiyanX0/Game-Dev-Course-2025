using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    bool isJumping = false;
    bool isOnGround = false;
    public float jumpForce = 10f; // Global variable for jump force
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isJumping)
        {
            isJumping = Input.GetButtonDown("Jump") && isOnGround;
        }
    }

    void FixedUpdate() 
    {
        if(isJumping)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
            animator.SetBool("Jump", true);
        }

        if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            animator.SetBool("Jump", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collider2D)
    {
        Vector2 boxPosition = transform.position;
        boxPosition.y -= 1.1f;
        RaycastHit2D[] raycastHits2D = Physics2D.BoxCastAll(boxPosition, new Vector2(1,1), 0, new Vector2(0,0));

        foreach (var item in raycastHits2D)
        {
            if(item.collider.gameObject.name != "Player")
            {
                isOnGround = true;
            }
        }
    }
    void OnCollisionExit2D(Collision2D collider2D)
    {
        isOnGround = false;
    }
}
