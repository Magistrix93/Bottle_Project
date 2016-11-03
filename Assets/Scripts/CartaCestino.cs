using UnityEngine;
using System.Collections;
using PlayMaker;

public class CartaCestino : MonoBehaviour
{

    private PlayMakerFSM myFsm;
    public bool paper;
    public bool paperStep = false;
    private bool activated=true;
    public GameObject button;
    public GameObject note2;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        paper = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

        if (!paperStep)
        paperStep = button.GetComponent<ButtonSearch>().diaryON;        

        if (paperStep && paper && activated)
        {
            button.SetActive(true);
            activated = false;
        }
            
        else if (!paper && !activated)
        {
            button.SetActive(false);
            activated = true;
        }

        if (!paper)
            note2.SetActive(false);


    }
}
