using UnityEngine;
using UnityEngine.UI;
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
            button.GetComponent<Image>().sprite = button.GetComponent<ButtonSearch>().handIconUI;
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
