using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    private Rigidbody2D rb;

    private Jogador jogador;
    private float timeToLive = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jogador = GameObject.FindWithTag("Player").GetComponent<Jogador>();
    }

    private void Update()
    {
        if (timeToLive > 0)
            timeToLive -= Time.deltaTime;
        else
            Destroy(gameObject);
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        var direction = transform.InverseTransformPoint(jogador.transform.position);


        if (direction.x > 0.0f)
            rb.velocity = new Vector2(rb.velocity.x + 0.5f, rb.velocity.y);
        else
            rb.velocity = new Vector2(rb.velocity.x - 0.5f, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            jogador.TiraVida(1);

        Destroy(gameObject, 0.2f);
    }
}
