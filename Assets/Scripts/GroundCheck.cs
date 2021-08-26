using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Jogador jogador;

    // Start is called before the first frame update
    private void Awake()
    {
        jogador = GameObject.FindWithTag("Player").GetComponent<Jogador>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jogador.SetGrounded(true);
        jogador.SetJumping(false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       jogador.SetGrounded(false);
       jogador.SetJumping(true);
    }
}
