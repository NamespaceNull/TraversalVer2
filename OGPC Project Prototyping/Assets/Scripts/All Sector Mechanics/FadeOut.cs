using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    bool on;
    bool happened = true;
    [HideInInspector]
    public GameObject Player;

    void Awake()
    {
        Player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Player.GetComponent<PlayerRigidbodyController2Dver2>().rb.velocity.x < 0)
        {
            if (happened)
            {
                StartCoroutine("fade");
                happened = false;
                Debug.Log("coroutine should start");
            }
        }

    }

    public IEnumerator fade()
    {
        for (int i = 0; i < 100; i++)
        {
            Screen.brightness -= .001f;

            yield return null;
        }
    }
}
