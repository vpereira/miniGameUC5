using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{

    private int _totalPontos = 0;
    private int _vidas = 10;

    private Animator animator;

    private float moveInput;

    private bool jump = false;

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
        // Se os pontos forem =< 0 reload a cena
        if(_vidas <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump = true;
        } 

        moveInput = Input.GetAxis("Horizontal");

        if (isMoving)
            animator.SetBool("isRunning", true);
        else
            animator.SetBool("isRunning", false);

    }

    private void Jump()
    {
        if(jump)
        {
            rb.velocity = Vector2.up * jumpHeight;
            jump = false;
        }

    }

    private void Move()
    {
        rb.velocity = new Vector2(moveInput * maxSpeed, rb.velocity.y);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isMoving = !Mathf.Approximately(rb.velocity.magnitude, 0f);

        if(isGrounded)
        {
            Jump();
        }

        Move();


        if(!facingRight && moveInput > 0)
        {
            Flip();
        } else if(facingRight && moveInput < 0 )
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
