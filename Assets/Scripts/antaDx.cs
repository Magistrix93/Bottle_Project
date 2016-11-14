using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class antaDx : Items
{

    private PlayMakerFSM myFsm;
    public bool AntaDx;
    public bool activated = true;
    public GameObject button;
    public AudioSource[] sounds;
    private Animation antaDxAnim;
    public bool checkDx = true;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
        sounds = GetComponents<AudioSource>();
        antaDxAnim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        AntaDx = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;

        if (AntaDx && activated)
        {
            button.GetComponent<ButtonSearch>().rayObject = this.gameObject;
            button.GetComponent<Image>().sprite = button.GetComponent<ButtonSearch>().searchIconUI;
            button.SetActive(true);
            activated = false;
        }

        else if (!AntaDx && !activated)
        {
            button.SetActive(false);
            activated = true;
        }
    }

    public override void OnClicked()
    {
        if (checkDx && !antaDxAnim.IsPlaying("Mobile 4 Close"))
        {
            antaDxAnim.Play("Mobile 4 Open");
            sounds[0].Play();
            checkDx = false;
        }
        else if (!checkDx && !antaDxAnim.IsPlaying("Mobile 4 Open"))
        {
            antaDxAnim.Play("Mobile 4 Close");
            sounds[1].Play();
            checkDx = true;
        }
    }
}
