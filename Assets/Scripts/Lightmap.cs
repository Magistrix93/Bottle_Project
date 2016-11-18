using UnityEngine;
using System;
using System.Collections;

public class Lightmap : MonoBehaviour
{
    private LightmapData[] lightmapNormalPulita, lightmapDarkPulita, lightmapNormalSporca, lightmapDarkSporca;

    // Use this for initialization
    void Start()
    {
        lightmapNormalPulita = new LightmapData[6];

        lightmapDarkPulita = new LightmapData[6];

        lightmapNormalSporca = new LightmapData[6];

        lightmapDarkSporca = new LightmapData[6];

        for (int i = 0; i < 6; i++)
        {
            lightmapNormalPulita[i] = new LightmapData();
            lightmapNormalPulita[i].lightmapFar = Resources.Load("Scena_1/Lightmap-" + i.ToString() + "_comp_light", typeof(Texture2D)) as Texture2D;

            lightmapDarkPulita[i] = new LightmapData();
            lightmapDarkPulita[i].lightmapFar = Resources.Load("Scena_1_Buia/Lightmap-" + i.ToString() + "_comp_light", typeof(Texture2D)) as Texture2D;

            lightmapNormalSporca[i] = new LightmapData();
            lightmapNormalSporca[i].lightmapFar = Resources.Load("Scena_2/Lightmap-" + i.ToString() + "_comp_light", typeof(Texture2D)) as Texture2D;

            lightmapDarkSporca[i] = new LightmapData();
            lightmapDarkSporca[i].lightmapFar = Resources.Load("Scena_2_Buia/Lightmap-" + i.ToString() + "_comp_light", typeof(Texture2D)) as Texture2D;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetLightmapNormal()
    {
        LightmapSettings.lightmaps = lightmapNormalPulita;
    }

    public void SetLightmapDark()
    {
        LightmapSettings.lightmaps = lightmapDarkPulita;
    }

    public void SetLightmapNormalSporca()
    {
        LightmapSettings.lightmaps = lightmapNormalSporca;
    }

    public void SetLightmaDarkSporca()
    {
        LightmapSettings.lightmaps = lightmapDarkSporca;
    }
}
