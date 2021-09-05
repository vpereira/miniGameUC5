using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    private Rigidbody2D rb;

    private Jogador jogador;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jogador = GameObject.FindWithTag("Player").GetComponent<Jogador>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.right * 5f;  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) {
            jogador.TiraVida(1);
            Destroy(gameObject);
        }
    }
}
