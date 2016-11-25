using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using System;

public enum Fasi
{
    menu,
    A,
    B,
    C
}

public enum FaseA
{
    none,
    teddy,
    tv,
    diary,
    completed
}

public enum FaseB
{
    none,
    photos,
    frame,
    perspective,
    completed
}

public enum FaseC
{
    none,
    completed
}

public enum FasiEnigmaLavagna
{
    trovaFoto,
    inquadraLavagna,
    ImHere,
    completed
}


public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject elsa;
    private Lightmap switchLight;
    private PlayMakerFSM myFSM;
    [SerializeField]
    private GameObject enigmaA3;
    private PlayMakerFSM enigmaA3FSM;
    public GameObject phone;

    public GameObject ambient, ambient2, ambient3, ambient4, ambient5, randomSound;

    public float Xsensitive = 1f, Ysensitive = 1f;

    public Fasi fasi = Fasi.menu;
    public FaseA faseA = FaseA.none;
    public FaseB faseB = FaseB.none;
    public FaseC faseC = FaseC.none;

    public bool[] photos;

    public bool[] ovenClue;

    public bool framedFound;

    public FasiEnigmaLavagna enigmaLavagna = FasiEnigmaLavagna.trovaFoto;

    public bool phoneDisturbed = true;


    private GameObject textBox;

    private Text text;

    private GameObject Tip;

    private GameObject jumpscaresFather;

    private GameObject generalFather;

    [SerializeField]
    private GameObject[] jumpscares;

    private GameObject elsaFather;

    [SerializeField]
    private GameObject[] elsaJumpScares;

    public GameObject touchpad;
    private TouchPad pad;

    // Use this for initialization
    void Start()
    {
        switchLight = GetComponent<Lightmap>();
        myFSM = GetComponent<PlayMakerFSM>();
        photos = new bool[4];
        ovenClue = new bool[2];

        elsa = GameObject.FindGameObjectWithTag("Elsa");
        myFSM.FsmVariables.GetFsmGameObject("Elsa").Value = elsa;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (pad != null)
        {
            pad.Xsensitivity = Xsensitive;
            pad.Ysensitivity = Ysensitive;
        }

        switch (fasi)
        {
            case Fasi.A:
                {
                    switch (faseA)
                    {
                        case FaseA.diary:
                            {
                                enigmaA3FSM.FsmVariables.GetFsmBool("Enigma Telecomando").Value = true;
                                ambient.SetActive(false);
                                ambient2.SetActive(true);
                                elsaFather.SetActive(false);
                                break;
                            }

                        case FaseA.teddy:
                            {
                                enigmaA3FSM.FsmVariables.GetFsmBool("Enigma Telecomando").Value = true;
                                ambient.SetActive(false);
                                ambient2.SetActive(true);
                                elsaFather.SetActive(false);
                                break;
                            }

                        case FaseA.tv:
                            {
                                ambient.SetActive(false);
                                ambient2.SetActive(true);
                                elsaFather.SetActive(false);
                                break;
                            }

                        default:
                            { break; }
                    }
                    break;
                }

            case Fasi.B:
                {
                    switch (faseB)
                    {
                        case FaseB.frame:
                            {
                                ambient2.SetActive(false);
                                ambient5.SetActive(true);
                                elsaFather.SetActive(false);
                                break;
                            }
                        case FaseB.perspective:
                            {
                                ambient2.SetActive(false);
                                ambient5.SetActive(true);
                                elsaFather.SetActive(false);
                                break;
                            }
                        case FaseB.photos:
                            {
                                ambient2.SetActive(false);
                                ambient5.SetActive(true);
                                elsaFather.SetActive(false);
                                break;
                            }

                        default: { break; }
                    }

                    break;
                }


            case Fasi.C:
                { break; }
        }
    }

    public IEnumerator DeathElsa(float wait, GameObject elsa)
    {
        yield return new WaitForSeconds(wait);
        StartCoroutine(DeathLightmap());
        elsa.SetActive(false);

    }

    public IEnumerator DeathLightmap()
    {
        switchLight.SetLightmapDark();
        yield return new WaitForSeconds(0.5f);
        switchLight.SetLightmapNormal();
    }

    public void avviaCoroutine(float wait, GameObject elsa)
    {
        StartCoroutine(DeathElsa(wait, elsa));
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.buildIndex != 0)
        {
            touchpad = GameObject.FindGameObjectWithTag("TouchPad");
            pad = touchpad.GetComponent<TouchPad>();
        }

        if (elsa != null)
            elsa.SetActive(false);

        if (scene.buildIndex == 1)
        {
            enigmaA3 = GameObject.FindGameObjectWithTag("EnigmaA3");
            enigmaA3FSM = enigmaA3.GetComponent<PlayMakerFSM>();

        }

        if (scene.buildIndex == 1 || scene.buildIndex == 2)
        {
            phone = GameObject.FindGameObjectWithTag("Phone");
            textBox = GameObject.FindGameObjectWithTag("TextBox");
            text = textBox.transform.Find("Eng Text").GetComponent<Text>();
            textBox.SetActive(false);
            randomSound.SetActive(true);
            ActiveJumpscares();
        }
        else
        {
            Destroy(elsa);
            randomSound.SetActive(false);
        }

        switch (fasi)
        {
            case Fasi.A:
                {
                    switch (faseA)
                    {
                        case FaseA.none: { break; }

                        case FaseA.completed: { break; }

                        default:
                            {
                                phone.GetComponent<PlayMakerFSM>().SendEvent("Phone Ring");
                                break;
                            }
                    }
                    break;
                }
            case Fasi.B:
                {

                    switch (faseB)
                    {
                        case FaseB.none: { break; }

                        case FaseB.completed: { break; };

                        default:
                            {
                                phone.GetComponent<PlayMakerFSM>().SendEvent("Phone Ring");
                                break;
                            }
                    }
                    break;
                }
            case Fasi.C: { break; }

        }





    }

    public void StandardAds()
    {
        if (Advertisement.IsReady())
            Advertisement.Show();
    }

    public void RewardedAds(GameObject tip)
    {
        Tip = tip;
        if (Advertisement.IsReady("rewardedVideo"))
        {
            ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }

    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                {
                    GiveTip();
                    Tip.GetComponent<Tip>().ActiveController();
                    break;
                }

            case ShowResult.Failed:
                {
                    Tip.GetComponent<Tip>().ActiveController();
                    break;
                }

        }
    }

    public void GiveTip()
    {
        textBox.SetActive(true);
        switch (fasi)
        {
            case Fasi.A:
                {
                    float randomTip;
                    randomTip = UnityEngine.Random.Range(0, 3);
                    if (randomTip < 1 && randomTip >= 0)
                    {
                        text.text = "Look behind the pictures";
                    }
                    else if (randomTip >= 1 && randomTip < 2)
                    {
                        text.text = "Put Teddy inside the wardrobe";
                    }
                    else if (randomTip >= 2 && randomTip <= 3)
                    {
                        text.text = "The missing page is in the trash";
                    }
                    break;
                }
            case Fasi.B:
                {
                    float randomTip;
                    randomTip = UnityEngine.Random.Range(0, 3);
                    if (randomTip < 1 && randomTip >= 0)
                    {
                        text.text = "The completed photo goes in the living room";
                    }
                    else if (randomTip >= 1 && randomTip < 2)
                    {
                        text.text = "Use the photo inside the room";
                    }
                    else if (randomTip >= 2 && randomTip <= 3)
                    {
                        text.text = "The girl is framed inside the painting";
                    }
                    break;
                }
            case Fasi.C:
                {
                    text.text = "The exit is in the beginning";
                    break;
                }
        }
        StartCoroutine(DisableText());
    }

    private IEnumerator DisableText()
    {
        yield return new WaitForSeconds(4f);
        textBox.SetActive(false);
    }


    public void ActiveJumpscares()
    {
        StopAllCoroutines();
        jumpscaresFather = GameObject.FindGameObjectWithTag("JumpScares");
        generalFather = jumpscaresFather.transform.Find("General").gameObject;
        elsaFather = jumpscaresFather.transform.Find("Elsa Jumpscares").gameObject;

        int childcount = generalFather.transform.childCount;
        jumpscares = new GameObject[childcount];

        int elsaChildCount = elsaFather.transform.childCount;
        elsaJumpScares = new GameObject[elsaChildCount];

        for (int i = 0; i < jumpscares.Length; i++)
        {
            jumpscares[i] = generalFather.transform.GetChild(i).gameObject;
            jumpscares[i].SetActive(false);
        }

        for (int i = 0; i < elsaJumpScares.Length; i++)
        {
            elsaJumpScares[i] = elsaFather.transform.GetChild(i).gameObject;
            elsaJumpScares[i].SetActive(false);
        }

        int random1 = 0, random2 = 0;

        random1 = UnityEngine.Random.Range(0, childcount);
        do
        {
            random2 = UnityEngine.Random.Range(0, childcount);
        }
        while (random1 == random2);

        if (fasi == Fasi.A)
            StartCoroutine(DelayFirstScare(random1, random2));

        else
        {
            jumpscares[random1].SetActive(true);
            jumpscares[random2].SetActive(true);
        }

        if (fasi == Fasi.A)
        {
            random1 = UnityEngine.Random.Range(0, 3);
            elsaJumpScares[random1].SetActive(true);
        }
        else
        {
            random1 = UnityEngine.Random.Range(0, elsaChildCount);
            elsaJumpScares[random1].SetActive(true);
        }


    }

    private IEnumerator DelayFirstScare(int random1, int random2)
    {

        yield return new WaitForSeconds(90f);
        jumpscares[random1].SetActive(true);
        StartCoroutine(DelaySecondScare(random2));
    }

    private IEnumerator DelaySecondScare(int random2)
    {
        yield return new WaitForSeconds(60f);
        jumpscares[random2].SetActive(true);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
