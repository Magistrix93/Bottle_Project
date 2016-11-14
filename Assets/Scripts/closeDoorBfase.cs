using UnityEngine;
using System.Collections;

public class closeDoorBfase : MonoBehaviour
{
    private PlayMakerFSM myFsm;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private GameObject soundEffects;
    public AudioSource[] myAudio;


    private PlayMakerFSM fatherFSM;
    public GameObject quadro;
    private QuadroScript quadroScript;
    private Animation anim;
    private bool activated;
    private bool activated2;
    public bool door1;
    public GameObject trig2;
    private trigger trig2step;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        soundEffects = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        myAudio = soundEffects.GetComponents<AudioSource>();

        fatherFSM = gameObject.GetComponentInParent<PlayMakerFSM>();
        quadroScript = quadro.GetComponent<QuadroScript>();
        anim = GetComponent<Animation>();
        trig2step = trig2.GetComponent<trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (door1 && quadroScript.stepQuadro && !activated && !fatherFSM.FsmVariables.GetFsmBool("DoorAnim").Value)
        {
            fatherFSM.SendEvent("Bool");
            activated = true;
        }

        if (!door1 && trig2step.doorClose && !activated2 && !fatherFSM.FsmVariables.GetFsmBool("DoorAnim").Value)
        {
            fatherFSM.SendEvent("Bool");
            activated2 = true;
        }
    }
}
