using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{   
    public Rigidbody2D player2RB;
    public Rigidbody2D player1RB;
    public Transform player2Transforms;
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
    public Animator anim2;
    public SpriteRenderer render;
    public SpriteRenderer otherrender;
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
        float horizontal2= Input.GetAxisRaw("Horizontal2");
        float vertical2 = Input.GetAxisRaw("Vertical2");
        if(horizontal2 >0 && !isFacingRight){
            Flip();
        }else if(horizontal2 < 0 && isFacingRight){
            Flip();
        }
        if(isdashing==true){
            return;
        }
        //gets the inputs of the 
        if(Input.GetButton("Horizontal2")){
            
            player2RB.velocity = new Vector2(horizontal2 * speed, player2RB.velocity.y);
            if(horizontal2==1){
                anim2.SetInteger("state2",3);
            }
            if(horizontal2==-1){
                anim2.SetInteger("state2",4);
            }
        }
        if(Input.GetButton("Vertical2")&&isTouchingGround==true){
            anim2.SetInteger("state2",2);
            if(render.flipY==true){
                player2RB.velocity = new Vector2(player2RB.velocity.x, -jump);
                return;
            }
            if(render.flipY==false){
                player2RB.velocity = new Vector2(player2RB.velocity.x, jump);
                return;
            }
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
        if(!Input.GetButton("Horizontal2")&&!Input.GetButton("Vertical2")&&isdashing==false){
            anim2.SetInteger("state2",1);
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
            player1object.transform.position=player1orgin.position;
            player2object.transform.position=player2orgin.position;
        }
    }
    public void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag=="ground"||collision.gameObject.tag=="BOX"){
            isTouchingGround=false;
        }
    }
    public void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag=="hurt"){
            render.flipY=false;
            otherrender.flipY=false;
            player2RB.gravityScale = 5;
            player1RB.gravityScale = 5;
            player1object.transform.position=player1orgin.position;
            player2object.transform.position=player2orgin.position;
        }
        if(other.gameObject.tag=="enemy" && isdashing==true){
            Destroy(other.gameObject);
        }else if(other.gameObject.tag=="enemy"&& isdashing==false){ 
            render.flipY=false;
            otherrender.flipY=false;
            player2RB.gravityScale = 5;
            player1RB.gravityScale = 5;
            player1object.transform.position=player1orgin.position;
            player2object.transform.position=player2orgin.position;
        }
        if(other.gameObject.tag=="eraser"){
            if(player2RB.velocity.y <-1){
                Destroy(other.gameObject);
                return;
            }
            print("hello");
            render.flipY=false;
            otherrender.flipY=false;
            player2RB.gravityScale = 5;
            player1RB.gravityScale = 5;
            player1object.transform.position=player1orgin.position;
            player2object.transform.position=player2orgin.position;
        }
    }
    public IEnumerator dash(){
        anim2.SetInteger("state2",5);
        candash=false;
        isdashing=true;
        float oggravity=player2RB.gravityScale;
        player2RB.gravityScale=0.01f;
        if(isFacingRight==true){
            player2RB.velocity=new Vector2(1*dashspeed,0f);
        }
        if(isFacingRight==false){
            render.flipX=true;
            player2RB.velocity=new Vector2(-1*dashspeed,0f);
        }
        yield return new WaitForSeconds(0.4f);
        if(player2RB.gravityScale<0){
            player2RB.gravityScale=oggravity*-1;
        }else{
            player2RB.gravityScale=oggravity;
        }
        isdashing=false;
        anim2.SetInteger("state2",1);
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
