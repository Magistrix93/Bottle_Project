using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Doll : MonoBehaviour
{

    private PlayMakerFSM myFsm;
    public bool doll;
    private bool activated = true;
    public GameObject button;
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
            doll = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (doll && activated)
            {
                button.GetComponent<Image>().sprite = button.GetComponent<ButtonSearch>().handIconUI;
                button.SetActive(true);
                activated = false;
            }

            else if (!doll && !activated)
            {
                button.SetActive(false);
                activated = true;
            }
        }

    }
}
