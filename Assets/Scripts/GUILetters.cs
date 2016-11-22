using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GUILetters : MonoBehaviour
{
    private int i;
    private int j;
    private int k;
    private string[] lettere;
    public GameObject[] lettersSprite;
    [SerializeField]
    public Color fullColor;
    [SerializeField]
    public Color startColor;
    public bool[] clickable;
    private PlayMakerFSM[] lettersFSM;
    public int lettersDone = 0;

    // Use this for initialization
    void Start()
    {
        lettere = new string[6];
        clickable = new bool[6];
        lettersFSM = new PlayMakerFSM[6];

        for (j = 0; j < 6; j++)     //Setto un array di stringhe vuote che saranno riempite con le lettere cliccate
        {
            lettere[i] = "";
            lettersSprite[j].GetComponent<SpriteRenderer>().color = startColor;
            lettersFSM[j] = lettersSprite[j].GetComponent<PlayMakerFSM>();
        }

        StartCoroutine(StartFlash());

    }

    private IEnumerator StartFlash()    //Coroutine per accendere e spegnere le lettere
    {
        for (k = 0; k < 6; k++)
        {
            lettersFSM[k].SendEvent("Update Items");
            //lettersSprite[k].layer = 5;
            lettersSprite[k].GetComponent<SpriteRenderer>().color = fullColor;
            yield return new WaitForSeconds(UnityEngine.Random.Range(5, 10));
            lettersFSM[k].SendEvent("Update Default");
            //lettersSprite[k].layer = 0;
            lettersSprite[k].GetComponent<SpriteRenderer>().color = startColor;
        }

    }


    void Update()  // Update is called once per frame
    {
        if (k == 6)
            StartCoroutine(StartFlash());
    }

    public void UpdateText()       //Chiamato quando una di queste lettere è stata cliccata
    {
        for (i = 0; i < 6; i++)
        {
            if (GameManager.letters[i])
            {
                if (i == 0)
                    lettere[i] = "F";
                if (i == 1)
                    lettere[i] = "A";
                if (i == 2)
                    lettere[i] = "T";
                if (i == 3)
                    lettere[i] = "H";
                if (i == 4)
                    lettere[i] = "E";
                if (i == 5)
                    lettere[i] = "R";
            }


        }
        //Aggiorna il testo con la nuova lettera
        GetComponent<Text>().text = (lettere[0] + lettere[1] + lettere[2] + lettere[3] + lettere[4] + lettere[5]);
    }
}
