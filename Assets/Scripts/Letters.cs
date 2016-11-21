using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Letters : Items
{
    private PlayMakerFSM myFsm;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private GameObject soundEffects;
    public AudioSource[] myAudio;

    public GameObject button;
    public bool letter;
    private bool activated;
    public Sprite spriteLetter;
    public GameObject GUIWord;
    private GUILetters GUIWordScript;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        soundEffects = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        //myAudio = soundEffects.GetComponents<AudioSource>();

        spriteLetter = gameObject.GetComponent<SpriteRenderer>().sprite;
        GUIWordScript = GUIWord.GetComponent<GUILetters>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.faseC == FaseC.none)
        {
            letter = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (letter && activated)
            {
                button.GetComponent<ButtonSearch>().rayObject = this.gameObject;
                button.GetComponent<Image>().sprite = button.GetComponent<ButtonSearch>().searchIconUI;
                button.SetActive(true);
                activated = false;
            }

            else if (!letter && !activated)
            {
                button.SetActive(false);
                activated = true;
            }
        }
    }

    public override void OnClicked()
    {
        if (spriteLetter.name == "F")
        {
            GameManager.letters[0] = true;
            GUIWordScript.UpdateText();
            button.SetActive(false);

        }    

        if (spriteLetter.name == "A")
        {
            GameManager.letters[1] = true;
            GUIWordScript.UpdateText();
            button.SetActive(false);
        }

        if (spriteLetter.name == "T")
        {
            GameManager.letters[2] = true;
            GUIWordScript.UpdateText();
            button.SetActive(false);
        }

        if (spriteLetter.name == "H")
        {
            GameManager.letters[3] = true;
            GUIWordScript.UpdateText();
            button.SetActive(false);
        }

        if (spriteLetter.name == "E")
        {
            GameManager.letters[4] = true;
            GUIWordScript.UpdateText();
            button.SetActive(false);
        }

        if (spriteLetter.name == "R")
        {
            GameManager.letters[5] = true;
            GUIWordScript.UpdateText();
            button.SetActive(false);
        }
    }
}
