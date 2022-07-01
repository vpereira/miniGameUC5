using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilhaFogo : MonoBehaviour
{

    private Jogador jogador;

    private Animator animator;

    private bool collided = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        jogador = GameObject.FindWithTag("Player").GetComponent<Jogador>();
    }


    private void FixedUpdate()
    {
        InvokeRepeating("onFire", 2f, 5f);
        InvokeRepeating("offFire", 5f, 2f);
    }

    private void onFire()
    {
        animator.SetBool("on", true);
    }

    private void offFire()
    {
        animator.SetBool("on", false);
    }

    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        // TODO do we need to check if we are touching a player?
        collided = true;

        while (collided)
        {
            yield return new WaitForSeconds(0.5f);

            if (collided && animator.GetBool("on") && collision.CompareTag("Player"))
            {
                jogador.TiraVida(1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collided = false;
    }
}
