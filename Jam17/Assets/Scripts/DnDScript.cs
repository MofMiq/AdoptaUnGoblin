using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class DnDScript : MonoBehaviour
{
    public int health = 500;
    public PartyHumorScript laught;
    public int tipo;

    public GoblinScript g1, g2, g3;
    public List<GameObject> arrowsImages;
    private SpriteRenderer spriteRenderer;

    public int[,] tablaHumor;
    // Start is called before the first frame update
    void Start()
    {

        tablaHumor = new int[3, 6]{
            {3,1,0,3,-2,-2},
            {0,-1,-3,2,1,2},
            {-3,1,1,-3,3,-2}};

        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void QuitaVida()
    {
        Debug.Log("Entro en QuitoVida" + health);
        health--;
        StartCoroutine(FeedbackDamaged());
    }
    private IEnumerator FeedbackDamaged()
    {
        yield return new WaitForSeconds(0.1f);
        TurnYellow();
        yield return new WaitForSeconds(0.2f);
        TurnWhite();
    }

    private void TurnWhite()
    {
        spriteRenderer.color = Color.white;
    }

    private void TurnYellow()
    {
        spriteRenderer.color = Color.yellow;
    }
    //Debug.Log("la vida de " + this.name + " es " + health);


    public void Attack(int turn)
    {
        if (turn == 1)
            g1.IsDamaged();
        if (turn == 2)
            g2.IsDamaged();
        if (turn == 3)
            g3.IsDamaged();
    }

    public void AfectaHumor(int columnaTipo1, int columnaTipo2)
    {
        int cantidad = tablaHumor[tipo, columnaTipo1];
        cantidad += tablaHumor[tipo, columnaTipo2];
        laught.funnyQuantity += cantidad;
        if (laught.funnyQuantity >= 6)
            laught.funnyQuantity = 5;
        else if (laught.funnyQuantity <= -6)
            laught.funnyQuantity = -5;
        Debug.Log("Humor de " + name + " es fila, " + ((tipo)) + " con una cantidad" + cantidad);
        foreach (var item in arrowsImages)
        {
            item.SetActive(false);
        }

        GameObject arrowSelected = null;

        if (cantidad <= -4)
        {
            arrowSelected = arrowsImages[2];
        }
        else if (cantidad == -3 || cantidad == -2)
        {
            arrowSelected = arrowsImages[1];
        }
        else if (cantidad == -1)
        {
            arrowSelected = arrowsImages[0];
        }

        if (cantidad >= 4)
        {
            arrowSelected = arrowsImages[5];
        }
        else if (cantidad == 3 || cantidad == 2)
        {
            arrowSelected = arrowsImages[4];
        }
        else if (cantidad == 1)
        {
            arrowSelected = arrowsImages[3];
        }

        if (arrowSelected != null)
        {
            arrowSelected.SetActive(true);
            StartCoroutine(ArrowFeedback(arrowSelected));
        }
    }

    private IEnumerator ArrowFeedback(GameObject arrowSelected)
    {
        yield return new WaitForSeconds(1f);
        arrowSelected.SetActive(false);
        yield return new WaitForSeconds(1f);
        arrowSelected.SetActive(true);
        yield return new WaitForSeconds(1f);
        arrowSelected.SetActive(false);
        yield return new WaitForSeconds(1f);
        arrowSelected.SetActive(true);
        yield return new WaitForSeconds(1f);
        arrowSelected.SetActive(false);
    }

}