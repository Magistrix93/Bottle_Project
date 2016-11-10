using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSearch : MonoBehaviour
{
    //Manager
    public bool faseA1;
    public bool faseA2;
    public bool faseA3;
    public PlayMakerFSM fineTv;
    public GameObject elsa;
    public GameObject antaDx;
    public GameObject antaSx;
    public bool antaDxCheck;
    public bool antaSxCheck;
    public bool checkDx;
    public bool checkSx;
    public bool tvFine;
    public GameObject gameManager;
    public Sprite searchIconUI;
    public Sprite handIconUI;


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
    private bool myPaper;
    private bool myDiary;
    private bool myTime;
    public bool diaryON = false;
    public bool paperON = false;
    public bool timeON = false;

    //Fase A2
    public GameObject dollobj;
    public GameObject imgWardr;
    public Sprite imgWardrobeUI;
    public Sprite dollUI;
    public GameObject slotDollobj;
    public ClockEvent armadio;
    public AudioSource myAudio;
    public AudioClip tvScary;
    public bool myDoll;
    public bool myImgWardr;
    public bool myDollSlot;
    public bool dollON;
    public bool slotDollON;
    public bool knockCheck;
    public bool dollDone;




    // Use this for initialization
    void Start()
    {
        tvFine = fineTv.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmBool("Fine Televisore").Value;
        faseA1 = true;
        faseA2 = true;
        faseA3 = true;
        checkDx = true;
        checkSx = true;

    }

    // Update is called once per frame
    void Update()
    {
        antaDxCheck = antaDx.GetComponent<antaDx>().AntaDx;
        antaSxCheck = antaSx.GetComponent<AntaSx>().antaSx;

        myDiary = diario.GetComponent<Diary>().diaryRead;
        myPaper = carta.GetComponent<CartaCestino>().paper;
        myTime = orologio.GetComponent<Orologio>().time;

        myDoll = dollobj.GetComponent<Doll>().doll;
        myImgWardr = imgWardr.GetComponent<imgArmadio>().imgWardrobe;
        myDollSlot = slotDollobj.GetComponent<BambolaPosto>().slotDoll;
        knockCheck = armadio.GetComponent<ClockEvent>().check;

    }





    public void OnClick()
    {
        if (faseA1 && !tvFine)
        {
            if (myDiary)
            {
                text.SetActive(true);
                text.GetComponent<Text>().text = "A page is missing.";
                note1.GetComponent<Image>().sprite = diaryUI;
                this.gameObject.SetActive(false);
                note1.SetActive(true);
                diaryON = true;
            }

            if (myPaper)
            {
                note1.GetComponent<Image>().sprite = cartaUI;
                this.gameObject.SetActive(false);
                note1.SetActive(true);
                paperON = true;
            }

            if (myTime)
            {
                this.gameObject.SetActive(false);
                mainCam.SetActive(false);
                camTime.SetActive(true);
                controller1.GetComponent<Image>().enabled = false;
                controller2.GetComponent<Image>().enabled = false;
                buttonExit.SetActive(true);
                btnLeft.SetActive(true);
                btnRight.SetActive(true);
                timeON = true;
            }
        }

        if (faseA2 && !tvFine)
        {
            if (myDoll && !dollON)
            {
                note2.SetActive(true);
                note2.GetComponent<Image>().sprite = dollUI;
                dollobj.SetActive(false);
                imgWardr.SetActive(true);
                dollON = true;
                this.gameObject.SetActive(false);
            }

            if (myImgWardr)
            {
                note1.SetActive(true);
                note1.GetComponent<Image>().sprite = imgWardrobeUI;
                this.gameObject.SetActive(false);

            }

            if (myDollSlot && !slotDollON && dollON)
            {
                note2.GetComponent<Image>().sprite = null;
                note2.SetActive(false);
                dollobj.transform.position = new Vector3(slotDollobj.transform.position.x, slotDollobj.transform.position.y - 1.2f, slotDollobj.transform.position.z);
                dollobj.SetActive(true);
                slotDollON = true;
                this.gameObject.SetActive(false);
            }

            if (antaSxCheck && checkSx && !antaSx.GetComponent<Animation>().IsPlaying("antaSxRagazzaClose"))
            {
                antaSx.GetComponent<Animation>().Play("antaSxRagazza");
                checkSx = false;

                if (knockCheck)
                {
                    armadio.check = false;
                    elsa.GetComponent<Animator>().SetTrigger("IsScream");
                    myAudio.Play();
                    gameManager.GetComponent<GameManager>().avviaCoroutine();
                    armadio.enabled = false;
                    dollDone = true;

                }

            }

            if (antaSxCheck && !checkSx && !antaSx.GetComponent<Animation>().IsPlaying("antaSxRagazza"))
            {
                antaSx.GetComponent<Animation>().Play("antaSxRagazzaClose");
                checkSx = true;
            }

            if (antaDxCheck && checkSx && !antaSx.GetComponent<Animation>().IsPlaying("antaDxRagazzaClose"))
            {
                antaDx.GetComponent<Animation>().Play("antaDxRagazza");
                checkDx = false;
            }

            if (antaDxCheck && !checkSx && !antaSx.GetComponent<Animation>().IsPlaying("antaDxRagazza"))
            {
                antaDx.GetComponent<Animation>().Play("antaDxRagazzaClose");
                checkDx = true;
            }



        }

        
    }


}
