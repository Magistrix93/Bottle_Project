using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class imgArmadio : MonoBehaviour {

    private PlayMakerFSM myFsm;
    public bool imgWardrobe;
    private bool activated = true;
    public GameObject button;
    public GameObject note1;

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
            button.GetComponent<Image>().sprite = button.GetComponent<ButtonSearch>().searchIconUI;
            button.SetActive(true);
            activated = false;
        }

        else if (!imgWardrobe && !activated)
        {
            button.SetActive(false);
            activated = true;
            note1.SetActive(false);
        }            
    }
}
