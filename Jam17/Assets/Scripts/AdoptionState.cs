using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdoptionState : MonoBehaviour
{
    public TurnScript t;

    public SpriteRenderer odio, apa, indi, curi, simpa, adop;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        odio.enabled = t.totalLaught <= -3;
        apa.enabled = t.totalLaught == -1 || t.totalLaught == -2;
        indi.enabled = t.totalLaught == 0;
        curi.enabled = t.totalLaught == 1 || t.totalLaught <= 2;
        simpa.enabled = t.totalLaught == 3 || t.totalLaught == 4;
        adop.enabled = t.totalLaught >= 5;
    }
}
