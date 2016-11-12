using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BambolaPosto : MonoBehaviour
{

    private PlayMakerFSM myFsm;
    public bool slotDoll;
    private bool activated = true;
    public GameObject button;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private ButtonSearch buttonScript;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        if (gameManagerScript.fasi != Fasi.A)
            enabled = false;
        buttonScript = button.GetComponent<ButtonSearch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.faseA == FaseA.none)
        {
            slotDoll = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (slotDoll && activated && !buttonScript.dollobj.activeSelf)
            {
                button.GetComponent<Image>().sprite = buttonScript.handIconUI;
                button.SetActive(true);
                activated = false;
            }

            else if (!slotDoll && !activated)
            {
                button.SetActive(false);
                activated = true;
            }
        }

    }
}
