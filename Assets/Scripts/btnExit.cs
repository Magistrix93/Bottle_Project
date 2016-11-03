using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class btnExit : MonoBehaviour {

    public GameObject camTime;
    public GameObject mainCam;
    public GameObject controller1;
    public GameObject controller2;
    public GameObject buttonExit;
    public GameObject btnLeft;
    public GameObject btnRight;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        mainCam.SetActive(true);
        camTime.SetActive(false);
        controller1.GetComponent<Image>().enabled = true;
        controller2.GetComponent<Image>().enabled = true;
        buttonExit.SetActive(false);
        btnLeft.SetActive(false);
        btnRight.SetActive(false);
    }
}
