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
    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Player");
        Invoke("themoves", 5f);
        player = targets[Random.Range(0, targets.Length)];
    }

    // Update is called once per frame
    void Update()
    {

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
        Instantiate(fireballprojectile, transform.position, transform.rotation);
        Invoke("themoves", Random.Range(1, 4));
    }
    public void summonbombs()
    {
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
        
        Invoke("themoves", Random.Range(2, 5));
    }
    public void gravityswitchamove()
    {
        playerrigidbody=player.GetComponent<Rigidbody2D>();
        sprite=player.GetComponent<SpriteRenderer>();
        playerrigidbody.gravityScale *= -1;
        if(sprite.flipY==false){
            sprite.flipY=true;
            return;
        }
        if(sprite.flipY==true){
            sprite.flipY=false;
            return;
        }
        player = targets[Random.Range(0, targets.Length)];
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
}
