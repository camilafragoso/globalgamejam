using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public static bool isDashing;
    public float velocidade;
    public float forcaPulo;
    public float forcaDash;
    public float tempoDash;
    private bool verificaChao;
    private bool ladoDash;
    public Transform chaoVerificador;
    public Rigidbody2D rb;
    //public GameObject telagameover;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
        Fazer_Dash();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //MORRER AO BATER NO BUG SEM DASH
        var bug = other.GetComponent<bugcontrol>();
        if(bug)
        {
            if(!isDashing)
            {
                Destroy(gameObject);
                //telagameover.SetActive(true);
                SceneManager.LoadScene("Main_Manu");
            }
            else
            {
                Destroy(bug.gameObject);
            }
    
        }
    }

    void Movimentacao()
    {
        verificaChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Chao"));


        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            GetComponentInChildren<SpriteRenderer>().flipX = false;
            GetComponentInChildren<Animator>().SetBool("run", true);
            ladoDash = false;
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
            GetComponentInChildren<SpriteRenderer>().flipX = true;
            GetComponentInChildren<Animator>().SetBool("run", true);
            ladoDash = true;
        }

        else
        {
            GetComponentInChildren<Animator>().SetBool("run", false);
        }

        if (Input.GetButtonDown("Jump") && verificaChao)
        {
            GetComponentInChildren<Rigidbody2D>().AddForce(transform.up * forcaPulo);
            //GetComponentInChildren<Animator>().SetTrigger("jump");
        }

    }

    void Fazer_Dash()
    {
        if (Input.GetButtonDown("Dash") && ladoDash == true)
        {
            isDashing = true;
            GetComponentInChildren<Animator>().SetTrigger("bottomDash");
            GetComponentInChildren<Rigidbody2D>().AddForce(-transform.right * forcaDash);
            Invoke("Stop_dash", tempoDash);

        }

        if (Input.GetButtonDown ("Dash") && ladoDash == false)
        {
            isDashing = true;
            GetComponentInChildren<Animator>().SetTrigger("bottomDash");
            GetComponentInChildren<Rigidbody2D>().AddForce(transform.right * forcaDash);
            Invoke("Stop_dash", tempoDash);
        }
    
    }

    void Stop_dash()
    {
        rb.velocity = Vector2.zero;
        isDashing = false;
        //GetComponentInChildren<Animator>().SetTrigger("bottomDash");
    }
}