﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public GameObject player;
    public int speed;
    public bool idkwhattocallthis;
    public Vector2 get;
    public GameObject[] targets;
    // Start is called before the first frame update
    void Start()
    {
        idkwhattocallthis = false;
        targets = GameObject.FindGameObjectsWithTag("Player");
        player = targets[Random.Range(0, targets.Length)];
        get = new Vector2(player.transform.position.x * 3, player.transform.position.y * 3);
        Invoke("truify", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, get, speed * Time.deltaTime);
        if (idkwhattocallthis == false)
        {
            get = new Vector2(player.transform.position.x * 3, player.transform.position.y * 3);
        }
    }
    public void truify()
    {
        idkwhattocallthis = true;
    }
}
