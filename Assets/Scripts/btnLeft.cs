using UnityEngine;
using System.Collections;

public class btnLeft : MonoBehaviour
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

        if (minutes == 0)
        {
            minutes = 55;
            hours--;
        }
        else
            minutes = minutes - 5;

        clockScript.minutes = minutes;
        clockScript.hour = hours;
    }
}
