using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{

    private int _totalPontos = 0;
    private int _vidas = 10;

    private Animator animator;

    private bool facingRight = true;

    private bool isGrounded = true;

    public float jumpHeight = 6.5f;
    public float maxSpeed = 3f;

    private float moveDirection = 0f;

    private Rigidbody2D rb;


    public int Vidas
    {
        get { return _vidas; }
    }

    public int Pontos
    {
        get { return _totalPontos; }
    }

    public void TiraVida(int vidasPerdidas)
    {
        if (_vidas > 0)
            _vidas -= vidasPerdidas;
    }

    public void AddPontos(int pontos)
    {
        _totalPontos += pontos;
    }

    private void Update()
    {

        // Movement controls
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (isGrounded || Mathf.Abs(rb.velocity.x) > 0.01f))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
            animator.SetBool("isRunning", true);
        }
        else
        {
            if (isGrounded || rb.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
                animator.SetBool("isRunning", false);
            }
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            rb.velocity = Vector2.up * jumpHeight;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2((moveDirection) * maxSpeed, rb.velocity.y);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
}
