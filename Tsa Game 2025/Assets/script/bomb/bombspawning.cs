using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombspawning : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bomspwan;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnboom",4.5f,4.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void spawnboom(){
        Instantiate(bombPrefab, bomspwan.position, bomspwan.rotation);
    }
}
