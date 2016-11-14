using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PhotoCounter : MonoBehaviour
{
    public int photoTook = 0;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    public GameObject note2;
    public Sprite photoUI;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        if (gameManagerScript.faseB != FaseB.none || !gameManagerScript.photos[0] && !gameManagerScript.photos[1] && !gameManagerScript.photos[2] && !gameManagerScript.photos[3])
        {
            note2.SetActive(false);
        }
        
        if(gameManagerScript.faseB == FaseB.none)
        {
            for (int i = 0; i < 4; i++)
            {
                if (gameManagerScript.photos[i])
                {
                    note2.GetComponent<Image>().sprite = photoUI;
                    photoTook++;
                    UpdateText();
                }
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateText()
    {       
        GetComponent<Text>().text = (photoTook + "/4");
    }
}
