using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{
    public int minutes;
    public int hour;

    private GameObject pointerMinutes;
    private GameObject pointerHours;
    public GameObject buttonRight;
    public GameObject buttonLeft;

    void Start()
    {
        pointerMinutes = transform.Find("rotation_axis_pointer_minutes").gameObject;
        pointerHours = transform.Find("rotation_axis_pointer_hour").gameObject;
    }
    
    void Update()
    {
        
        //-- calculate pointer angles
        float rotationMinutes = (360.0f / 60.0f) * minutes;
        float rotationHours = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

        //-- draw pointers
        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);

    }
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
}
