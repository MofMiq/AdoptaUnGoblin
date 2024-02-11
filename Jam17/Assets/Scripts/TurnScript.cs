using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        StartCoroutine(GameSequence());
    }

    // Update is called once per frame
    void Update()
    {
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

            Debug.Log("PULSA INTRO-----------");
            hoverImg = true;
            pB.SetActive(true);
            yield return new WaitUntil(() => isEnterPressed);
            isEnterPressed = false;
            hoverImg = false;
            //animatorRealPlayer.SetTrigger("Pedo");

            pB.SetActive(false);
            pM.SetActive(false);
            pME.SetActive(false);
            pV.SetActive(false);
            yield return StartCoroutine(DndSeq(turn));
            g.IsDead(turn);
            turn++;
            limite--;
            Debug.Log("ESTAMOS EN EL TURNO " + turn);
        }
        camara.mute = true;
        if (totalLaught >= 6)
        {
            audioManager.SeleccionAudio(11, 30);
            imgV.SetActive(true);
        }
        else
        {
            audioManager.SeleccionAudio(12, 30);
            imgD.SetActive(true);
        }
        this.enabled = false;
    }

    private IEnumerator GoblinSeq(int limite)
    {
        int i = 0;
        yield return new WaitForSeconds(5);
        while (i < limite)
        {
            g.Action();
            if (limite == 3 && i == 0)
            {
                animRoki.SetTrigger("RokiTrigger");
                audioManager.SeleccionAudio(8, 20);
                yield return new WaitForSeconds(2);
                audioManager.SeleccionAudio(9, 20);
                animRati.SetTrigger("RatiTRigger");
                audioManager.SeleccionAudio(10, 20);
                yield return new WaitForSeconds(2);
                animFruti.SetTrigger("FrutiTrigger");
            }
            if (limite == 2 && i == 0)
            {
                audioManager.SeleccionAudio(9, 20);
                animRati.SetTrigger("RatiTRigger");
                yield return new WaitForSeconds(1);
                audioManager.SeleccionAudio(10, 20);
                animFruti.SetTrigger("FrutiTrigger");
            }
            if (limite == 1 && i == 0)
            {
                animFruti.SetTrigger("FrutiTrigger");
                audioManager.SeleccionAudio(8, 20);
            }
            yield return new WaitForSeconds(2);
            i++;
        }
    }

    private IEnumerator DndSeq(int turn)
    {
        int i = 0;
        yield return new WaitForSeconds(5);
        while (i < 3)
        {
            d.Attack(turn);
            if (i == 0)
            {
                audioManager.SeleccionAudio(2, 20);
                animBarbara.SetTrigger("AnimTrigger");
            }
            if (i == 1)
            {
                audioManager.SeleccionAudio(3, 20);
                animBardo.SetTrigger("BardTrigger");
            }
            if (i == 2)
            {
                audioManager.SeleccionAudio(4, 20);
                animMago.SetTrigger("MagoTrigger");
            }
            yield return new WaitForSeconds(2);
            i++;
        }
    }
    
    public void CambiaAnimacion(int i)
    {
        if (i == 1)
        {
            audioManager.SeleccionAudio(0, 20);
            animPedo.SetTrigger("Pedo");
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
            audioManager.SeleccionAudio(1, 20);
            animMusi.SetTrigger("MusicaTRigger");
        }
        if (i == 6)
        {
            audioManager.SeleccionAudio(5, 20);
            animMusi.SetTrigger("MusicaTRigger");
        }
        if (i == 7)
        {
            audioManager.SeleccionAudio(6, 20);
            animMusi.SetTrigger("MusicaTRigger");
        }
        if (i == 8)
        {
            audioManager.SeleccionAudio(7, 20);
            animMusi.SetTrigger("MusicaTRigger");
        }
    }

    public void CambiaMeme(int i)
    {
        if (i == 1)
        {
            bap.enabled = true;
        }
        if (i == 2)
        {
            cartel.enabled = true;
        }
        if (i == 3)
        {
            cena.enabled = true;
        }
        if (i == 4)
        {
            patri.enabled = true;
        }
        isWaiting = true;
    }

    public void DisableMeme()
    {
        bap.enabled = false;
        cartel.enabled = false;
        cena.enabled = false;
        patri.enabled = false;
    }

}
