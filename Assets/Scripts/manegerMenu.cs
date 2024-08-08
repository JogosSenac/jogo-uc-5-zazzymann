using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
public class manegerMenu : MonoBehaviour
{
    public Button volumeButton;
    public Canvas menuSettings;
    public Slider sliderMenu;
    public bool mute = false;
    
    // Start is called before the first frame update
    void Start()
    {
        menuSettings.enabled = false;
        if(volumeButton == null||sliderMenu == null){
            Debug.LogWarning("Volume Button ou Slidder Menu não setados, procure em Maneger e os coloque");
        }    
    }
    // Update is called once per frame
    void Update()
    {
        if(sliderMenu != null){
             PlayerPrefs.SetFloat("volume",sliderMenu.value);
        }
        if(Input.GetKeyUp(KeyCode.Escape)){
            Debug.Log(sliderMenu.value);
            Debug.Log(mute);
        }
    }
    public void muteFunc(){
        if(mute){
            mute = false;
        }else{
            mute = true;
        }
        
    }
    public void voltarButton(){
            menuSettings.enabled = false;
    }
    public void aparecerMenu(){
        menuSettings.enabled = true;
    }
    public void fase1(){
        SceneManager.LoadScene(1);
    }
    public void Quit(){
        Application.Quit();
    }
}
