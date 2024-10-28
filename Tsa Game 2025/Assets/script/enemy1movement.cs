using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1movement : MonoBehaviour
{
    public string direction;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        speed=3;
        direction="right";
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == "left") {
            transform.position += speed * Time.deltaTime * -transform.right;
            Vector2 currentscale = transform.localScale;
            currentscale.x = 1f;
            transform.localScale = currentscale;
        }
        if (direction == "right")
        {
            transform.position += speed * Time.deltaTime * transform.right;
            Vector2 currentscale = transform.localScale;
            currentscale.x = -1f;
            transform.localScale = currentscale;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="right movement"){
            direction="right";
        }
        if(other.tag=="left movement"){
            direction="left";
        }
    }
}
