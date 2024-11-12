using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorbuttonthing : MonoBehaviour
{
    public GameObject door;
    public Animator anim;
    public Animator dooranim;
    public AudioSource buttonsound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionStay2D(Collision2D collision){
        buttonsound.Play();
        if(collision.gameObject.tag=="Player" || collision.gameObject.tag=="Box"){
            //temp do animation later
            anim.SetBool("isdown",true);
            dooranim.SetBool("active",true);
            
        }
    }
    public void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag=="Player"||collision.gameObject.tag=="Box"){
            //temp do animation later
            anim.SetBool("isdown",false);
            dooranim.SetBool("active",false);
            buttonsound.Stop();
        }
    }
}
