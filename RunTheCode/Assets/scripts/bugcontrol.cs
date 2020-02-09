using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugcontrol : MonoBehaviour
{
    public Rigidbody2D  rb;
    public Animator Anime;
    public float velocidade;
    public bool esquerda, voar, ataque;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //FAZ ELE ANDAR DE UM LADO PRO OUTRO
        if(esquerda){
            rb.velocity = new Vector2(velocidade, rb.velocity.y);
            //transform.Translate(Vector2.left * -velocidade * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;
            StartCoroutine("voarasvezes");
        }else{
            rb.velocity = new Vector2(-velocidade, rb.velocity.y);
            //transform.Translate(Vector2.left * velocidade * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //FAZ ELE VOAR
        if(voar){
            Anime.SetBool("animvoar", true);
            if(rb.position.y < 0.39f){
                rb.velocity = new Vector2(rb.velocity.x, 2f);
            }
        }else{
            Anime.SetBool("animvoar", false);
        }
    

    }
    //AÇÃO AO COLIDIR
    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "esquerdo"){
            esquerda = true;
        }
        if(other.name == "direito"){
            esquerda = false;
        }
    }
    //ALTERNAR 1s ENTRE AS AÇÕES
    public IEnumerator voarasvezes(){
        voar = true;
        yield return new WaitForSeconds(1.0f);
        voar = false;
    }
}
