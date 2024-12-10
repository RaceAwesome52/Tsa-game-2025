using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pausemenu : MonoBehaviour
{
    public GameObject menu;
    public bool isopen;
    public GameObject player3;
    public GameObject player4;
    // Start is called before the first frame update
    void Start()
    {
        isopen=false;
        menu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")){
            if(isopen==false){
                menu.SetActive(true);
                isopen=true;
                return;
            }
            if(isopen==true){
                menu.SetActive(false);
                isopen=false;
                return;
            }
            
        }
    }
    public void resumebutton(){
        menu.SetActive(false);
        isopen=false;
    }
    public void quitbutton(){
        SceneManager.LoadScene(0);
    }
    public void a2(){
        player3.SetActive(false);
        player4.SetActive(false);
    }
    public void a3(){
        player3.SetActive(true);
        player4.SetActive(false);
    }
    public void a4(){
        player3.SetActive(true);
        player4.SetActive(true);
    }
}
