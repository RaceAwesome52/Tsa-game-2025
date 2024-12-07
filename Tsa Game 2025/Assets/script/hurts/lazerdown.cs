using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerdown : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += speed * Time.deltaTime * -transform.up;
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="destroy"){
            Destroy(this.gameObject);
        }
    }
}
