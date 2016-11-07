using UnityEngine;
using System.Collections;

public class imgArmadio : MonoBehaviour {

    private PlayMakerFSM myFsm;
    public bool imgWardrobe;
    private bool activated = true;
    public GameObject button;
    public GameObject note3;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        imgWardrobe = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

        if (imgWardrobe && activated)
        {
            button.SetActive(true);
            activated = false;
        }

        else if (!imgWardrobe && !activated)
        {
            button.SetActive(false);
            activated = true;
        }

        if (!imgWardrobe)
            note3.SetActive(false);
    }
}
