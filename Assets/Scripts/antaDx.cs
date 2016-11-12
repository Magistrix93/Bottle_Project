using UnityEngine;
using System.Collections;

public class antaDx : MonoBehaviour {

	private PlayMakerFSM myFsm;
    public bool AntaDx;
    private bool activated = true;
    public GameObject button;
    public AudioSource[] sounds;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
        sounds = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AntaDx = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

        if (AntaDx && activated)
        {
            button.SetActive(true);
            activated = false;
        }

        else if (!AntaDx && !activated)
        {
            button.SetActive(false);
            activated = true;
        }
    }
}
