using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pausemenu : MonoBehaviour
{
    public GameObject menu;
    public bool isopen;
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
}
