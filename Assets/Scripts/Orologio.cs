using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Orologio : Items
{

    private PlayMakerFSM myFsm;
    public GameObject controller1;
    public GameObject controller2;
    public bool time;
    public bool timeStep = false;
    private bool activated = true;
    public bool timeON;
    public GameObject button;
    public GameObject camTime;
    public GameObject mainCam;
    public GameObject controller;
    public GameObject buttonExit;
    public GameObject btnLeft;
    public GameObject btnRight;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    public GameObject carta;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        if (gameManagerScript.fasi != Fasi.A)
            enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.faseA == FaseA.none)
        {

            time = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (!timeStep)
                timeStep = carta.GetComponent<CartaCestino>().paperON;

            if (timeStep && time && activated)
            {
                button.GetComponent<ButtonSearch>().rayObject = this.gameObject;
                button.SetActive(true);
                activated = false;
            }

            else if (!time && !activated)
            {
                button.SetActive(false);
                activated = true;
            }
        }
    }

    public override void OnClicked()
    {
        timeON = true;
        button.SetActive(false);
        mainCam.SetActive(false);
        camTime.SetActive(true);
        controller1.GetComponent<Image>().enabled = false;
        controller2.GetComponent<Image>().enabled = false;
        buttonExit.SetActive(true);
        btnLeft.SetActive(true);
        btnRight.SetActive(true);
    }
}
