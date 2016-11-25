using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Doll : Items
{

    private PlayMakerFSM myFsm;

    public GameObject note2;
    public GameObject imgWardr;
    public bool doll;
    public bool dollTaken;
    public Sprite dollUI;
    private bool activated = true;
    public GameObject button;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private GameObject soundEffects;
    public AudioSource[] myAudio;



    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        soundEffects = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        myAudio = soundEffects.GetComponents<AudioSource>();

        if (gameManagerScript.fasi != Fasi.A)
            enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.faseA == FaseA.none && !dollTaken)
        {
            doll = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (doll && activated)
            {
                button.GetComponent<ButtonSearch>().rayObject = this.gameObject;
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

    public override void OnClicked()
    {
        dollTaken = true;
        note2.SetActive(true);
        note2.GetComponent<Image>().sprite = dollUI;
        myAudio[10].Play();
        imgWardr.SetActive(true);
        button.SetActive(false);
        doll = false;
        gameObject.SetActive(false);
    }

}
