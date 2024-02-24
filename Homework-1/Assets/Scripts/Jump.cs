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
        Vector2 boxPosition = transform.position;
        boxPosition.y -= 1.1f;
        RaycastHit2D[] raycastHits2D = Physics2D.BoxCastAll(boxPosition, new Vector2(1,1), 0, new Vector2(0,0));

        isOnGround = false;
        foreach (var item in raycastHits2D)
        {
            if(item.collider.gameObject.name != "Player"){
                isOnGround = true;
            }
        }
    }
    void OnCollisionExit2D(Collision2D collider2D){
        isOnGround = false;
    }
}
