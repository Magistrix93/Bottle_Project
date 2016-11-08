using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public PlayMakerFSM phone;
    public ButtonSearch events;
    public StartKnockTime triggerDoll;
    public bool timeEventDone;
    public bool dollEventDone;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeEventDone = events.timeON;
        dollEventDone = events.dollDone;

        if (timeEventDone)
        {
            events.faseA2 = false;
            phone.enabled = true; 
        }
            

        if (dollEventDone)
        {
            events.faseA1 = false;
            phone.enabled = true;
        }
            
    }
}
