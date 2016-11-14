using UnityEngine;
using System;
using System.Collections;

public class ButtonSearch : MonoBehaviour
{
    //Manager
    public Sprite searchIconUI;
    public Sprite handIconUI;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private GameObject soundEffects;
    private AudioSource[] myAudio;
    public GameObject rayObject;


    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        soundEffects = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        myAudio = soundEffects.GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        rayObject.GetComponent<Items>().OnClicked();
    }
}
