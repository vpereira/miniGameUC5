using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{

    private int _pontosColetavel = 3;

    private Jogador jogador;

    private Animator animator;

    private void Awake()
    {
        jogador = GameObject.FindWithTag("Player").GetComponent<Jogador>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            jogador.AddPontos(_pontosColetavel);
            // TODO add animation
            animator.SetBool("coletou", true);
            Destroy(gameObject, 1.5f);
        }
    }

}
