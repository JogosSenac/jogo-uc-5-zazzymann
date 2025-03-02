using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Player2 : MonoBehaviour
{
    //A T E N Ç Ã O - CONSERTAR O CÓDIGO

    //Este personagem deve mover-se para a direita e esquerda, pular e coletar itens
    //O personagem deve ter uma animação de andar e idle
    //Ele deve morrar ao cair em um buraco

    public float moveH;
    public int velocidade;
    public int forcaPulo;
    public Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public bool isJumping = false;
    public Light2D LuzPlayer;
    public bool impulso;
    public GameObject fim;
    public AudioSource audioFundo;
    public GameObject telaRespawn;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        LuzPlayer.intensity = 0;

    }

    private void FixedUpdate() 
    {
        //Andar
        moveH = Input.GetAxis("Horizontal"); // -1 a 1
        transform.position += new Vector3(moveH * velocidade * Time.deltaTime, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Animação Andar
        if(moveH >= 0)
        {
            sprite.flipX = false;
            anim.SetLayerWeight(1,1);
        }
        
        if(moveH <= 0)
        {
            sprite.flipX = true;
            anim.SetLayerWeight(1,1);
        }
        
        if(moveH == 0)
        {
            anim.SetLayerWeight(1,0);
            anim.SetLayerWeight(0,1);   
        }
        //Pular
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(transform.up * forcaPulo,ForceMode2D.Impulse);
            isJumping = true;
            anim.SetLayerWeight(2,1);
        }
        if(isJumping == true){
            anim.SetLayerWeight(2,1);
        }else{
            anim.SetLayerWeight(2,0);
            anim.SetLayerWeight(0,1);
        }
        // Atirar
        if(Input.GetMouseButtonDown(0)&& !impulso){
            rb.AddForce(transform.up * forcaPulo,ForceMode2D.Impulse);
            impulso= true;

        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Chao"))
        {
            isJumping = false;
            impulso = false;
        }
         if(other.gameObject.CompareTag("Fim")){
            StartCoroutine(QuitGame());
            Time.timeScale = 1;
            fim.SetActive(true);
            audioFundo.mute =true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Void")){
             telaRespawn.SetActive(true);
             Destroy(this.gameObject);
        }
        if(other.gameObject.CompareTag("Fruit")){
            Destroy(other.gameObject);
            LuzPlayer.intensity = 1;
        }
    }
    IEnumerator QuitGame(){
        while (true)
        {
            yield return new WaitForSeconds(10);
            print("Quitado");
            Application.Quit();
        }
    }
}
