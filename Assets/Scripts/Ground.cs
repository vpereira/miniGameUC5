using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Jogador jogador;

    // Start is called before the first frame update
    private void Awake()
    {
        jogador = GameObject.FindWithTag("Player").GetComponent<Jogador>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
            jogador.SetGrounded(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            jogador.SetGrounded(false);
    }

}
