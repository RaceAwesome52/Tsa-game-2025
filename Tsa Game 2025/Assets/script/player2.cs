using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{   
    public Rigidbody2D player2RB;
    public Transform player2Transforms;
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
        //gets the inputs of the player
        float horizontal= Input.GetAxisRaw("Horizontal2");
        float vertical = Input.GetAxisRaw("Vertical2");
        if(Input.GetButton("Horizontal2")){
            player2RB.velocity = new Vector2(horizontal * speed, player2RB.velocity.y);
        }
        if(Input.GetButton("Vertical2")&&isTouchingGround==true){
            player2RB.velocity = new Vector2(player2RB.velocity.x, jump);
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
