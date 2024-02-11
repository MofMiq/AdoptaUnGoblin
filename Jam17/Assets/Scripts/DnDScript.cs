using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnDScript : MonoBehaviour
{
    public int health = 500;
    public PartyHumorScript laught;
    public int tipo;

    public GoblinScript g1,g2,g3;

    public int[,] tablaHumor;
    // Start is called before the first frame update
    void Start()
    {

        tablaHumor = new int [3,6]{
            {3,2,0,2,-1,-3},
            {1,1,-1,0,-2,3},
            {-3,-2,2,-1,4,1}};

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitaVida()
    {
        //Debug.Log("Entro en QuitoVida" + health);
        health--;
        //Debug.Log("la vida de " + this.name + " es " + health);
    }

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
        Debug.Log("Humor de " + name + " es fila, " + ((tipo)) + " con una cantidad"  + cantidad);
    }
}