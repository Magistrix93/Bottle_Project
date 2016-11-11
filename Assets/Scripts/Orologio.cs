using UnityEngine;
using System.Collections;

public class Orologio : MonoBehaviour
{

    private PlayMakerFSM myFsm;
    public bool time;
    public bool timeStep = false;
    private bool activated = true;
    public GameObject button;
    public GameObject camTime;
    public GameObject mainCam;
    public GameObject controller;
    public GameObject buttonExit;
    public GameObject btnLeft;
    public GameObject btnRight;
    private GameObject gameManager;
    private GameManager gameManagerScript;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        if (gameManagerScript.fasi != Fasi.A)
            this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.faseA == FaseA.none)
        {

            time = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (!timeStep)
                timeStep = button.GetComponent<ButtonSearch>().paperON;

            if (timeStep && time && activated)
            {
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
}
