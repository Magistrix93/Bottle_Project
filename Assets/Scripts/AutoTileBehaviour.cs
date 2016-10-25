using UnityEngine;
using System.Collections;

public class AutoTileBehaviour : MonoBehaviour
{
    private Material[] materials;

    private Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        SetTiling();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTiling()
    {        
        rend.material.mainTextureScale = (new Vector2(transform.parent.localScale.x, transform.parent.localScale.z));
    }
}

