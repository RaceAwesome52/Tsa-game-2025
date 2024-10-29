using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class keyscript : MonoBehaviour
{
    public GameObject door;
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
            //destroys the door...for now play an animation later
            Destroy(door);
            Destroy(this.gameObject);
        }
    }
}
