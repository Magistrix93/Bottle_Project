using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using PlayMaker;

public class CartaCestino : MonoBehaviour
{

    private PlayMakerFSM myFsm;
    public bool paper;
    public bool paperStep;
    private bool activated;
    public GameObject button;
    public GameObject note1;
    private GameObject gameManager;
    private GameManager gameManagerScript;

    // Use this for initialization
    void Start()
    {
        activated = true;
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
            paper = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (!paperStep)
                paperStep = button.GetComponent<ButtonSearch>().diaryON;

            if (paperStep && paper && activated)
            {
                button.GetComponent<Image>().sprite = button.GetComponent<ButtonSearch>().searchIconUI;
                button.SetActive(true);
                activated = false;
            }

            else if (!paper && !activated)
            {
                button.SetActive(false);
                activated = true;
                note1.SetActive(false);
            }
        }

    }
}
