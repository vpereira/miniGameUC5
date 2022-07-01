using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{

    private int _totalPontos = 0;
    private int _maxVidas = 10;
    private int _vidas = 0;

    private Animator animator;
    private BoxCollider2D bc;

    private float moveInput;

    private bool facingRight = true;

    private bool isMoving = false;

    public LayerMask whatIsGround;

    public float jumpHeight = 4f;
    public float maxSpeed = 2f;

    private float hitTimer = 1f;

    private Rigidbody2D rb;

    public SliderControl healthbar;


    private void Start()
    {
        _vidas = _maxVidas;

        healthbar.SetHealth(_vidas, _maxVidas);
    }
    public int Vidas
    {
        get { return _vidas; }
    }

    public int MaxVidas
    {
        get { return _maxVidas; }
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
        healthbar.SetHealth(_vidas, _maxVidas);
        animator.SetBool("hit", true);

        if (_vidas > 0)
            _vidas -= vidasPerdidas;
    }

    public void AddPontos(int pontos)
    {
        _totalPontos += pontos;
    }

    private void Update()
    {

        // Se as vidas forem =< 0 reload a cena
        if (_vidas <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jump();
        }

        moveInput = Input.GetAxis("Horizontal");

        isMoving = !Mathf.Approximately(rb.velocity.magnitude, 0f);

        if (isMoving)
            animator.SetBool("isRunning", true);
        else
            animator.SetBool("isRunning", false);

        if (animator.GetBool("hit"))
        {
            if (hitTimer > 0)
            {
                hitTimer -= Time.deltaTime;
            }
            else
            {
                animator.SetBool("hit", false);
                hitTimer = 1f;
            }
        }

        defineDirectionAndFlip();
        move();
    }

    private void defineDirectionAndFlip()
    {
        if (!facingRight && moveInput > 0)
        {
            flip();
        }
        else if (facingRight && moveInput < 0)
        {
            flip();
        }
    }
    private void jump()
    {
        rb.velocity = Vector2.up * jumpHeight;
    }

    private void move()
    {
        rb.velocity = new Vector2(moveInput * maxSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        var groundCast = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 1f, whatIsGround);

        Debug.Log(groundCast.collider);

        return groundCast.collider != null;

    }

    private void flip()
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
        bc = GetComponent<BoxCollider2D>();

    }
}
