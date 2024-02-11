using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyHumorScript : MonoBehaviour
{
    public int funnyQuantity = 0;

    public GameObject[] caras = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update() {
        caras[0].SetActive(funnyQuantity < -3);
        caras[1].SetActive(funnyQuantity >= -3 && funnyQuantity <= -1);
        caras[2].SetActive(funnyQuantity==0);
        caras[3].SetActive(funnyQuantity >= 1 && funnyQuantity <= 3);
        caras[4].SetActive(funnyQuantity >= 4);
        if (funnyQuantity >= 6)
            funnyQuantity = 5;
        if (funnyQuantity <= -6)
            funnyQuantity = -5;
    }
}
