using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontos : MonoBehaviour
{
    [SerializeField]
    private Jogador jogador;

    [SerializeField]
    private Text textScore;

    // Update is called once per frame
    void Update()
    {
        textScore.text = $"Score: {jogador.Pontos} ";
    }
}
