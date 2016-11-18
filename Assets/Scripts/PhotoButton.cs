using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class PhotoButton : MonoBehaviour
{
    public GameObject photoLavagna;
    private GameObject FPSController;
    private GameObject gameManager;
    private GameManager gameManagerScript;

    public GameObject lavagna;

    // Use this for initialization
    void Start()
    {
        FPSController = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        if (gameManagerScript.fasi != Fasi.B)
            Destroy(gameObject);
        else if (gameManagerScript.enigmaLavagna != FasiEnigmaLavagna.inquadraLavagna)
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (gameManagerScript.faseB != FaseB.none)
            gameObject.SetActive(false);
    }

    public void OnClick()
    {
        photoLavagna.SetActive(true);
        if (lavagna != null)
            lavagna.GetComponent<Renderer>().enabled = true;
        FPSController.GetComponent<FirstPersonController>().enabled = false;
    }
}
