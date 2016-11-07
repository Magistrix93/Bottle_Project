using UnityEngine;
using System.Collections;

public class ClockEvent : MonoBehaviour
{

    public int minutes = 0;
    public int hour = 0;

    public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    public int seconds;
    public float msecs;


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
    public bool scaryStep=false;


    void Start()
    {        

        msecs = 0.0f;
        seconds = 0;
        delay = 5;
    }

    void Update()
    {

        antaCheck = button.GetComponent<ButtonSearch>().checkSx;


        //-- calculate time
        msecs += Time.deltaTime * clockSpeed;
        if (msecs >= 1.0f)
        {
            msecs -= 1.0f;
            seconds++;
            if (seconds >= 60)
            {
                seconds = 0;
                minutes++;
                if (minutes > 60)
                {
                    minutes = 0;
                    hour++;
                    if (hour >= 24)
                        hour = 0;
                }
            }
        }

        

        if (seconds >= delay && !check)
        {
            if (!antaCheck)
            {
                anta.GetComponent<Animation>().Play("antaSxRagazzaClose");
                button.GetComponent<ButtonSearch>().checkSx = true;
            }

            check = true;
            StartCoroutine("wait");            
            myAudio.Play();          
               
        }

        if (check)
        {
            if(!isInCoroutine)
            {
                StartCoroutine("TenSeconds");
                isInCoroutine = true;
                myAudio.Play();
            }
            
        }


    }

    public IEnumerator TenSeconds()
    {        
        yield return new WaitForSeconds(Random.Range(5, 10));
        isInCoroutine = false;
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        dollOBJ.SetActive(false);
        elsa.transform.position = new Vector3(dollOBJ.transform.position.x, dollOBJ.transform.position.y - 0.5f, dollOBJ.transform.position.z + 0.45f);
        elsa.transform.rotation = Quaternion.Euler(0, -190, 0);
        elsa.SetActive(true);
        scaryStep = true;
    }
}
