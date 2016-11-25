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

    [SerializeField]
    public Color startColor = new Color(255f, 0f, 0f, 255f);
    [SerializeField]
    public Color fullColor = new Color(255, 0, 255);

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();

        //soundEffects = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        //myAudio = soundEffects.GetComponents<AudioSource>();

        spriteLetter = gameObject.GetComponent<SpriteRenderer>().sprite;
        GUIWordScript = GUIWord.GetComponent<GUILetters>();
        startColor = new Color(1f, 0f, 0.04f, 1f);
        fullColor = Color.white;
        StartCoroutine(StartFlash());
    }

    // Update is called once per frame
    void Update()
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

    public override void OnClicked()
    {
        if (spriteLetter.name == "F")
        {
            GUIWordScript.letters[0] = true;
            GUIWordScript.UpdateText();
            GUIWordScript.lettersDone++;
            gameObject.SetActive(false);
            button.SetActive(false);

        }

        if (spriteLetter.name == "A")
        {
            GUIWordScript.letters[1] = true;
            GUIWordScript.UpdateText();
            GUIWordScript.lettersDone++;
            gameObject.SetActive(false);
            button.SetActive(false);
        }

        if (spriteLetter.name == "T")
        {
            GUIWordScript.letters[2] = true;
            GUIWordScript.UpdateText();
            GUIWordScript.lettersDone++;
            gameObject.SetActive(false);
            button.SetActive(false);
        }

        if (spriteLetter.name == "H")
        {
            GUIWordScript.letters[3] = true;
            GUIWordScript.UpdateText();
            GUIWordScript.lettersDone++;
            gameObject.SetActive(false);
            button.SetActive(false);
        }

        if (spriteLetter.name == "E")
        {
            GUIWordScript.letters[4] = true;
            GUIWordScript.UpdateText();
            GUIWordScript.lettersDone++;
            gameObject.SetActive(false);
            button.SetActive(false);
        }

        if (spriteLetter.name == "R")
        {
            GUIWordScript.letters[5] = true;
            GUIWordScript.UpdateText();
            GUIWordScript.lettersDone++;
            gameObject.SetActive(false);
            button.SetActive(false);
        }
    }

    private IEnumerator StartFlash()    //Coroutine per accendere e spegnere le lettere
    {
        gameObject.GetComponent<SpriteRenderer>().color = fullColor;
        yield return new WaitForSeconds(Random.Range(1f, 4f));        
        StartCoroutine(StopFlash());
    }


    private IEnumerator StopFlash()
    {
        gameObject.GetComponent<SpriteRenderer>().color = startColor;
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        StartCoroutine(StartFlash());
    }
}


