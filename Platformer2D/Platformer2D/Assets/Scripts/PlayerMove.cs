using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Exercício de Fixação
    //Script para mover o personagem!

    //1 -> Defina uma variável, de tipo ponto flutuante, acessível no Editor da Unity para controlar a velocidade de movimento do personagem.
    [SerializeField] float horizontalSpeed;
    //2 -> Defina uma variável, de tipo ponto flutuante, acessível no Editor da Unity para controlar a força de pulo do personagem.
    [SerializeField] float jumpForce;
    //3 -> Defina e pegue a referência do componente RigidBody2D usando método GetComponent
    private Rigidbody2D rb;
    //4 -> Siga as instruções de implementação em Update
    //public bool canJump;
    private Animator myAnimator;
    private SpriteRenderer sr;
    Transform groundCheck;
    [SerializeField] bool isGrounded;
    Vector2 startPosition;
    [SerializeField] int numPulos = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        groundCheck = transform.GetChild(0);
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {   

        if (Physics2D.Linecast(transform.position, groundCheck.position, LayerMask.GetMask("Ground")))
        {
            Debug.DrawLine(transform.position, groundCheck.position, Color.green);
            isGrounded = true;
            numPulos = 0;
        }
        else
        {
            Debug.DrawLine(transform.position, groundCheck.position, Color.red);
            isGrounded = false;
        }
        //5 -> Implemente o código abaixo:
        //5.1 -> Crie uma condição lógica para que: "Se o jogador segurar a tecla para Esquerda, define o Vector2 do campo velocity do Rigidbody2D (acessivel em myRigidbody.velocity, para ele mover para esquerda"
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-horizontalSpeed, rb.velocity.y);
            myAnimator.SetBool("isRunning", true);
            sr.flipX = true;
        }
        //5.2 -> Repita a condição lógica para mover para direita
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
            myAnimator.SetBool("isRunning", true);
            sr.flipX = false;
        }
        else
            myAnimator.SetBool("isRunning", false);

        //5.3 -> Repita a condição lógica para "pular"
        if (Input.GetKeyDown(KeyCode.Space) && numPulos <= 1)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            numPulos += 1;
        }
        myAnimator.SetBool("isJumping", !isGrounded);


        //Respawn: Se o jogador cair para fora da tela, volta à posição original
        if (this.transform.position.y < -5)
            this.transform.position = startPosition;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag.Contains("Floor")

    //}
}