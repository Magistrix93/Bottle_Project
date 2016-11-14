using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AntaSx : Items
{

    private GameObject gameManager;
    private GameManager gameManagerScript;
    private GameObject elsa;
    private GameObject phone;
    private PlayMakerFSM myFsm;
    private GameObject soundEffects;
    private AudioSource[] myAudio;
    public bool antaSx;
    public bool activated = true;
    public GameObject button;
    public AudioSource[] sounds;
    public Animation antaSxAnim;
    public bool checkSx = true;
    public ClockEvent armadio;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        soundEffects = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        myAudio = soundEffects.GetComponents<AudioSource>();
        elsa = gameManagerScript.elsa;
        phone = gameManagerScript.phone;
        antaSxAnim = GetComponent<Animation>();
        myFsm = GetComponent<PlayMakerFSM>();
        sounds = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        antaSx = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

        if (antaSx && activated)
        {
            button.GetComponent<ButtonSearch>().rayObject = this.gameObject;
            button.GetComponent<Image>().sprite = button.GetComponent<ButtonSearch>().searchIconUI;
            button.SetActive(true);
            activated = false;
        }

        else if (!antaSx && !activated)
        {
            button.SetActive(false);
            activated = true;
        }
    }

    public override void OnClicked()
    {

        if (checkSx && !antaSxAnim.IsPlaying("antaSxRagazzaClose"))
        {
            sounds[0].Play();
            antaSxAnim.Play("antaSxRagazza");
            checkSx = false;

            if (armadio.check)
            {
                armadio.check = false;
                elsa.GetComponent<Animator>().SetTrigger("IsScream");
                myAudio[6].Play();
                gameManagerScript.avviaCoroutine(1f, elsa);
                armadio.enabled = false;
                phone.GetComponent<PlayMakerFSM>().SendEvent("Phone Ring");
                gameManagerScript.faseA = FaseA.teddy;
            }
        }
        else if (!checkSx && !antaSxAnim.IsPlaying("antaSxRagazza"))
        {
            antaSxAnim.Play("antaSxRagazzaClose");
            sounds[1].Play();
            checkSx = true;
        }
    }
}
