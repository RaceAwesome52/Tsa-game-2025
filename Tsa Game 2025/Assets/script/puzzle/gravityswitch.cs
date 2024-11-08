using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityswitch : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Rigidbody2D playerrigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            print("please");
            playerrigidbody=other.gameObject.GetComponent<Rigidbody2D>();
            sprite=other.gameObject.GetComponent<SpriteRenderer>();
            playerrigidbody.gravityScale *= -1;
            if(sprite.flipY==false){
                sprite.flipY=true;
                return;
            }
            if(sprite.flipY==true){
                sprite.flipY=false;
                return;
            }
        }
    }
    
}
