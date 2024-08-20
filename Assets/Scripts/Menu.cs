using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioSource audioS;
    public GameObject settings;
    public Slider volume;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)&&!settings.activeSelf){
            settings.SetActive(true);
            Time.timeScale = 0f;
        } else if(Input.GetKeyDown(KeyCode.Escape)&&settings.activeSelf){
            settings.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void quit(){
        audioS.Play();
        Application.Quit();
    }
    public void Fase1(){
        audioS.Play();
        SceneManager.LoadScene("Fase1");
    }
    public void config(){
        volume.value = PlayerPrefs.GetFloat("Volume");
        audioS.Play();
        settings.SetActive(true);

    }
    public void save(){
        audioS.Play();
        PlayerPrefs.SetFloat("Volume", volume.value);
        settings.SetActive(false);
    }
}
