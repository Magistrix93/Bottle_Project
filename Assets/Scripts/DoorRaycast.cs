using UnityEngine;
using PlayMaker;
using System.Collections;

public class DoorRaycast : MonoBehaviour
{
    private RaycastHit hit;
    public GameObject thisCast, lateCast;
    private int layerMask;

    // Use this for initialization
    void Start()
    {
        layerMask = LayerMask.GetMask("Items");
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, layerMask))
        {
            thisCast = hit.collider.gameObject;
            if (thisCast != lateCast)
            {
                if (lateCast != null)
                {
                    lateCast.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmBool("StartOpen").Value = false;
                }

                lateCast = thisCast;

                if (lateCast.GetComponent<PlayMakerFSM>() != null)
                    lateCast.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmBool("StartOpen").Value = true;

            }

            

        }

        else if (lateCast != null)
        {
            if(lateCast.GetComponent<PlayMakerFSM>() != null)
                lateCast.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmBool("StartOpen").Value = false;
            lateCast = null;
        }


    }
}
