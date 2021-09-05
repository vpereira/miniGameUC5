using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPlanta : MonoBehaviour
{
    public GameObject projetil;

    bool inimigoOnRange = false;

    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            inimigoOnRange = true;

        while(inimigoOnRange)
        {
            yield return new WaitForSeconds(1);

            if (inimigoOnRange)
            {
                var startPosition = transform.position;
                Instantiate(projetil, startPosition, Quaternion.identity);
            }
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            inimigoOnRange = false;
    }
}
