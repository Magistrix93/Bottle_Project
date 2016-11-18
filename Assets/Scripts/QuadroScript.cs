using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class QuadroScript : Items
{
    private PlayMakerFSM myFsm;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private GameObject soundEffects;
    public AudioSource[] myAudio;

    public Material fotoCompleta;
    public GameObject note2;
    public GameObject text1;
    private PhotoCounter photo;
    public GameObject button;
    public GameObject trigElsa;
    public bool quadro;
    public bool stepQuadro;
    private bool activated;
    private GameObject phone;
    public GameObject finalDoor;
    public GameObject closeDoor;

    private int layerdefault;

    // Use this for initialization
    void Start()
    {
        layerdefault = LayerMask.GetMask("Default");
        myFsm = GetComponent<PlayMakerFSM>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        soundEffects = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        myAudio = soundEffects.GetComponents<AudioSource>();
        phone = GameObject.FindGameObjectWithTag("Phone");
        photo = text1.GetComponent<PhotoCounter>();

        if (gameManagerScript.fasi != Fasi.B)
            enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.faseB == FaseB.none)
        {
            quadro = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (quadro && activated)
            {
                button.GetComponent<ButtonSearch>().rayObject = gameObject;
                button.GetComponent<Image>().sprite = button.GetComponent<ButtonSearch>().handIconUI;
                button.SetActive(true);
                activated = false;
            }

            else if (!quadro && !activated)
            {
                button.SetActive(false);
                activated = true;
            }
        }
    }

    public override void OnClicked()
    {
        if(!stepQuadro && gameManagerScript.photos[0] && gameManagerScript.photos[1] && gameManagerScript.photos[2] && gameManagerScript.photos[3])
        {
            gameObject.GetComponent<Renderer>().material = fotoCompleta;
            stepQuadro = true;
            trigElsa.SetActive(true);
            note2.SetActive(false);
            text1.SetActive(false);
            myAudio[10].Play();
            gameObject.GetComponent<AudioSource>().Play();
            button.SetActive(false);
            StartCoroutine(DelayPhone());
            finalDoor.layer = layerdefault;
            gameManagerScript.faseB = FaseB.photos;
            closeDoor.GetComponent<PlayMakerFSM>().SendEvent("Bool");
        }
       
    }

    private IEnumerator DelayPhone()
    {
        yield return new WaitForSeconds(3);
        phone.GetComponent<PlayMakerFSM>().SendEvent("Phone Ring");

    }
}
