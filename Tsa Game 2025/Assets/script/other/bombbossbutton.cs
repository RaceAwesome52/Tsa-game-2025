using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombbossbutton : MonoBehaviour
{
    public Animator anim;
    public AudioSource buttonsound;
    public GameObject specialboom;
    public Transform bomspwan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision){
        
        if(collision.gameObject.tag=="Player"){
            anim.SetBool("isdown",true);
            buttonsound.Play();
            Instantiate(specialboom, bomspwan.position, bomspwan.rotation);
        }
    }
    public void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag=="Player"){
            anim.SetBool("isdown",false);
            buttonsound.Stop();
        }
    }
}
