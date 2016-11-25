using UnityEngine;
using System.Collections;

public class Tip : MonoBehaviour
{

    private GameObject gameManager;
    private GameManager gameManagerScript;

    public GameObject analog;
    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClicked()
    {
        gameManagerScript.RewardedAds(gameObject);
        Vector3 analogPos = analog.GetComponent<UnityStandardAssets.CrossPlatformInput.Joystick>().m_StartPos;
        analog.GetComponent<UnityStandardAssets.CrossPlatformInput.Joystick>().UpdateVirtualAxes(analogPos);
        analog.transform.position = analogPos;   
        Input.ResetInputAxes();
    }

    public void ActiveController()
    {
        Vector3 analogPos = analog.GetComponent<UnityStandardAssets.CrossPlatformInput.Joystick>().m_StartPos;        
        analog.transform.position = analogPos;
        analog.GetComponent<UnityStandardAssets.CrossPlatformInput.Joystick>().UpdateVirtualAxes(analogPos);
        Input.ResetInputAxes();
    }
}
