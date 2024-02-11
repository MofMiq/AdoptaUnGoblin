using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class TurnScript : MonoBehaviour
{
    public int turn = 1;
    public int totalLaught = 0;
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
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        pB.SetActive(false);
        StartCoroutine(GameSequence());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        if (isWaiting)
        {
            timer += Time.deltaTime;
            if (timer >= 1.5f)
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
            ChangeText("Comienza el 4 y último turno");
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
                ChangeText("Fruti ataca con mucho potasio");
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
                ChangeText("Roki ha fenecido");
            else if (turn == 2)
                ChangeText("Rati ha fenecido");
            else if (turn == 3)
                ChangeText("Fruti ha fenecido");
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
            ChangeText("Ataque Megapedo");
        if (i == 1)
            ChangeText("Ataque Vomito");
        if (i == 2)
            ChangeText("Ataque Fashion");
        if (i == 3)
            ChangeText("Ataque Achante");
        if (i == 4)
            ChangeText("Ataque Rumbita");
        if (i == 5)
            ChangeText("Ataque Cansao");
        if (i == 6)
            ChangeText("Ataque Guay");
        if (i == 7)
            ChangeText("Ataque Pasión");
        if (i == 8)
            ChangeText("Ataque Patrisio");
        if (i == 9)
            ChangeText("Ataque Cena");
        if (i == 10)
            ChangeText("Ataque Siglo");
        if (i == 11)
            ChangeText("Ataque Analfabetismo");
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
        Debug.Log("nb: " + nb);
        switch (nb)
        {
            case 1:
                ChangeText("Barbara ataque 1111");
                break ;
            case 2:
                ChangeText("Barbara ataque 2222");
                break ;
            case 3:
                ChangeText("Barbara ataque 3333");
                break ;
            case 4:
                ChangeText("Bardo ataque 1111");
                break ;
            case 5:
                ChangeText("Bardo ataque 2222");
                break ;
            case 6:
                ChangeText("Bardo ataque 3333");
                break ;
            case 7:
                ChangeText("Mago ataque 1111");
                break ;
            case 8:
                ChangeText("Mago ataque 2222");
                break ;
            case 9:
                ChangeText("Mago ataque 3333");
                break ;
        }
    }

}
