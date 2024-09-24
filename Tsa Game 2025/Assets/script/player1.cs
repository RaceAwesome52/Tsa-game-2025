using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{   
    public Rigidbody2D player1RB;
    public Transform player1Transforms;
    public float speed;
    public float jump;
    public bool isFacingRight;
    public bool isTouchingGround;
    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //gets the inputs of the 
        float horizontal= Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetButton("Horizontal")){
            player1RB.velocity = new Vector2(horizontal * speed, player1RB.velocity.y);
        }
        if(Input.GetButton("Vertical")&&isTouchingGround==true){
            player1RB.velocity = new Vector2(player1RB.velocity.x, jump);
        }
    }
    public void Flip(){
        Vector2 currentscale = gameObject.transform.localScale;
        currentscale.x*=-1;
        gameObject.transform.localScale= currentscale;
        isFacingRight= !isFacingRight;
    }
    public void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag=="ground"){
            isTouchingGround=true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag=="ground"){
            isTouchingGround=false;
        }
    }
}
