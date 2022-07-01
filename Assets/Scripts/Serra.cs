using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serra : MonoBehaviour
{
    private Vector3 posInicio;
    private Vector3 posFim;
    private Vector3 proximaPosicao;

    private Jogador jogador;

    private Animator animator;
    private float _speed = 0.2f;

    [SerializeField]
    private Transform transformPosFim;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        posInicio = transform.position;
        posFim = transformPosFim.position;
        proximaPosicao = posFim;
        jogador = GameObject.FindWithTag("Player").GetComponent<Jogador>();
    }

    private void Start()
    {
        animator.SetBool("on", true);
    }
    private void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.position, proximaPosicao, _speed * Time.deltaTime);

        // invert destination
        if (Vector3.Distance(transform.position, proximaPosicao) <= 0.1f)
            proximaPosicao = proximaPosicao != posInicio ? posInicio : posFim;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jogador.TiraVida(3);
        }
    }
}
