using UnityEngine;
using System;
using System.Collections;

public class Lightmap : MonoBehaviour
{
    private LightmapData[] lightmap;

    // Use this for initialization
    void Start()
    {
        lightmap = new LightmapData[6];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            for (int i = 0; i < 6; i++)
            {
                lightmap[i] = new LightmapData();
                lightmap[i].lightmapFar = Resources.Load("Scena_1_Rossa/Lightmap-" + i.ToString() + "_comp_light", typeof(Texture2D)) as Texture2D;
            }

            LightmapSettings.lightmaps = lightmap;
        }

        if (Input.GetKeyDown("k"))
            {
                for (int i = 0; i < 6; i++)
                {
                    lightmap[i] = new LightmapData();
                    lightmap[i].lightmapFar = Resources.Load("Scena_1/Lightmap-" + i.ToString() + "_comp_light", typeof(Texture2D)) as Texture2D;
                }

                LightmapSettings.lightmaps = lightmap;
            }
    }
}
