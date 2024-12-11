using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hat : MonoBehaviour
{
    public GameObject hat31;
    public GameObject hat32;
    public GameObject hat41;
    public GameObject hat42;
    public bool ishat3fliped;
    public bool ishat4fliped;
    void Start(){
        ishat3fliped=false;
        ishat4fliped=false;
    }
    public void p3hatswap(){
        if(ishat3fliped==false){
            hat31.SetActive(false);
            hat32.SetActive(true);
            ishat3fliped=true;
            return;
        }
        if(ishat3fliped==true){
            hat31.SetActive(true);
            hat32.SetActive(false);
            ishat3fliped=false;
            return;
        }
    }
    public void p4hatswap(){
        if(ishat4fliped==false){
            hat41.SetActive(false);
            hat42.SetActive(true);
            ishat4fliped=true;
            return;
        }
        if(ishat4fliped==true){
            hat41.SetActive(true);
            hat42.SetActive(false);
            ishat4fliped=false;
            return;
        }
    }
    public void p3hatreset(){
        hat31.SetActive(true);
        hat32.SetActive(false);
        ishat3fliped=false;
    }
    public void p4hatreset(){
        hat41.SetActive(true);
        hat42.SetActive(false);
        ishat4fliped=false;
    }
}
