using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlideSensibility : MonoBehaviour
{

    public enum Axis { X, Y};
    public Axis thisAxys;

    private GameObject gameManager;
    private GameManager gameManagerScript;

    private Slider mySlider;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        mySlider = GetComponent<Slider>();
        if (thisAxys == Axis.X)
            mySlider.value = gameManagerScript.Xsensitive;
        else
            mySlider.value = gameManagerScript.Ysensitive;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnChangeValue()
    {
        if (thisAxys == Axis.X)
            gameManagerScript.Xsensitive = mySlider.value;
        else
            gameManagerScript.Ysensitive = mySlider.value;
    }
}
