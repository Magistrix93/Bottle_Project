using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Doll : MonoBehaviour {

    private PlayMakerFSM myFsm;
    public bool doll;
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
        doll = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

        if (doll && activated)
        {
            button.GetComponent<Image>().sprite = button.GetComponent<ButtonSearch>().handIconUI;
            button.SetActive(true);
            activated = false;
        }

        else if (!doll && !activated)
        {
            button.SetActive(false);
            activated = true;
        }
    }
}
