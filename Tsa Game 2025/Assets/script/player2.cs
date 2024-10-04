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
    public bool candash;
    public bool isdashing;
    public float dashspeed;
    public bool dashtrigger;


    // Start is called before the first frame update
    void Start()
    {
        
        candash=true;
        isFacingRight = true;
        speed = 5f;
        dashspeed=30f;
        dashtrigger=false;
    }

    // Update is called once per frame
    void Update()
    { 
        float horizontal= Input.GetAxisRaw("Horizontal2");
        float vertical = Input.GetAxisRaw("Vertical2");
        if(horizontal >0 && !isFacingRight){
            Flip();
        }else if(horizontal < 0 && isFacingRight){
            Flip();
        }
        if(isdashing==true){
            return;
        }
        //gets the inputs of the 
        
        if(Input.GetButton("Horizontal2")){
            player2RB.velocity = new Vector2(horizontal * speed, player2RB.velocity.y);
        }
        if(Input.GetButton("Vertical2")&&isTouchingGround==true){
            player2RB.velocity = new Vector2(player2RB.velocity.x, jump);
        }
        if(Input.GetButtonDown("Horizontal2")){  
            if(dashtrigger==true&&candash==true){
                dashtrigger=false;
                StartCoroutine(dash());
                return;
            }
            dashtrigger=true;
            Invoke("falseify",0.4f);
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

    public IEnumerator dash(){
        candash=false;
        isdashing=true;
        float oggravity=player2RB.gravityScale;
        player2RB.gravityScale=0f;
        player2RB.velocity=new Vector2(transform.localScale.x*dashspeed,0f);
        yield return new WaitForSeconds(0.4f);
        player2RB.gravityScale=oggravity;
        isdashing=false;
        yield return new WaitForSeconds(1.4f);
        candash=true;
    }
    public void falseify(){
        if(isdashing==false){
        dashtrigger=false;
        }
    }
}
