using UnityEngine;
using System.Collections;

public class BambolaPosto : MonoBehaviour {

    private PlayMakerFSM myFsm;
    public bool slotDoll;
    private bool activated = true;
    public GameObject button;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        slotDoll = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

        if (slotDoll && activated)
        {
            button.SetActive(true);
            activated = false;
        }

        else if (!slotDoll && !activated)
        {
            button.SetActive(false);
            activated = true;
        }
    }
}
