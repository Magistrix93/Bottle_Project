using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using PlayMaker;

public class CartaCestino : Items
{

    private PlayMakerFSM myFsm;

    public Sprite cartaUI;
    public bool paper;
    public bool paperStep;
    private bool activated;
    public bool paperON;
    public GameObject button;
    public GameObject note1;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    public GameObject diario;

    private GameObject soundEffect;
    private AudioSource[] audios;

    // Use this for initialization
    void Start()
    {
        activated = true;
        myFsm = GetComponent<PlayMakerFSM>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        if (gameManagerScript.fasi != Fasi.A)
            enabled = false;

        soundEffect = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        audios = soundEffect.GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.faseA == FaseA.none)
        {
            paper = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (!paperStep)
                paperStep = diario.GetComponent<Diary>().diaryON;

            if (paperStep && paper && activated)
            {
                button.GetComponent<ButtonSearch>().rayObject = this.gameObject;
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

    public override void OnClicked()
    {
        note1.GetComponent<Image>().sprite = cartaUI;
        button.SetActive(false);
        note1.SetActive(true);
        audios[12].Play();
        paperON = true;
    }
}
