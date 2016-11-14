﻿using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class Diary : Items
{
   
    public GameObject text;
    private PlayMakerFSM myFsm;
    public Sprite diaryUI;
    public bool diaryRead;
    private bool activated = true;
    public bool diaryON;
    public GameObject button;
    public GameObject note1;
    private GameObject gameManager;
    private GameManager gameManagerScript;


    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        if (gameManagerScript.fasi != Fasi.A)
            this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.faseA == FaseA.none)
        {
            diaryRead = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

            if (diaryRead && activated)
            {
                button.GetComponent<ButtonSearch>().rayObject = this.gameObject;
                button.GetComponent<Image>().sprite = button.GetComponent<ButtonSearch>().searchIconUI;
                button.SetActive(true);
                activated = false;
            }

            else if (!diaryRead && !activated)
            {
                text.SetActive(false);
                text.GetComponent<Text>().text = "";
                button.SetActive(false);
                activated = true;
                note1.SetActive(false);
            }
        }

    }

    public override void OnClicked()
    {
        text.SetActive(true);
        text.GetComponent<Text>().text = "A page is missing.";
        note1.GetComponent<Image>().sprite = diaryUI;
        button.SetActive(false);
        note1.SetActive(true);
        diaryON = true;
    }
}
