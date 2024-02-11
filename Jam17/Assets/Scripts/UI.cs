using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIBotonEleccion : MonoBehaviour {
    
    public GameObject panel1, panel2, panel3, panelTexto, displayText;
    
    // Start is called before the first frame update
    void Start() {
    }

    public void ActivaPanel1() {
        displayText.SetActive(false);
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }
    
    public void ActivaPanel2() {
        displayText.SetActive(false);
        panel1.SetActive(false);
        panel2.SetActive(true);
        panel3.SetActive(false);
    }
    
    public void ActivaPanel3() {
        displayText.SetActive(false);
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(true);
    }

    public void DesactivaPaneles() {
        displayText.SetActive(true);
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
