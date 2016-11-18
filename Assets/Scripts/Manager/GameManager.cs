using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private btnExit btnexit;
    private PlayMakerFSM myFSM;
    [SerializeField]
    private GameObject enigmaA3;
    private PlayMakerFSM enigmaA3FSM;
    public GameObject phone;

    public GameObject ambient, ambient2, ambient3, ambient4;

    public Fasi fasi = Fasi.menu;
    public FaseA faseA = FaseA.none;
    public FaseB faseB = FaseB.none;
    public FaseC faseC = FaseC.none;

    public bool[] photos;

    public bool[] ovenClue;

    public bool framedFound;

    public FasiEnigmaLavagna enigmaLavagna = FasiEnigmaLavagna.trovaFoto;

    public bool phoneDisturbed = true;

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
                                break;
                            }

                        case FaseA.teddy:
                            {
                                enigmaA3FSM.FsmVariables.GetFsmBool("Enigma Telecomando").Value = true;
                                ambient.SetActive(false);
                                ambient2.SetActive(true);
                                break;
                            }

                        case FaseA.tv:
                            {
                                ambient.SetActive(false);
                                ambient2.SetActive(true);
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
                                ambient4.SetActive(true);
                                break;
                            }
                        case FaseB.perspective:
                            {
                                ambient2.SetActive(false);
                                ambient4.SetActive(true);
                                break;
                            }
                        case FaseB.photos:
                            {
                                ambient2.SetActive(false);
                                ambient4.SetActive(true);
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
        phone = GameObject.FindGameObjectWithTag("Phone");
        elsa.SetActive(false);
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


        if (scene.buildIndex == 1)
        {
            enigmaA3 = GameObject.FindGameObjectWithTag("EnigmaA3");
            enigmaA3FSM = enigmaA3.GetComponent<PlayMakerFSM>();
        }



    }
}
