using UnityEngine;
using System.Collections;

public class AndroidManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        #if UNITY_ANDROID

                Application.targetFrameRate = 60;

                QualitySettings.vSyncCount = 0;

                QualitySettings.antiAliasing = 0;


        #endif
    }

    // Update is called once per frame
    void Update () {
	
	}
}
