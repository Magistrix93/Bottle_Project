using UnityEngine;
using System.Collections;

public class AntaSx : MonoBehaviour {

    private PlayMakerFSM myFsm;
    public bool antaSx;
    public bool activated = true;
    public GameObject button;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        antaSx = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

        if (antaSx && activated)
        {
            button.SetActive(true);
            activated = false;
        }

        else if (!antaSx && !activated)
        {
            button.SetActive(false);
            activated = true;
        }
    }
}
