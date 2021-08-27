using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{

    private int _totalPontos = 0;
    private int _vidas = 10;

    private Animator animator;

    private float moveInput;

    private bool facingRight = true;

    private bool isGrounded = true;

    private bool isMoving = false;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float jumpHeight = 4f;
    public float maxSpeed = 2f;

    private Rigidbody2D rb;


    public int Vidas
    {
        get { return _vidas; }
    }

    public int Pontos
    {
        get { return _totalPontos; }
    }

    public void TiraPontos(int pontos)
    {
        _totalPontos -= pontos;
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
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpHeight;
        } 

        if (isMoving)
            animator.SetBool("isRunning", true);
        else
            animator.SetBool("isRunning", false);

    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * maxSpeed, rb.velocity.y);

        isMoving = !Mathf.Approximately(rb.velocity.magnitude, 0f);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if(facingRight == true && moveInput < 0 )
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
}
