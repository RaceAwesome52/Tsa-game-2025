using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazershoot : MonoBehaviour
{
    public GameObject lazerPrefab;
    public Transform lazerspawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LAZERBLAST",4.5f,4.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LAZERBLAST(){
        Instantiate(lazerPrefab, lazerspawn.position, lazerspawn.rotation);
    }
}
