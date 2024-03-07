using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    private Animator animator;
    private int contador;

    [SerializeField] private AnimationClip animacionfinal;

    private void Start()
    {
        animator = GetComponent<Animator>();
        contador = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CambiarEscena());
            contador++;
        }
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("TriggerImg");
        yield return new WaitForSeconds(animacionfinal.length);

        if (contador == 4)
        {
            SceneManager.LoadScene("EscenaJuego");
        }
    }
}
