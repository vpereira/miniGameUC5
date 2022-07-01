using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilhaAgua : MonoBehaviour
{
    private Jogador jogador;

    private bool collided = false;

    private void Awake()
    {
        jogador = GameObject.FindWithTag("Player").GetComponent<Jogador>();
    }

    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        // TODO do we need to check if we are touching a player?
        collided = true;

        while (collided)
        {
            yield return new WaitForSeconds(1);

            if (collided == true && collision.CompareTag("Player"))
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
