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

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();        
    }

    // Update is called once per frame
    void Update()
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
