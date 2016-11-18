using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class PhotoLavagna : MonoBehaviour
{

    public bool activeEvent;
    public GameObject trigger;
    private PlayMakerFSM triggerFSM;
    [SerializeField]
    private GameObject FPSController;

    private GameObject gameManager;
    private GameManager gameManagerScript;

    public GameObject lavagna;

    // Use this for initialization
    void Start()
    {
        if (trigger != null)
            triggerFSM = trigger.GetComponent<PlayMakerFSM>();

        FPSController = GameObject.FindGameObjectWithTag("Player");

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        if (gameManagerScript.fasi != Fasi.B)
            Destroy(gameObject);
        else 
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.enigmaLavagna != FasiEnigmaLavagna.inquadraLavagna && gameManagerScript.faseB != FaseB.none)
            gameObject.SetActive(false);
    }

    public void OnClick()
    {
        FPSController.GetComponent<FirstPersonController>().enabled = true;
        if (activeEvent)
        {
            triggerFSM.SendEvent("Bool");
            Destroy(gameObject);
        }
        else if (lavagna != null)
            lavagna.GetComponent<Renderer>().enabled = false;
        

        gameObject.SetActive(false);

    }
}
