using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BambolaPosto : Items
{
    public GameObject note2;
    public GameObject dollobj;
    private PlayMakerFSM myFsm;
    public bool slotDoll;
    public bool slotDollON;
    private bool activated = true;
    public GameObject button;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private ButtonSearch buttonScript;
    private GameObject soundeffect;
    private AudioSource[] audios;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        if (gameManagerScript.fasi != Fasi.A)
            enabled = false;
        buttonScript = button.GetComponent<ButtonSearch>();
        soundeffect = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        audios = soundeffect.GetComponents<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.faseA == FaseA.none)
        {
            slotDoll = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (slotDoll && activated && !dollobj.activeSelf)
            {
                button.GetComponent<ButtonSearch>().rayObject = this.gameObject;
                button.GetComponent<Image>().sprite = buttonScript.handIconUI;
                button.SetActive(true);
                activated = false;
            }

            else if (!slotDoll && !activated)
            {
                button.SetActive(false);
                activated = true;
            }
        }

    }

    public override void OnClicked()
    {
        slotDollON = true;
        note2.GetComponent<Image>().sprite = null;
        note2.SetActive(false);
        dollobj.SetActive(true);
        dollobj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1.2f, this.transform.position.z);
        button.SetActive(false);
        gameObject.SetActive(false);
        audios[10].Play();
    }
}
