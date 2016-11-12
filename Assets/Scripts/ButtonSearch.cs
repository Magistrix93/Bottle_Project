using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class ButtonSearch : MonoBehaviour
{
    //Manager
    public PlayMakerFSM fineTv;
    public GameObject elsa;
    public GameObject antaDxObj;
    public GameObject antaSxOgj;
    private Animation antaDxAnim;
    private Animation antaSxAnim;
    private antaDx antaDx;
    private AntaSx antaSx;
    [NonSerialized]
    public bool checkDx;
    [NonSerialized]
    public bool checkSx;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    public Sprite searchIconUI;
    public Sprite handIconUI;
    private GameObject phone;
    


    //Fase A1
    public GameObject text;
    public GameObject note1;
    public GameObject note2;
    public Sprite diaryUI;
    public Sprite cartaUI;
    public GameObject diario;
    public GameObject carta;
    public GameObject orologio;
    public GameObject camTime;
    public GameObject mainCam;
    public GameObject controller1;
    public GameObject controller2;
    public GameObject buttonExit;
    public GameObject btnLeft;
    public GameObject btnRight;
    private CartaCestino myPaper;
    private Diary myDiary;
    private Orologio myTime;

    [NonSerialized]
    public bool diaryON = false;

    public bool paperON = false;
    [NonSerialized]
    public bool timeON = false;

    //Fase A2
    public GameObject dollobj;
    public GameObject imgWardr;
    public Sprite imgWardrobeUI;
    public Sprite dollUI;
    public GameObject slotDollobj;
    public ClockEvent armadio;
    private GameObject soundEffects;
    private AudioSource[] myAudio;
    private Doll myDoll;
    private imgArmadio myImgWardr;
    public BambolaPosto slotDoll;
    [NonSerialized]
    public bool slotDollON;
    private bool knockCheck;




    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        phone = GameObject.FindGameObjectWithTag("Phone");

        if (gameManagerScript.fasi != Fasi.A)
            enabled = false;

        checkDx = true;
        checkSx = true;
        
        antaDxAnim = antaDxObj.GetComponent<Animation>();
        antaSxAnim = antaSxOgj.GetComponent<Animation>();        

        antaDx = antaDxObj.GetComponent<antaDx>();
        antaSx = antaSxOgj.GetComponent<AntaSx>();

        myDiary = diario.GetComponent<Diary>();
        myPaper = carta.GetComponent<CartaCestino>();
        myTime = orologio.GetComponent<Orologio>();

        myDoll = dollobj.GetComponent<Doll>();
        myImgWardr = imgWardr.GetComponent<imgArmadio>();
        slotDoll = slotDollobj.GetComponent<BambolaPosto>();

        soundEffects = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        myAudio = soundEffects.GetComponents<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (gameManagerScript.faseA == FaseA.none)
        {
            if (myDiary.diaryRead)
            {
                text.SetActive(true);
                text.GetComponent<Text>().text = "A page is missing.";
                note1.GetComponent<Image>().sprite = diaryUI;
                gameObject.SetActive(false);
                note1.SetActive(true);
                diaryON = true;
            }

            if (myPaper.paper)
            {
                note1.GetComponent<Image>().sprite = cartaUI;
                gameObject.SetActive(false);
                note1.SetActive(true);
                paperON = true;
            }

            if (myTime.time)
            {
                gameObject.SetActive(false);
                mainCam.SetActive(false);
                camTime.SetActive(true);
                controller1.GetComponent<Image>().enabled = false;
                controller2.GetComponent<Image>().enabled = false;
                buttonExit.SetActive(true);
                btnLeft.SetActive(true);
                btnRight.SetActive(true);
                timeON = true;
            }

            if (myDoll.doll)
            {
                note2.SetActive(true);
                note2.GetComponent<Image>().sprite = dollUI;
                myAudio[10].Play();
                myDoll.doll = false;
                dollobj.SetActive(false);
                imgWardr.SetActive(true);
                gameObject.SetActive(false);
            }

            if (myImgWardr.imgWardrobe)
            {
                note1.SetActive(true);
                note1.GetComponent<Image>().sprite = imgWardrobeUI;
                gameObject.SetActive(false);

            }

            if (slotDoll.slotDoll && !slotDollON && !dollobj.activeSelf)
            {
                note2.GetComponent<Image>().sprite = null;
                note2.SetActive(false);
                dollobj.transform.position = new Vector3(slotDollobj.transform.position.x, slotDollobj.transform.position.y - 1.2f, slotDollobj.transform.position.z);
                dollobj.SetActive(true);
                slotDollON = true;
                gameObject.SetActive(false);
            }

            if (antaSx.antaSx && checkSx && !antaSxAnim.IsPlaying("antaSxRagazzaClose"))
            {
                antaSx.sounds[0].Play();
                antaSxAnim.Play("antaSxRagazza");
                checkSx = false;

                if (armadio.check)
                {
                    armadio.check = false;
                    elsa.GetComponent<Animator>().SetTrigger("IsScream");
                    myAudio[6].Play();
                    gameManagerScript.avviaCoroutine(1f, elsa);
                    armadio.enabled = false;
                    phone.GetComponent<PlayMakerFSM>().SendEvent("Phone Ring");
                    gameManagerScript.faseA = FaseA.teddy;


                }
            }

            if (antaSx.antaSx && !checkSx && !antaSxAnim.IsPlaying("antaSxRagazza"))
            {
                antaSxAnim.Play("antaSxRagazzaClose");
                antaSx.sounds[1].Play();
                checkSx = true;
            }

            if (antaDx.AntaDx && checkDx && !antaDxAnim.IsPlaying("Mobile 4 Close"))
            {
                antaDxAnim.Play("Mobile 4 Open");
                antaDx.sounds[0].Play();
                checkDx = false;
            }

            if (antaDx.AntaDx && !checkDx && !antaDxAnim.IsPlaying("Mobile 4 Open"))
            {
                antaDxAnim.Play("Mobile 4 Close");
                antaDx.sounds[1].Play();
                checkDx = true;
            }
        }


        
    }


}
