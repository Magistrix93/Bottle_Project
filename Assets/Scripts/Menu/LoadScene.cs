using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    private GameObject gameManager;
    private GameObject Elsa;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        Elsa = GameObject.FindGameObjectWithTag("Elsa");
        DontDestroyOnLoad(Elsa);
        DontDestroyOnLoad(gameManager);
    }

    public void LoadByIndex(int sceneIndex)
    {
        gameManager.GetComponent<GameManager>().fasi = Fasi.A;
        if (Advertisement.IsReady())
            Advertisement.Show();

        SceneManager.LoadScene(sceneIndex);
    }
}
