using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FimDoJogo : MonoBehaviour
{
    [SerializeField]
    private Text finalMessage;

    [SerializeField]
    private GameObject background;

    void Start()
    {
        background.SetActive(false);
    }


    IEnumerator restartScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (background.activeSelf)
        {
            if (Input.anyKey)
            {
                StartCoroutine(restartScene());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            background.SetActive(true);
        }
    }
}
