using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class btnExit : MonoBehaviour
{
    public GameObject controllerCamera;
    public GameObject camTime;
    public GameObject controller1;
    public GameObject controller2;
    public GameObject btnLeft;
    public GameObject btnRight;
    public GameObject orologio;
    public GameObject audioSlam;
    private AudioSource[] audioSources;
    public AudioClip youDontKnow;
    public bool on = false;

    private GameObject gameManager;
    private GameManager gameManagerScript;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        if (gameManagerScript.fasi != Fasi.A)
            Destroy(gameObject);

        audioSlam = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        audioSources = audioSlam.GetComponents<AudioSource>();

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        controllerCamera = orologio.GetComponent<Orologio>().controllerCamera;
        controllerCamera.SetActive(true);
        camTime.SetActive(false);
        controller1.GetComponent<Image>().enabled = true;
        controller2.GetComponent<Image>().enabled = true;

        btnLeft.SetActive(false);
        btnRight.SetActive(false);



        if (orologio.GetComponent<Clock>().minutes == 30 && orologio.GetComponent<Clock>().hour == 12)
        {
            audioSources[7].Play();
            gameManager.GetComponent<PlayMakerFSM>().SendEvent("JumpScareClock");
            Destroy(gameObject);
        }

        gameObject.SetActive(false);
    }
}
