using UnityEngine;
using System.Collections;
using System;

public class ClockEvent : MonoBehaviour
{

    public int minutes = 0;
    public int hour = 0;

    public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    public GameObject button;
    public GameObject anta;
    public GameObject dollOBJ;
    public GameObject elsa;
    public GameObject player;
    public bool antaCheck;
    public AudioSource myAudio;
    public AudioClip myClip;
    public bool check = false;
    public int delay;
    public bool isInCoroutine;
    public bool scaryStep = false;
    public bool coroutineGo = true;



    void Start()
    {
        delay = 30;
    }

    void Update()
    {

        antaCheck = button.GetComponent<ButtonSearch>().checkSx;
        
        if (coroutineGo)
            StartCoroutine(waitDoor());

        if (check)
        {
            if (!isInCoroutine)
            {
                StartCoroutine(TenSeconds());
            }

        }

            
    }

    private IEnumerator waitDoor()
    {
        coroutineGo = false;
        yield return new WaitForSeconds(30);

        if (!check)
        {
            if (!antaCheck)
            {
                anta.GetComponent<Animation>().Play("antaSxRagazzaClose");
                button.GetComponent<ButtonSearch>().checkSx = true;
            }

            check = true;

            StartCoroutine(wait());
            myAudio.Play();

        }


    }

    public IEnumerator TenSeconds()
    {
        isInCoroutine = true;
        myAudio.Play();
        yield return new WaitForSeconds(UnityEngine.Random.Range(5, 10));
       
        isInCoroutine = false;
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        dollOBJ.SetActive(false);
        elsa.SetActive(true);
        elsa.transform.position = new Vector3(dollOBJ.transform.position.x, dollOBJ.transform.position.y + 0.5f, dollOBJ.transform.position.z + 0.45f);
        elsa.transform.rotation = Quaternion.Euler(0, -190, 0);
        scaryStep = true;
    }

   
}
