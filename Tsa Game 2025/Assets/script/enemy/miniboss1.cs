using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniboss1 : MonoBehaviour
{
    public GameObject player;
    public GameObject fireballprojectile;
    public int randommove;
    public GameObject bomb;
    public Animator boss1anim;
    public Vector2 bombpos;
    public GameObject[] targets;
    public SpriteRenderer sprite;
    public Rigidbody2D playerrigidbody;
    public Transform spawnguypos1;
    public Transform spawnguypos2;
    public Transform spawnguypos3;
    public GameObject guytospawn1;
    public GameObject bounceguy;
    public int health = 3;
    public GameObject wintext;
    public hat hatcode;
    // Start is called before the first frame update
    void Start()
    {
        wintext.SetActive(false);
        targets = GameObject.FindGameObjectsWithTag("Player");
        Invoke("themoves", 5f);
        player = targets[Random.Range(0, targets.Length)];
        boss1anim.SetInteger("state",0);
    }

    // Update is called once per frame
    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("Player");
        if(health<=0){
            boss1anim.SetInteger("state",3);
            CancelInvoke("themoves");
            CancelInvoke("idle");
            Invoke("destruction",3f);
        }
    }
    public void themoves()
    {
        randommove = Random.Range(0, 12);
        if (randommove <= 4)
        {
            summonprojectile();
        }
        if(randommove>=5 && randommove<=7){
            summonbombs();
        }
        if(randommove>=8 && randommove<=9){
            spawnguys();
        }
        if (randommove==10)
        {
            gravityswitchamove();
        }
        if (randommove==11 ||randommove==12)
        {
            spawnbounceguy();
        }
    }
    public void summonprojectile()
    {
        boss1anim.SetInteger("state",1);
        Instantiate(fireballprojectile, transform.position, transform.rotation);
        Invoke("idle",2f);
        Invoke("themoves", Random.Range(1, 4));
        
    }
    public void summonbombs()
    {
        boss1anim.SetInteger("state",1);
        randommove = Random.Range(1, 2);
        if(randommove==1){
            bombpos=new Vector2(transform.position.x+4,transform.position.y);
            Instantiate(bomb, bombpos, transform.rotation);
            bombpos=new Vector2(transform.position.x+8,transform.position.y);
            Instantiate(bomb,bombpos, transform.rotation);
            bombpos=new Vector2(transform.position.x+12,transform.position.y);
            Instantiate(bomb, bombpos, transform.rotation);
        }
        if(randommove==2){
            bombpos=new Vector2(transform.position.x-4,transform.position.y);
            Instantiate(bomb, bombpos, transform.rotation);
            bombpos=new Vector2(transform.position.x-8,transform.position.y);
            Instantiate(bomb,bombpos, transform.rotation);
            bombpos=new Vector2(transform.position.x-12,transform.position.y);
            Instantiate(bomb, bombpos, transform.rotation);
        }
        Invoke("idle",1f);
        Invoke("themoves", Random.Range(2, 5));
    }
    public void gravityswitchamove()
    {
        boss1anim.SetInteger("state",2);
        playerrigidbody=player.GetComponent<Rigidbody2D>();
        sprite=player.GetComponent<SpriteRenderer>();
        playerrigidbody.gravityScale *= -1;
        if(player.name=="player3"){
            hatcode.p3hatswap();
        }
        if(player.name=="player4"){
            hatcode.p4hatswap();
        }
        if(sprite.flipY==false){
            sprite.flipY=true;
            return;
        }
        if(sprite.flipY==true){
            sprite.flipY=false;
            return;
        }
        player = targets[Random.Range(0, targets.Length)];
        Invoke("idle",1f);
        Invoke("themoves", Random.Range(1, 2));
    }
    public void spawnguys(){
        Instantiate(guytospawn1, spawnguypos1.position, transform.rotation);
        Instantiate(guytospawn1, spawnguypos2.position, transform.rotation);
        Invoke("themoves", Random.Range(3, 6));
    }
    public void spawnbounceguy(){
        Instantiate(bounceguy, spawnguypos3.position, transform.rotation);
        Invoke("themoves", Random.Range(2, 6));
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="antibossbomb"){
            CancelInvoke("themoves");
            health--;
            for(int i = 0; i<targets.Length; i++){
                player=targets[i];
                playerrigidbody=player.GetComponent<Rigidbody2D>();
                sprite=player.GetComponent<SpriteRenderer>();
                sprite.flipY=false;
                playerrigidbody.gravityScale = 3;
                hatcode.p3hatreset();
                hatcode.p4hatreset();
            }
            Invoke("themoves", 3f);
        }
        
    }
    public void destruction(){
        wintext.SetActive(true);
        Destroy(gameObject);
    }
    public void idle(){
        boss1anim.SetInteger("state",0);
    }
}