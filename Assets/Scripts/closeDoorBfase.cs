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
    }

    // Update is called once per frame
    void Update()
    {
        if (quadroScript.stepQuadro && !activated && !fatherFSM.FsmVariables.GetFsmBool("DoorAnim").Value)
        {
            fatherFSM.SendEvent("Bool");
            activated = true;
        }
    }
}
