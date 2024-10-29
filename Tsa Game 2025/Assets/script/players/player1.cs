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
    public Animator anim;
    public SpriteRenderer render;
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
            if(horizontal==1){
                anim.SetInteger("state",3);
            }
            if(horizontal==-1){
                anim.SetInteger("state",4);
            }
        }
        if(Input.GetButton("Vertical")&&isTouchingGround==true){
            player1RB.velocity = new Vector2(player1RB.velocity.x, jump);
            anim.SetInteger("state",2);
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
        if(!Input.GetButton("Horizontal")&&!Input.GetButton("Vertical")&&isdashing==false){
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
        if(other.gameObject.tag=="enemy" && isdashing==true){
            Destroy(other.gameObject);
        }else if(other.gameObject.tag=="enemy"&& isdashing==false){
            player1object.transform.position=player1orgin.position;
            player2object.transform.position=player2orgin.position;
        }
    }

    public IEnumerator dash(){
        anim.SetInteger("state",5);
        candash=false;
        isdashing=true;
        float oggravity=player1RB.gravityScale;
        player1RB.gravityScale=0f;
        if(isFacingRight==true){
            player1RB.velocity=new Vector2(1*dashspeed,0f);
        }
        if(isFacingRight==false){
            render.flipX=true;
            player1RB.velocity=new Vector2(-1*dashspeed,0f);
        }

        yield return new WaitForSeconds(0.4f);
        player1RB.gravityScale=oggravity;
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
}
