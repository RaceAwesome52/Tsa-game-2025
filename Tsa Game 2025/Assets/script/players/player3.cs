﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player3 : MonoBehaviour
{
    public Rigidbody2D player1RB;
    public Rigidbody2D player2RB;
    public Rigidbody2D player3RB;
    public Rigidbody2D player4RB;
    public Transform player3Transforms;
    public float speed;
    public float jump;
    public bool isFacingRight;
    public bool isTouchingGround;
    public bool candash;
    public bool isdashing;
    public float dashspeed;
    public bool dashtrigger;
    public GameObject player2object;
    public GameObject player1object;
    public GameObject player3object;
    public GameObject player4object;
    public Transform player1orgin;
    public Transform player2orgin;
    public Transform player3orgin;
    public Transform player4orgin;
    public Animator anim;
    public SpriteRenderer render;
    public SpriteRenderer otherrender;
    public SpriteRenderer otherrender2;
    public SpriteRenderer otherrender3;
    public hat hatcode;
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
        float horizontal= Input.GetAxisRaw("Horizontal3");
        float vertical = Input.GetAxisRaw("Vertical3");
        if(horizontal >0 && !isFacingRight){
            Flip();
        }else if(horizontal < 0 && isFacingRight){
            Flip();
        }
        if(isdashing==true){
            return;
        }
        //gets the inputs of the 
        
        if(Input.GetButton("Horizontal3")){
            player3RB.velocity = new Vector2(horizontal * speed, player3RB.velocity.y);
            if(horizontal==1){
                anim.SetInteger("state",3);
            }
            if(horizontal==-1){
                anim.SetInteger("state",4);
            }
        }
        if(Input.GetButton("Vertical3")&&isTouchingGround==true){
            anim.SetInteger("state",2);
            if(render.flipY==true){
                player3RB.velocity = new Vector2(player3RB.velocity.x, -jump);
                return;
            }
            if(render.flipY==false){
                player3RB.velocity = new Vector2(player3RB.velocity.x, jump);
                return;
            }
        }
        if(Input.GetButtonDown("Horizontal3")){
            if(dashtrigger==true&&candash==true){
                dashtrigger=false;
                StartCoroutine(dash());
                return;
            }
            dashtrigger=true;
            Invoke("falseify",0.4f);
        }
        if(!Input.GetButton("Horizontal3")&&!Input.GetButton("Vertical3")&&isdashing==false){
            anim.SetInteger("state",1);
        }
    }
    public void Flip(){
        //Vector2 currentscale = gameObject.transform.localScale;
        //currentscale.x*=-1;
        //gameObject.transform.localScale= currentscale;
        isFacingRight= !isFacingRight;
    }
    public void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag=="ground"||collision.gameObject.tag=="BOX"){
            isTouchingGround=true;
        }
        if(collision.gameObject.tag=="enemy" && isdashing==true){
            Destroy(collision.gameObject);
        }else if(collision.gameObject.tag=="enemy"){
            resetplayers();
        }
    }
    public void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag=="ground"||collision.gameObject.tag=="BOX"){
            isTouchingGround=false;
        }
    }
    public void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag=="hurt"){
            resetplayers();
        }
        if(other.gameObject.tag=="enemy" && isdashing==true){
            Destroy(other.gameObject);
        }else if(other.gameObject.tag=="enemy"&& isdashing==false){
            resetplayers();
        }
        if(other.gameObject.tag=="eraser"){
            if(player3RB.velocity.y <-1){
                Destroy(other.gameObject);
                return;
            }
            resetplayers();
        }

    }

    public IEnumerator dash(){
        anim.SetInteger("state",5);
        candash=false;
        isdashing=true;
        float oggravity=player3RB.gravityScale;
        player3RB.gravityScale=0.01f;
        if(isFacingRight==true){
            player3RB.velocity=new Vector2(1*dashspeed,0f);
        }
        if(isFacingRight==false){
            render.flipX=true;
            player3RB.velocity=new Vector2(-1*dashspeed,0f);
        }
        yield return new WaitForSeconds(0.4f);
        if(player3RB.gravityScale<0){
            player3RB.gravityScale=oggravity*-1;
        }else{
            player3RB.gravityScale=oggravity;
        }
        isdashing=false;
        anim.SetInteger("state",1);
        yield return new WaitForSeconds(1.4f);
        candash=true;
        render.flipX=false;
    }
    public void falseify(){
        if(isdashing==false){
            dashtrigger=false;
        }
    }
    public void resetplayers(){
        render.flipY=false;
        otherrender.flipY=false;
        otherrender2.flipY=false;
        otherrender3.flipY=false;
        player2RB.gravityScale = 5;
        player1RB.gravityScale = 5;
        player3RB.gravityScale = 5;
        player4RB.gravityScale = 5;
        player1object.transform.position=player1orgin.position;
        player2object.transform.position=player2orgin.position;
        player3object.transform.position=player3orgin.position;
        player4object.transform.position=player4orgin.position;
        hatcode.p3hatreset();
        hatcode.p4hatreset();
    }
}
