using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AntaSx : Items
{
    public GameObject dollOBJ;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private GameObject elsa;
    private GameObject phone;
    private PlayMakerFSM myFsm;
    private GameObject soundEffects;
    private GameObject ambient;
    private GameObject newAmbient;
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
        ambient = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Ambient").Value;
        newAmbient = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Ambient 2").Value;
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
        if (gameManagerScript.faseA == FaseA.none)
        {
            antaSx = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (antaSx && activated)
            {
                button.GetComponent<ButtonSearch>().rayObject = gameObject;
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



    }

    public override void OnClicked()
    {
        if (gameManagerScript.faseA == FaseA.none)
            if (checkSx && !antaSxAnim.IsPlaying("antaSxRagazzaClose"))
            {
                sounds[0].Play();
                antaSxAnim.Play("antaSxRagazza");
                checkSx = false;


                if (armadio.check && armadio.scaryStep)
                {
                    elsa.SetActive(true);
                    elsa.transform.position = new Vector3(dollOBJ.transform.position.x, 0, dollOBJ.transform.position.z + 0.45f);
                    elsa.transform.rotation = Quaternion.Euler(0, -190, 0);
                    armadio.check = false;
                    elsa.GetComponent<Animator>().SetTrigger("IsScream");
                    myAudio[6].Play();
                    gameManagerScript.avviaCoroutine(1f, elsa);
                    armadio.enabled = false;
                    phone.GetComponent<PlayMakerFSM>().SendEvent("Phone Ring");
                    gameManagerScript.faseA = FaseA.teddy;
                    ambient.SetActive(false);
                    newAmbient.SetActive(true);
                    button.SetActive(false);
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
