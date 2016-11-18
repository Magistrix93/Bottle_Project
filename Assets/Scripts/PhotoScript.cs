using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PhotoScript : Items
{

    private PlayMakerFSM myFsm;
    private GameObject gameManager;
    private GameManager gameManagerScript;

    public int photoN;
    public bool photo;
    private bool activated;
    public GameObject button;

    public GameObject note2;
    private GameObject soundEffects;
    public AudioSource[] myAudio;
    public Sprite photoUI;
    public GameObject text1;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        soundEffects = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        myAudio = soundEffects.GetComponents<AudioSource>();

        if (gameManagerScript.fasi != Fasi.B)
            Destroy(gameObject);

        if (gameManagerScript.photos[photoN])
            Destroy(gameObject);       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.faseB == FaseB.none)
        {
            photo = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;           

            if (photo && activated)
            {
                button.GetComponent<ButtonSearch>().rayObject = this.gameObject;
                button.GetComponent<Image>().sprite = button.GetComponent<ButtonSearch>().handIconUI;
                button.SetActive(true);
                activated = false;
            }

            else if (!photo && !activated)
            {
                button.SetActive(false);
                activated = true;
            }           
        }
    }

    public override void OnClicked()
    {
        gameManagerScript.photos[photoN] = true;
        text1.GetComponent<PhotoCounter>().photoTook++;
        note2.SetActive(true);
        note2.GetComponent<Image>().sprite = photoUI;
        text1.SetActive(true);
        text1.GetComponent<PhotoCounter>().UpdateText();
        myAudio[10].Play();
        gameObject.SetActive(false);
        button.SetActive(false);
        photo = false;
    }
}
