using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3movement : MonoBehaviour
{
    public string direction;
    public int speed;
    public Animator anim;
    public SpriteRenderer reder;
    public Rigidbody2D gravifgasdyu;
    // Start is called before the first frame update
    void Start()
    {
        speed=2;
        direction="right";
        reder.flipX=true;
        anim=this.gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == "left") {
            transform.position += speed * Time.deltaTime * -transform.right;
        }
        if (direction == "right")
        {
            transform.position += speed * Time.deltaTime * transform.right;
        }
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="ground"){
            gravifgasdyu.velocity = new Vector3(0, 0, 0);
        }
        if(other.gameObject.tag=="right movement e"){
            direction="right";
            reder.flipX=true;
        }
        if(other.gameObject.tag=="left movement e"){
            direction="left";
            reder.flipX=false;
        }
    }

    public void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag=="ground"){
            gravifgasdyu.gravityScale=0;
            
        }
    }
    public void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag=="ground"){
            gravifgasdyu.gravityScale=4;
        }
    }
}
