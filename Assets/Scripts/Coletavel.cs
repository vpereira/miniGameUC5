using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{

    public int pontosColetavel = 3;

    private Jogador jogador;

    private Animator animator;

    private void Awake()
    {
        jogador = GameObject.FindWithTag("Player").GetComponent<Jogador>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jogador.AddPontos(pontosColetavel);
            animator.SetBool("coletou", true);
            Destroy(gameObject, 1.5f);
        }
    }

}
