using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("death",5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void death(){
        Destroy(this.gameObject);
    }
}
