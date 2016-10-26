using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour
{
    private GameObject player;
    public bool check = false;
    private RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 20))
            if (hit.collider.CompareTag("Player"))
            check = true;
    }
}
