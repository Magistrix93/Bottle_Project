using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class imgArmadio : Items
{
    public Sprite imgWardrobeUI;                            
    private PlayMakerFSM myFsm;
    public bool imgWardrobe;
    private bool activated = true;
    public GameObject button;
    public GameObject note1;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private GameObject soundeffect;
    private AudioSource[] audios;
 
    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        if (gameManagerScript.fasi != Fasi.A)
            this.enabled = false;
        soundeffect = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        audios = soundeffect.GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.faseA == FaseA.none)
        {
            imgWardrobe = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (imgWardrobe && activated)
            {
                button.GetComponent<ButtonSearch>().rayObject = this.gameObject;
                button.GetComponent<Image>().sprite = button.GetComponent<ButtonSearch>().searchIconUI;
                button.SetActive(true);
                activated = false;
            }

            else if (!imgWardrobe && !activated)
            {                
                activated = true;
                note1.SetActive(false);
                button.SetActive(false);
            }
        }

    }

    public override void OnClicked()
    {
        button.SetActive(false);
        note1.SetActive(true);
        note1.GetComponent<Image>().sprite = imgWardrobeUI;
        audios[12].Play();
    }
}
