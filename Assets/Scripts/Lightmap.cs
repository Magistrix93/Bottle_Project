using UnityEngine;
using System;
using System.Collections;

public class Lightmap : MonoBehaviour
{
    private LightmapData[] lightmapNormal, lightmapDark;

    // Use this for initialization
    void Start()
    {
        lightmapNormal = new LightmapData[17];

        lightmapDark = new LightmapData[17];

        for (int i = 0; i < 17; i++)
        {
            lightmapNormal[i] = new LightmapData();
            lightmapNormal[i].lightmapFar = Resources.Load("Scena_1/Lightmap-" + i.ToString() + "_comp_light", typeof(Texture2D)) as Texture2D;
        }
        for (int i = 0; i < 17; i++)
        {
            lightmapDark[i] = new LightmapData();
            lightmapDark[i].lightmapFar = Resources.Load("Scena_1_Buia/Lightmap-" + i.ToString() + "_comp_light", typeof(Texture2D)) as Texture2D;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetLightmapNormal()
    {
        LightmapSettings.lightmaps = lightmapNormal;
    }

    public void SetLightmapDark()
    {
        LightmapSettings.lightmaps = lightmapDark;
    }
}
