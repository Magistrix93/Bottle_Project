using UnityEngine;
using System.Collections;
using System;

public class trigger : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private GameObject soundEffects;
    public AudioSource[] myAudio;

    private GameObject elsa;
    public GameObject elsaTarget1;
    private GameObject player;
    public GameObject elsaTarget;
    private Vector3 elsaPos;
    private float distance;
    public bool triggered;
    public bool doorClose;
    private bool trigDone;
    private bool startMove;
    private bool startMove2;
    private bool startMove3;
    private bool startMove4;
    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        soundEffects = gameManager.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("Sound effects").Value;
        myAudio = soundEffects.GetComponents<AudioSource>();
        elsa = gameManagerScript.elsa;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(elsa.transform.position, player.transform.position);

        if (startMove)
        {
            elsa.GetComponent<Animator>().SetBool("IsWalk", true);
            elsa.transform.position = Vector3.MoveTowards(elsa.transform.position, elsaTarget.transform.position, 4f * Time.deltaTime);

            if (elsa.transform.position == elsaTarget.transform.position)
            {
                elsa.GetComponent<Animator>().SetBool("IsWalk", false);
                elsa.transform.rotation = Quaternion.Slerp(elsa.transform.rotation, Quaternion.LookRotation(player.transform.position - elsa.transform.position), (2f * Time.deltaTime));
                elsa.transform.eulerAngles = new Vector3(0, elsa.transform.eulerAngles.y, 0);
            }
        }


        if (startMove2)
        {
            startMove = false;
            elsa.transform.position = Vector3.MoveTowards(elsa.transform.position, elsaPos, 2f * Time.deltaTime);

            if (!elsa.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Strafe Left"))
            {
                gameObject.GetComponent<AudioSource>().Play();
                elsa.GetComponent<Animator>().SetTrigger("IsStrafeLeft");
            }

            if (elsa.transform.position == elsaPos)
                startMove2 = false;
        }

        if (startMove3)
        {
            elsa.GetComponent<Animator>().SetBool("IsWalk", true);
            if (!startMove4)
            {
                elsa.transform.position = Vector3.MoveTowards(elsa.transform.position, elsaTarget1.transform.position, 8f * Time.deltaTime);
            }

            if (elsa.transform.position == elsaTarget1.transform.position)
            {
                startMove4 = true;
            }

            if(startMove4)
            {
                elsa.transform.rotation = Quaternion.Slerp(elsa.transform.rotation, Quaternion.LookRotation(player.transform.position - elsa.transform.position), (5f * Time.deltaTime));
                elsa.transform.position = Vector3.MoveTowards(elsa.transform.position, new Vector3(player.transform.position.x, (player.transform.position.y - 1.54f), player.transform.position.z), 8f * Time.deltaTime);
            }


            if (distance < 2 && !elsa.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Scream"))
            {
                elsa.GetComponent<Animator>().SetTrigger("IsScream");
                myAudio[6].Play();
                gameManagerScript.avviaCoroutine(1f, elsa);
                gameManagerScript.faseB = FaseB.photos;
                startMove3 = false;
                startMove4 = false;
            }
        }


    }

    //private IEnumerator ElsaScary2()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    elsa.SetActive(false);
    //    Destroy(gameObject);
    //}

    void OnTriggerEnter()
    {
        if (!trigDone && !triggered)
        {
            elsa.SetActive(true);
            elsa.transform.position = new Vector3(86.5f, 0, -568.66f);
            elsaPos = elsa.transform.position;
            elsa.transform.eulerAngles = new Vector3(0, 0, 0);
            myAudio[8].Play();
            startMove = true;
            trigDone = true;
            StartCoroutine(HideElsa());
        }

        if (triggered)
        {
            doorClose = true;
            StartCoroutine(ElsaScary());
        }


    }

    private IEnumerator ElsaScary()
    {
        startMove2 = false;
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        elsa.SetActive(true);
        elsa.transform.position = new Vector3(142.5f, 0, -570f);
        startMove3 = true;
    }

    private IEnumerator HideElsa()
    {
        yield return new WaitForSeconds(4f);
        startMove2 = true;
        StartCoroutine(HideElsa2());
    }

    private IEnumerator HideElsa2()
    {
        yield return new WaitForSeconds(2f);
        elsa.SetActive(false);
        //Destroy(gameObject);
    }
}
