using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2movement : MonoBehaviour
{
    
    public Rigidbody2D thisrb;
    public int currentvelocitystate;
    // Start is called before the first frame update
    void Start()
    {
        currentvelocitystate = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentvelocitystate == 1)
        {
            thisrb.velocity = new Vector2(10f, 10f);
        }
        if (currentvelocitystate == 2)
        {
            thisrb.velocity = new Vector2(10f, -10f);
        }
        if (currentvelocitystate == 3)
        {
            thisrb.velocity = new Vector2(-10f, 10f);
        }
        if (currentvelocitystate == 4)
        {
            thisrb.velocity = new Vector2(-10f, -10f);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            if (currentvelocitystate == 1)
            {
                currentvelocitystate = 2;
                return;
            }
            if (currentvelocitystate == 2)
            {
                currentvelocitystate = 1;
                return;
            }
            if (currentvelocitystate == 3)
            {
                currentvelocitystate = 4;
                return;
            }
            if (currentvelocitystate == 4)
            {
                currentvelocitystate = 3;
                return;
            }
        }
        if (collision.gameObject.tag == "wall")
        {
            if (currentvelocitystate == 1)
            {
                currentvelocitystate = 3;
                return;
            }
            if (currentvelocitystate == 3)
            {
                currentvelocitystate = 1;
                return;
            }
            if (currentvelocitystate == 4)
            {
                currentvelocitystate = 2;
                return;
            }
            if (currentvelocitystate == 2)
            {
                currentvelocitystate = 4;
                return;
            }
        }
    }
}
