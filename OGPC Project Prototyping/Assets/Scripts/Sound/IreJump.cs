using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IreJump : MonoBehaviour
{

    private GameObject player;
    public Sound ireJump;

    void Start()
    {

        player = GameObject.Find("Player");

        AudioSource source = gameObject.AddComponent<AudioSource>();
        AudioClip clip = ireJump.clip;
        ireJump = new Sound(source, clip, 1);

        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && player.GetComponent<PlayerRigidbodyController2Dver2>().inIre) ireJump.source.Play();
    }
}
