using UnityEngine;
using System.Collections;

public class Pausemenu : MonoBehaviour
{

    public GameObject canvasBase;
    public GameObject canvasMenu;
    public GameObject controller;
    private bool canvas;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (gameObject.tag == "buttonPause")
        {
            Time.timeScale = 0;
            canvasBase.SetActive(false);
            canvasMenu.SetActive(true);
            controller.SetActive(false);
        }

        if (gameObject.tag == "buttonPlay")
        {
            Time.timeScale = 1;
            canvasBase.SetActive(true);
            canvasMenu.SetActive(false);
            controller.SetActive(true);
        }

    }
}
