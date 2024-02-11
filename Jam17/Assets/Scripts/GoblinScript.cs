using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    public int health = 9;
    public DnDScript otherScript;
    public int movimiento;

    public GameObject gob1, gob2, gob3;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action()
    {
        otherScript.QuitaVida();
    }

    public void Movimiento() {
        transform.position -= Vector3.left * movimiento;
    }

    public void IsDead(int turn)
    {
        if (turn == 1 && health <= 0)
            gob1.SetActive(false);
        else if (turn == 2 && health <= 0)
            gob2.SetActive(false);
        else if (turn == 3 && health <= 0)
            gob3.SetActive(false);
        return ;
    }

    public void IsDamaged()
    {
        health -= 3;
        //sDebug.Log("la vida de " + this.name + " es " + health);
    }
}
