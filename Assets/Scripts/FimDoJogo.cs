using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FimDoJogo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI finalMessage;

    void Start()
    {
        finalMessage.enabled = false;        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            finalMessage.enabled = true;
        }
    }
}
