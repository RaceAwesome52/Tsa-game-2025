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
    public GameObject worldselect;
    public AudioSource audio;
    public AudioSource musicaudio;
    public AudioClip audioclipthing;
    public AudioClip titlemusuic;
    public AudioClip selectmusic;
    public void Start(){
        musicaudio.clip=titlemusuic;
        musicaudio.Play();
        audio.clip=audioclipthing;
    }
    public void play(){
        creditsbutton.SetActive(false);
        levelselectbutton.SetActive(false);
        howButton.SetActive(false);
        worldselect.SetActive(true);
        backbutton.SetActive(true);
        musicaudio.clip=selectmusic;
        musicaudio.Stop();
        musicaudio.Play();
        audio.Play();
    }
    public void credbutt()
    {
        creds.SetActive(true);
        creditsbutton.SetActive(false);
        levelselectbutton.SetActive(false);
        howButton.SetActive(false);
        backbutton.SetActive(true);
        audio.Play();
    }
    public void backbuttoclciked(){
        creditsbutton.SetActive(true);
        levelselectbutton.SetActive(true);
        howButton.SetActive(true);
        worldselect.SetActive(false);
        backbutton.SetActive(false);
        creds.SetActive(false);
        audio.Play();
        if(musicaudio.clip==selectmusic){
            musicaudio.clip=titlemusuic;
            musicaudio.Stop();
            musicaudio.Play();
        }
    }
    public void howtoplay(){
        audio.Play();
    }
    public void level1(){
        SceneManager.LoadScene(1);
        audio.Play();
    }
    public void level2(){
        SceneManager.LoadScene(2);
        audio.Play();
    }
    public void level3(){
        SceneManager.LoadScene(3);
        audio.Play();
    }
    public void level4(){
        SceneManager.LoadScene(4);
        audio.Play();
    }
    public void level5(){
        SceneManager.LoadScene(5);
        audio.Play();
    }
    public void level6(){
        SceneManager.LoadScene(6);
        audio.Play();
    }
    public void level7(){
        SceneManager.LoadScene(7);
        audio.Play();
    }
}
