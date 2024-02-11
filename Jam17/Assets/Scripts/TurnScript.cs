using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TurnScript : MonoBehaviour
{
    public int turn = 1;
    public int totalLaught;
    public GoblinScript g;
    public DnDScript d;

    public Animator animBarbara, animBardo, animMago, animRoki, animRati, animFruti, animPedo, animVom, animKulo, animAcha, animMusi;
    public SpriteRenderer bap, cartel, cena, patri;

    public bool isEnterPressed = false;
    public bool hoverImg = false;
    private float timer = 0;
    private bool isWaiting = false;
    public GameObject imgV, imgD, pB, pV, pM, pME;

    public AudioSource camara;

    public TMP_Text displayText;
    private AudioManager audioManager;

    public Slider SliderLaught;
    // Start is called before the first frame update
    void Start()
    {
        totalLaught = 0;
        audioManager = FindObjectOfType<AudioManager>();
        pB.SetActive(false);
        StartCoroutine(GameSequence());
    }

    // Update is called once per frame
    void Update()
    {
        SliderLaught.value = totalLaught;
        if (Input.GetKey("escape"))
            Application.Quit();
        if (isWaiting)
        {
            timer += Time.deltaTime;
            if (timer >= 4f)
            {
                DisableMeme();
                isWaiting = false;
                timer = 0;
            }
        }
    }

    private IEnumerator GameSequence()
    {
        int limite = 3;
        while (turn < 5)
        {
            yield return StartCoroutine(GoblinSeq(limite));

            pB.SetActive(true);
            ChangeText("Es mi momento de brillar");
            hoverImg = true;
            pB.SetActive(true);
            yield return new WaitUntil(() => isEnterPressed);
            isEnterPressed = false;
            hoverImg = false;

            pB.SetActive(false);
            pM.SetActive(false);
            pME.SetActive(false);
            pV.SetActive(false);
            yield return StartCoroutine(DndSeq(turn));
            g.IsDead(turn);
            turn++;
            limite--;
        }
        camara.mute = true;
        yield return new WaitForSeconds(2);
        if (totalLaught >= 6)
            imgV.SetActive(true);
        else
            imgD.SetActive(true);
        this.enabled = false;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator GoblinSeq(int limite)
    {
        int i = 0;
        if (turn == 2)
            ChangeText("Turno 2");
        else if (turn == 3)
            ChangeText("Turno 3");
        else if (turn == 4)
            ChangeText("Último turno");
        yield return new WaitForSeconds(3);
        while (i < limite)
        {
            g.Action();
            if (limite == 3 && i == 0)
            {
                animRoki.SetTrigger("RokiTrigger");
                ChangeText("Roki ataca con pedrolo");
                audioManager.SeleccionAudio(8, 7, 0);
                yield return new WaitForSeconds(2);
                animRati.SetTrigger("RatiTRigger");
                audioManager.SeleccionAudio(9, 7, 0);
                ChangeText("Rati ataca con su pincho ratuno");
                yield return new WaitForSeconds(2);
                animFruti.SetTrigger("FrutiTrigger");
                audioManager.SeleccionAudio(10, 7, 0);
                ChangeText("Fruti ataca con fuente de potasio");
            }
            if (limite == 2 && i == 0)
            {
                audioManager.SeleccionAudio(9, 7, 0);
                animRati.SetTrigger("RatiTRigger");
                ChangeText("Rati ataca dispuesto a pinchar");
                yield return new WaitForSeconds(2);
                audioManager.SeleccionAudio(10, 7, 0);
                animFruti.SetTrigger("FrutiTrigger");
                ChangeText("Fruti ataca por segunda vez");
            }
            if (limite == 1 && i == 0)
            {
                animFruti.SetTrigger("FrutiTrigger");
                ChangeText("Fruti sigue atacando con su plátano");
                audioManager.SeleccionAudio(8, 7, 0);
            }
            yield return new WaitForSeconds(1);
            i++;
        }
    }

    private IEnumerator DndSeq(int turn)
    {
        int i = 0;
        yield return new WaitForSeconds(4);
        ChangeText("Turno de los aventureros");
        yield return new WaitForSeconds(2);
        while (i < 3 && turn < 4)
        {
            d.Attack(turn);
            if (i == 0)
            {
                audioManager.SeleccionAudio(2, 1, 0);
                animBarbara.SetTrigger("AnimTrigger");
                RandomText(1);
            }
            if (i == 1)
            {
                audioManager.SeleccionAudio(3, 7, 0);
                animBardo.SetTrigger("BardTrigger");
                RandomText(2);
            }
            if (i == 2)
            {
                audioManager.SeleccionAudio(4, 1, 1);
                animMago.SetTrigger("MagoTrigger");
                RandomText(3);
            }
            yield return new WaitForSeconds(2);
            if (turn == 1)
                ChangeText("Roki ha muelto");
            else if (turn == 2)
                ChangeText("Han matado a Rati");
            else if (turn == 3)
                ChangeText("Fruti ha sido destruido");
            i++;
        }
    }
    
    public void CambiaAnimacion(int i)
    {
        if (i == 1)
        {
            animPedo.SetTrigger("Pedo");
            audioManager.SeleccionAudio(0, 3, 2);
        }
        if (i == 2)
        {
            animVom.SetTrigger("VomitoTrigger");
        }
        if (i == 3)
            animKulo.SetTrigger("KuloTrigger");
        if (i == 4)
            animAcha.SetTrigger("AchanteTrig");
        if (i == 5)
        {
            audioManager.SeleccionAudio(1, 7, 0);
            animMusi.SetTrigger("MusicaTRigger");
        }
        if (i == 6)
        {
            animMusi.SetTrigger("MusicaTRigger");
            audioManager.SeleccionAudio(5, 7, 0);
        }
        if (i == 7)
        {
            animMusi.SetTrigger("MusicaTRigger");
            audioManager.SeleccionAudio(6, 7, 0);
        }
        if (i == 8)
        {
            animMusi.SetTrigger("MusicaTRigger");
            audioManager.SeleccionAudio(7, 7, 0);
        }
    }

    public void CambiaMeme(int i)
    {
        if (i == 1)
            bap.enabled = true;
        if (i == 2)
            cartel.enabled = true;
        if (i == 3)
            cena.enabled = true;
        if (i == 4)
            patri.enabled = true;
        isWaiting = true;
    }

    public void DisableMeme()
    {
        bap.enabled = false;
        cartel.enabled = false;
        cena.enabled = false;
        patri.enabled = false;
    }

    public void ChangeText(string newText)
    {
        displayText.text = newText;
    }

    public void AttackText(int i)
    {
        if (i == 0)
            ChangeText("'Al siguiente truco lo llamaré Megapedo");
        if (i == 1)
            ChangeText("Party, he gomitao");
        if (i == 2)
            ChangeText("Es como si no llevara nada");
        if (i == 3)
            ChangeText(":)");
        if (i == 4)
            ChangeText("");
        if (i == 5)
            ChangeText("");
        if (i == 6)
            ChangeText("");
        if (i == 7)
            ChangeText("");
        if (i == 8)
            ChangeText("Kuanto me da por este tanbor?");
        if (i == 9)
            ChangeText("Gente, nos hemos quedao sin cena");
        if (i == 10)
            ChangeText("¿A quién no le va a gustar una mazmorra del siglo primero?");
        if (i == 11)
            ChangeText("Este cartel no me parará porque no se leer");
    }

    void RandomText(int i)
    {
        int nb = 0;

        if (i == 1)
            nb = Random.Range(1, 4);
        else if (i == 2)
            nb = Random.Range(4, 7);
        else if (i == 3)
            nb = Random.Range(7, 10);
        switch (nb)
        {
            case 1:
                ChangeText("La bárbara ataca con un HACHASO TO FUERTE");
                break ;
            case 2:
                ChangeText("La barbará realiza un empotramiento");
                break ;
            case 3:
                ChangeText("La bárbara da un SOPAPO PAL MULHACÉN");
                break ;
            case 4:
                ChangeText("Bardo ataca con VIOLINENCIA");
                break ;
            case 5:
                ChangeText("Bardo entona su RÉQUIEM POR LÁSTIMA");
                break ;
            case 6:
                ChangeText("Bardo realiza su PUÑALADA EN DO MENOR");
                break ;
            case 7:
                ChangeText("El mago realiza una TORSIÓN TESTICULAR");
                break ;
            case 8:
                ChangeText("El mago grita 'HOCUS POCUS PISOTÓN DE DIPLODOCUS'");
                break ;
            case 9:
                ChangeText("El mago conjura: 'ABRACADABRA, UN GOBLIN SE DESCALABRA");
                break ;
        }
    }

}
