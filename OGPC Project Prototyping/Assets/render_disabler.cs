using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class render_disabler : MonoBehaviour
{
    int i;
    void Start()
    {
        GetComponent<SpriteRenderer>().forceRenderingOff = true;
        i = 0;
    }

    void Update()
    {
        i++;

        if(i == 150) GetComponent<SpriteRenderer>().forceRenderingOff = false;


    }
}
