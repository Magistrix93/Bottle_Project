using UnityEngine;
using System.Collections;

public class btnRight : MonoBehaviour
{
    public GameObject clock;
    public int minutes;
    public int hours;
    private Clock clockScript;

    // Use this for initialization
    void Start()
    {
       clockScript = clock.GetComponent<Clock>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        minutes = clockScript.minutes;
        hours = clockScript.hour;


        minutes = minutes + 5;

        if (minutes > 60)
        {
            minutes = 5;
            hours++;
        }

        clockScript.minutes = minutes;
        clockScript.hour = hours;
    }
}
