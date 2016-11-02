using UnityEngine;
using System.Collections;
using PlayMaker;

public class CartaCestino : MonoBehaviour
{

    private PlayMakerFSM myFsm;
    private bool cartaOk;

    // Use this for initialization
    void Start()
    {
        myFsm = GetComponent<PlayMakerFSM>();
        
    }

    // Update is called once per frame
    void Update()
    {
        cartaOk = myFsm.FsmVariables.GetFsmBool("StartOpen").Value;
        if(cartaOk)
        {

        }
    }
}
