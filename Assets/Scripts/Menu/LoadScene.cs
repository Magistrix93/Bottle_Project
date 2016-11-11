using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        DontDestroyOnLoad(gameManager);
    }

    public void LoadByIndex(int sceneIndex)
    {
        gameManager.GetComponent<GameManager>().fasi = Fasi.A;
        SceneManager.LoadScene(sceneIndex);
    }
}
