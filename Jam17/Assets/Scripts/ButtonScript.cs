using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TIPO{
    RIDICULO, SONORO, FOLCLORICO, SEXY, LIRICO, ENTRANABLE
};

public class ButtonScript : MonoBehaviour
{
    public TurnScript t;
    public TIPO t1, t2;
    public DnDScript barbara;
    public DnDScript bardo;
    public DnDScript mago;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void mandarTipos() {
        barbara.AfectaHumor((int)t1, (int)t2);
        bardo.AfectaHumor((int)t1, (int)t2);
        mago.AfectaHumor((int)t1, (int)t2);
        t.totalLaught = barbara.laught.funnyQuantity + bardo.laught.funnyQuantity + mago.laught.funnyQuantity;
        Debug.Log("Total laught " + t.totalLaught);
        t.isEnterPressed = true;
    }

    public void LlamaAnim(int i)
    {
        t.CambiaAnimacion(i);
    }

    public void LlamaMeme(int i)
    {
        t.CambiaMeme(i);
    }
}