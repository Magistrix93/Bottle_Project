using UnityEngine;
using System.Collections;

public class timeJumpScare : MonoBehaviour
{
    private GameObject elsa;
    public GameObject player;
    public GameObject[] spawnPoints;
    public Lightmap switchLight;
    private int i;

    private GameObject gameManager;
    private GameManager gameManagerScript;


    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        elsa = gameManagerScript.elsa;
    }

    // Update is called once per frame
    void Update()
    {
        for (i = 0; i < 3; i++)
        {
            elsa.SetActive(true);

            if (i == 0)
            {
               
                elsa.transform.position = spawnPoints[1].transform.position;
                elsa.transform.LookAt(player.transform.position);
                elsa.GetComponent<Animator>().SetBool("isWalk", true);
                elsa.transform.position = Vector3.MoveTowards(elsa.transform.position, player.transform.position, 2f);
                StartCoroutine("wait");
            }
        }

    }




    IEnumerator wait()
    {
        switchLight.SetLightmapDark();

        yield return new WaitForSecondsRealtime(2.5f);
        switchLight.SetLightmapNormal();
        yield return new WaitForSecondsRealtime(2.5f);
    }
}
