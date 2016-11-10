using UnityEngine;
using PlayMaker;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public PlayMakerFSM phone;
    public GameObject elsa;
    public ButtonSearch events;
    private Lightmap switchLight;
    public btnExit btnexit;
    private PlayMakerFSM switchLightmap;
    public PlayMakerFSM faseA3;
    public bool startJumpscare;
    public bool timeEventDone;
    public bool dollEventDone;

    // Use this for initialization
    void Start()
    {
        switchLight = GetComponent<Lightmap>();
        switchLightmap = GetComponent<PlayMakerFSM>();
        timeEventDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        dollEventDone = events.dollDone;
        startJumpscare = btnexit.on;

        if (timeEventDone)
        {
            events.faseA2 = false;
            faseA3.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmBool("Enigma Telecomando").Value = true;
            //phone.enabled = true;
        }

        if (dollEventDone)
        {
            events.faseA1 = false;
            faseA3.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmBool("Enigma Telecomando").Value = true;
            //phone.enabled = true;
        }

        if (startJumpscare && !timeEventDone)
        {
            switchLightmap.SendEvent("JumpScareClock");
            startJumpscare = false;
            timeEventDone = true;
        }

    }

    public IEnumerator DeathElsa(float wait, GameObject elsa)
    {
        yield return new WaitForSeconds(wait);
        StartCoroutine(DeathLightmap());
        elsa.SetActive(false);

    }

    public IEnumerator DeathLightmap()
    {
        GetComponent<Lightmap>().SetLightmapDark();
        yield return new WaitForSeconds(0.5f);
        GetComponent<Lightmap>().SetLightmapNormal();
    }

    public void avviaCoroutine()
    {
        StartCoroutine(DeathElsa(1f, elsa));
    }
}
