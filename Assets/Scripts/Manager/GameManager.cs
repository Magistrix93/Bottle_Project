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

public enum FaseB
{
    none,
    photos,
    frame,
    perspective,
    completed
}

public enum FaseA
{
    none,
    teddy,
    tv,
    diary,
    completed
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject elsa;
    private Lightmap switchLight;
    [SerializeField]
    private btnExit btnexit;
    private PlayMakerFSM switchLightmap;
    [SerializeField]
    private GameObject enigmaA3;
    private PlayMakerFSM enigmaA3FSM;
    public Fasi fasi = Fasi.menu;
    public FaseA faseA = FaseA.none;
    public FaseB faseB = FaseB.none;

    // Use this for initialization
    void Start()
    {
        switchLight = GetComponent<Lightmap>();
        switchLightmap = GetComponent<PlayMakerFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        switch (fasi)
        {
            case Fasi.A:
                {
                    switch (faseA)
                    {
                        case FaseA.diary:
                            {
                                enigmaA3FSM.FsmVariables.GetFsmBool("Enigma Telecomando").Value = true;
                                break;
                            }

                        case FaseA.teddy:
                            {
                                enigmaA3FSM.FsmVariables.GetFsmBool("Enigma Telecomando").Value = true;
                                break;
                            }

                        case FaseA.none:
                            {
                                if (btnexit != null && btnexit.on)
                                {
                                    switchLightmap.SendEvent("JumpScareClock");
                                    btnexit.on = false;
                                }

                                break;
                            }

                        default:
                            {
                                break;
                            }
                    }
                    break;
                }

            case Fasi.B:
                {

                    break;
                }

            case Fasi.C: { break; }
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
       
        if (scene.buildIndex == 1)
        {
            enigmaA3 = GameObject.FindGameObjectWithTag("EnigmaA3");
            enigmaA3FSM = enigmaA3.GetComponent<PlayMakerFSM>();
            btnexit = GameObject.FindGameObjectWithTag("BtnExit").GetComponent<btnExit>();
            btnexit.audioSlam = switchLightmap.FsmVariables.GetFsmGameObject("Sound effects").Value;
            btnexit.gameObject.SetActive(false);
            
        }

        elsa = GameObject.FindGameObjectWithTag("Elsa");
        switchLightmap.FsmVariables.GetFsmGameObject("Elsa").Value = elsa;
        elsa.SetActive(false);
    }
}
