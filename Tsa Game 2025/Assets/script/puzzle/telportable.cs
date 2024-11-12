using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telportable : MonoBehaviour
{
    public Transform  placetoteleport;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "teleporter")
        {
            placetoteleport = collision.gameObject.transform.parent.GetChild(0).transform;
            if (placetoteleport == collision.gameObject.transform)
            {
                placetoteleport = collision.gameObject.transform.parent.GetChild(1).transform;
            }
            Invoke("TELE",3F);
            print("invoked");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "teleporter"){
            print("nowork");
            CancelInvoke("TELE");
        }
        
    }
    public void TELE()
    {
        this.gameObject.transform.position = new Vector3(placetoteleport.position.x, placetoteleport.position.y + 1f, 65f);
    }
}
