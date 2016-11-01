using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Audio : MonoBehaviour {

    private AudioSource audio;

    public Slider volumeSlider;

	// Use this for initialization
	void Start () {

        audio = GetComponent<AudioSource>();
	
	}

    public void changeVolume()
    {
        audio.volume = volumeSlider.value;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
