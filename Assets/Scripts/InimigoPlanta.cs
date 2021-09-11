using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPlanta : MonoBehaviour
{
    public GameObject projetil;

    bool inimigoOnRange = false;

    [SerializeField]
    private float fireballTime = 1f;

    private float fireballTimer = 1f;


    private Animator animator;

    private void Awake()
    {
        fireballTimer = fireballTime;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private IEnumerator WaitAndShoot()
    {
        yield return new WaitForSeconds(0.5f);
        var startPosition = transform.Find("FacingTo").position;
        Instantiate(projetil, startPosition, Quaternion.identity);
        animator.SetBool("onSight", false);
    }
    private void Update()
    {
        if(inimigoOnRange)
        {
            fireballTimer -= Time.deltaTime;

            if(fireballTimer <= 0f)
            {
                animator.SetBool("onSight", true);
                StartCoroutine(WaitAndShoot());
                fireballTimer = fireballTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            inimigoOnRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            inimigoOnRange = false;
    }
}
