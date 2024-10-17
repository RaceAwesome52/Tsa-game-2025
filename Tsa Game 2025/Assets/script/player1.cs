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
    public bool candash;
    public bool isdashing;
    public float dashspeed;
    public bool dashtrigger;
    public GameObject player2object;
    public GameObject player1object;
    public Transform player1orgin;
    public Transform player2orgin;

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
        float horizontal= Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if(horizontal >0 && !isFacingRight){
            Flip();
        }else if(horizontal < 0 && isFacingRight){
            Flip();
        }
        if(isdashing==true){
            return;
        }
        //gets the inputs of the 
        
        if(Input.GetButton("Horizontal")){
            player1RB.velocity = new Vector2(horizontal * speed, player1RB.velocity.y);
        }
        if(Input.GetButton("Vertical")&&isTouchingGround==true){
            player1RB.velocity = new Vector2(player1RB.velocity.x, jump);
        }
        if(Input.GetButtonDown("Horizontal")){
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
        if(collision.gameObject.tag=="ground"||collision.gameObject.tag=="BOX"){
            isTouchingGround=true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag=="ground"||collision.gameObject.tag=="BOX"){
            isTouchingGround=false;
        }
    }
    public void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag=="hurt"){
            player1object.transform.position=player1orgin.position;
            player2object.transform.position=player2orgin.position;
        }
    }

    public IEnumerator dash(){
        candash=false;
        isdashing=true;
        float oggravity=player1RB.gravityScale;
        player1RB.gravityScale=0f;
        player1RB.velocity=new Vector2(transform.localScale.x*dashspeed,0f);
        yield return new WaitForSeconds(0.4f);
        player1RB.gravityScale=oggravity;
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
