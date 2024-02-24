using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    bool isJumping;
    bool isOnGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isJumping = Input.GetButtonDown("Jump");
    }

    void FixedUpdate() {
        if(isJumping && isOnGround){
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collider2D){
        Debug.Log("enter");
        isOnGround = true;
    }
    void OnCollisionExit2D(Collision2D collider2D){
        Debug.Log("exit");
        isOnGround = false;
    }
}
