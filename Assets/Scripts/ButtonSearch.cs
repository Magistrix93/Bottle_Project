using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

public class ButtonSearch : MonoBehaviour
{
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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myDiary = diario.GetComponent<Diary>().diaryRead;
        myPaper = carta.GetComponent<CartaCestino>().paper;
        myTime = orologio.GetComponent<Orologio>().time;  
    }

    
    public void OnClick()
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
}
