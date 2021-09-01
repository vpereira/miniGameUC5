using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private Vector3 posInicio;
    private Vector3 posFim;
    private Vector3 proximaPosicao;

    private float _speed = 0.5f;

    [SerializeField]
    private Transform transformPosFim;

    private void Awake()
    {
        posInicio = transform.position;
        posFim = transformPosFim.position;
        proximaPosicao = posFim;

    }

    private void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.position, proximaPosicao, _speed * Time.deltaTime);

        // invert destination
        if(Vector3.Distance(transform.position, proximaPosicao) <= 0.1f)
            proximaPosicao = proximaPosicao != posInicio ? posInicio : posFim;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        collision.transform.parent = transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.parent = null;
    }
}
