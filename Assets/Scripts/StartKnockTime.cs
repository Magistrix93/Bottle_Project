using UnityEngine;
using System.Collections;

public class StartKnockTime : MonoBehaviour
{

    public GameObject slotDoll;
    public bool trigOn;
    public ClockEvent startTime;

    // Use this for initialization
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        trigOn = slotDoll.GetComponent<BambolaPosto>().slotDollON;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && trigOn && !startTime.scaryStep)
        {
            startTime.enabled = true;
        }
    }
}
