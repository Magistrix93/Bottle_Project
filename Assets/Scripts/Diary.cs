using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Diary : MonoBehaviour
{


    private PlayMakerFSM myFsm;
    public bool diaryRead;
    private bool activated=true;
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
        diaryRead = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

        if (diaryRead && activated)
        {
            button.SetActive(true);
            activated = false;            
        }           

        else if (!diaryRead && !activated)
        {
            button.SetActive(false);
            activated = true;
        }

        if (!diaryRead)
            note1.SetActive(false);

    }
}
