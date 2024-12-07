using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3movement : MonoBehaviour
{
    public string direction;
    public int speed;
    public Animator anim;
    public SpriteRenderer reder;
    // Start is called before the first frame update
    void Start()
    {
        speed=2;
        direction="right";
        reder.flipX=true;
        anim.SetInteger("",2);
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
        if(other.tag=="right movement e"){
            direction="right";
            reder.flipX=true;
        }
        if(other.tag=="left movement e"){
            direction="left";
            reder.flipX=false;
        }
    }
}
