using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSearch : MonoBehaviour
{
    //Manager
    public bool faseA1;
    public bool faseA2;
    public bool faseA3;

    public GameObject antaDx;
    public GameObject antaSx;
    public bool antaDxCheck;
    public bool antaSxCheck;
    public bool checkDx;
    public bool checkSx;

    //Fase A1
    public GameObject note1;
    public GameObject note2;
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
    public GameObject note3;
    public GameObject slotDollobj;
    public ClockEvent armadio;
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
        if (faseA1)
        {
            if (myDiary && this.gameObject.activeSelf)
            {
                this.gameObject.SetActive(false);
                note1.SetActive(true);
                diaryON = true;
            }

            if (myPaper && this.gameObject.activeSelf)
            {
                this.gameObject.SetActive(false);
                note2.SetActive(true);
                paperON = true;
            }

            if (myTime && this.gameObject.activeSelf)
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

        if (faseA2)
        {
            if (myDoll && this.gameObject.activeSelf && !dollON)
            {
                dollobj.SetActive(false);
                dollON = true;
                this.gameObject.SetActive(false);
            }

            if (myImgWardr && this.gameObject.activeSelf)
            {
                this.gameObject.SetActive(false);
                note3.SetActive(true);                
            }

            if (myDollSlot && !slotDollON && dollON && this.gameObject.activeSelf)
            {
                dollobj.transform.position = new Vector3(slotDollobj.transform.position.x, slotDollobj.transform.position.y, slotDollobj.transform.position.z);
                dollobj.SetActive(true);
                slotDollON = true;
                this.gameObject.SetActive(false);
            }

            if (antaSxCheck && checkSx &&  !antaSx.GetComponent<Animation>().IsPlaying("antaSxRagazzaClose"))
            {
                antaSx.GetComponent<Animation>().Play("antaSxRagazza");
                checkSx = false;
                if (knockCheck)
                {
                    armadio.GetComponent<ClockEvent>().check = false;
                    armadio.enabled = false;
                    dollDone = true;
                }
                    
            }

            if (antaSxCheck && !checkSx && !antaSx.GetComponent<Animation>().IsPlaying("antaSxRagazza"))
            {
                antaSx.GetComponent<Animation>().Play("antaSxRagazzaClose");
                checkSx = true;
            }



        }

        if (faseA3)
        {

        }
    }

}
