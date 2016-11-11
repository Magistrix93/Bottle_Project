using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Diary : MonoBehaviour
{


    private PlayMakerFSM myFsm;
    public bool diaryRead;
    private bool activated = true;
    public GameObject button;
    public GameObject note1;
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
            diaryRead = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (diaryRead && activated)
            {
                button.GetComponent<Image>().sprite = button.GetComponent<ButtonSearch>().searchIconUI;
                button.SetActive(true);
                activated = false;
            }

            else if (!diaryRead && !activated)
            {
                button.GetComponent<ButtonSearch>().text.SetActive(false);
                button.GetComponent<ButtonSearch>().text.GetComponent<Text>().text = "";
                button.SetActive(false);
                activated = true;
                note1.SetActive(false);
            }
        }

    }
}
