using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoints : MonoBehaviour
{
    public player1 p1script;
    public player2 p2script;
    public Transform falg1transform;
    public Transform falg2transform;
    public SpriteRenderer flag1render;
    public SpriteRenderer flag2render;
    public Sprite clickedflag;
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
            p1script.player1orgin=falg1transform;
            p2script.player1orgin=falg1transform;
            p1script.player2orgin=falg2transform;
            p2script.player2orgin=falg2transform;
            flag1render.sprite=clickedflag;
            flag2render.sprite=clickedflag;
        }
        
    }
}
