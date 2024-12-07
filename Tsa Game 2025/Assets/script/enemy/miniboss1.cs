using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniboss1 : MonoBehaviour
{
    public GameObject fireballprojectile;
    public int randommove;
    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("themoves", 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void themoves()
    {
        randommove = Random.Range(0, 10);
        if (randommove <= 4)
        {
            summonprojectile();
        }
        if (randommove==10)
        {
            gravityswitchamove();
        }
    }
    public void summonprojectile()
    {
        Instantiate(fireballprojectile, transform.position, transform.rotation);
        Invoke("themoves", Random.Range(1, 4));
    }
    public void summonbombs()
    {
        Instantiate(bomb, transform.position, transform.rotation);
        Invoke("themoves", Random.Range(1, 4));
    }
    public void gravityswitchamove()
    {
        Invoke("themoves", Random.Range(0, 1));
    }
}
