using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    public Text timer_text;
    public float timer;
    public bool contando = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(contando){
            timer += Time.deltaTime;
            timer_text.text = timer.ToString("#0");
        }
    }
    public void activeTimer(bool a){
        contando = a;
    }
}
