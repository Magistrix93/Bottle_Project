using UnityEngine;
using PlayMaker;
using System.Collections;

public class DoorRaycast : MonoBehaviour
{
    private RaycastHit hit;
    private PlayMakerFSM fsm;
    private int layerMask;

    // Use this for initialization
    void Start()
    {
        layerMask = LayerMask.GetMask("Doors");
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, layerMask))
        {
            fsm = hit.collider.GetComponent<PlayMakerFSM>();
            fsm.FsmVariables.GetFsmBool("StartOpen").Value = true;

        }

            else if (fsm != null)
                fsm.FsmVariables.GetFsmBool("StartOpen").Value = false;


    }
}
