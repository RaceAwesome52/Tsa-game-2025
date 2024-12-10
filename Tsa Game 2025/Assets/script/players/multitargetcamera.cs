using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multitargetcamera : MonoBehaviour
{

    public Vector2 offset;
    //Got tyhe code frome this guys video https://www.youtube.com/watch?v=aLpixrPvlB8
    public GameObject[] targets;
    private Vector2 velocity;
    //zero clue what smoothTime does it like makes it so the dela looks smooth
    public float smoothTime=0.5f;
    public void Start(){
        targets = GameObject.FindGameObjectsWithTag("Player");
    }
    public void/* update everyframe but after everything else*/ LateUpdate(){
        if(targets.Length==0){
            return;
        }
        Vector2 centerPoint=Getcenterpoint();
        Vector2 epicPosition=centerPoint+offset;
        //so smooth damp is a function that smooths out a vector instead of just making the position 
        //the vector it smooths it and ref is refrance with velocity and idk what smooth time is something about delays
        transform.position=Vector2.SmoothDamp(transform.position,epicPosition,ref velocity,smoothTime);
    }
    //Yoooo i didn't know i could make a vector a function
    Vector2 Getcenterpoint(){
        
        if(targets.Length==1){
            //return instantly stops a function
            return targets[0].transform.position;
        }
        //using what unity calls bounds in this function also i didn't know c# uses var
        var bounds=new Bounds(targets[0].transform.position, Vector2.zero);
        for(int i=0; i<targets.Length;i++){
            //rezizes box to fix the new target
            bounds.Encapsulate(targets[i].transform.position);
        }
        return bounds.center;
    }
    public void Update(){
        targets = GameObject.FindGameObjectsWithTag("Player");
    }
}
