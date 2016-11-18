using UnityEngine;
using System.Collections;

public class StartKnockTime : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager gameManagerScript;

    public GameObject slotDoll;
    public bool trigOn;
    public ClockEvent startTime;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        if (gameManagerScript.fasi != Fasi.A)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        trigOn = slotDoll.GetComponent<BambolaPosto>().slotDollON;
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameManagerScript.faseA == FaseA.none)
            if (other.tag == "Player" && trigOn && !startTime.scaryStep)
            {
                startTime.enabled = true;
            }

    }
}
