using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menubutton : MonoBehaviour
{
    public GameObject creds;
    public GameObject levelselectbutton;
    public GameObject levekselekscreen;
    public GameObject creditsbutton;
    public GameObject backbutton;
    public GameObject howButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play(){
        SceneManager.LoadScene(1);
    }
    public void credbutt()
    {
        creds.SetActive(true);
        creditsbutton.SetActive(false);
        levelselectbutton.SetActive(false);
        howButton.SetActive(false);
    }
    public void howtoplay(){

    }
}
