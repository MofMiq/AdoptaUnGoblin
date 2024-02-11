using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIBotonEleccion : MonoBehaviour {
    
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panelTexto;
    
    // Start is called before the first frame update
    void Start() {
    }

    public void ActivaPanel1() {
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }
    
    public void ActivaPanel2() {
        panel1.SetActive(false);
        panel2.SetActive(true);
        panel3.SetActive(false);
    }
    
    public void ActivaPanel3() {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(true);
    }

    public void DesactivaPaneles() {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }

    public void SwitchPanelTexto() {
        // panelTexto.SetActive(panelTexto.);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
