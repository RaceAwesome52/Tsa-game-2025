using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoints : MonoBehaviour
{
    public player1 p1script;
    public player2 p2script;
    public player3 p3script;
    public player4 p4script;
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
            p3script.player1orgin=falg1transform;
            p4script.player1orgin=falg1transform;

            p1script.player2orgin=falg2transform;
            p2script.player2orgin=falg2transform;
            p3script.player2orgin=falg2transform;
            p4script.player2orgin=falg1transform;

            p1script.player3orgin=falg1transform;
            p2script.player3orgin=falg1transform;
            p3script.player3orgin=falg1transform;
            p4script.player3orgin=falg1transform;

            p1script.player4orgin=falg2transform;
            p2script.player4orgin=falg2transform;
            p3script.player4orgin=falg2transform;
            p4script.player4orgin=falg2transform;

            flag1render.sprite=clickedflag;
            flag2render.sprite=clickedflag;
        }
        
    }
}
