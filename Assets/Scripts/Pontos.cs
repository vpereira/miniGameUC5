using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pontos : MonoBehaviour
{
    [SerializeField]
    private Jogador jogador;

    [SerializeField]
    private TextMeshProUGUI textScore;

    // Update is called once per frame
    void Update()
    {
        textScore.text = $"Pontos: {jogador.Pontos} ";
    }
}
