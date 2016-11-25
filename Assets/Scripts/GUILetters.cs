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

    public bool[] clickable;

    public int lettersDone = 0;

    public bool[] letters;
    public bool[] letterePrese;

    // Use this for initialization
    void Start()
    {
        lettere = new string[6];
        clickable = new bool[6];

        letters = new bool[6];
        letterePrese = new bool[6];

        for (j = 0; j < 6; j++)     //Setto un array di stringhe vuote che saranno riempite con le lettere cliccate
        {
            lettere[i] = "";
        }



    }



    void Update()  // Update is called once per frame
    {
        letterePrese = letters;
    }

    public void UpdateText()       //Chiamato quando una di queste lettere è stata cliccata
    {
        for (i = 0; i < 6; i++)
        {
            if (letters[i])
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
