using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Sound_Effects : MonoBehaviour
{

    // ArrayList of all non-colliion sound effects
    // Set the size to 8
    // Set the audio clips as follows: 0 is Footsteps, 1 is Start Glide, 2 is Gliding, 3 is Glide End, 4 is Jump 1
    // 5 is Jump 2, 6 is Jump 3, 7 is Jump 4
    public Sound[] soundEffects;
    private GameObject player;
    int finaleCount;
    bool timerStarter;

    // Code will run when the game is started
    void Awake()
    {
        
        // Loop through each sound and assign it values
        foreach (Sound s in soundEffects)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = 1;
            s.source.pitch = 1;
            s.source.loop = false;
            s.source.playOnAwake = true;
        }
        // footstps
        soundEffects[0].source.loop = true;
        // gliding
        soundEffects[2].source.loop = true;
        // Glide End
        soundEffects[3].source.volume = .3F; // this is a Zach edit, needed this for my sanity it was 0.5f before
        //Jumps
        soundEffects[4].source.volume = .3F;
        soundEffects[5].source.volume = .3F;
        soundEffects[6].source.volume = .3F;
        soundEffects[7].source.volume = .3F;

    }

    void Start()
    {
        player = GameObject.Find("Player");
        soundEffects[0].source.Play();
        soundEffects[2].source.Play();

        timerStarter = true;
    }

    void Update()
    {
        finaleCount = GetComponent<Music_Listener>().finaleCount;
        // Footsteps
        // Replace true with !(conditional for when gliding)
       // if (finaleCount <= 5)
       // { 
            if ((Mathf.Abs(player.GetComponent<PlayerRigidbodyController2Dver2>().rb.velocity.x) > 0) && player.GetComponent<PlayerRigidbodyController2Dver2>().isGrounded)
            {
                soundEffects[0].source.mute = false;

            } else
            {
                soundEffects[0].source.mute = true;

            }

            // Start Gliding
            if (Input.GetKeyDown(KeyCode.W) && !(player.GetComponent<PlayerRigidbodyController2Dver2>().isGrounded) && !(player.GetComponent<PlayerRigidbodyController2Dver2>().inIre)) soundEffects[1].source.Play();

            // Gliding
            if ((Input.GetKey(KeyCode.W)) && !(player.GetComponent<PlayerRigidbodyController2Dver2>().isGrounded) && !(player.GetComponent<PlayerRigidbodyController2Dver2>().inIre))
            {
                soundEffects[2].source.mute = false;

        }
            else
            {
                soundEffects[2].source.mute = true;
        }

            //Glide end
            if (Input.GetKeyUp(KeyCode.W) && !(player.GetComponent<PlayerRigidbodyController2Dver2>().isGrounded) && !(player.GetComponent<PlayerRigidbodyController2Dver2>().inIre)) soundEffects[3].source.Play();

            //Jumping
            if (Input.GetKeyDown(KeyCode.Space) && player.GetComponent<PlayerRigidbodyController2Dver2>().isGrounded)
            {
                int i = UnityEngine.Random.Range(4, 8);
                soundEffects[i].source.Play();
            
            }
      //  }
        if (finaleCount >= 5 && timerStarter)
        {
            StartCoroutine("volumeFade");

            timerStarter = false;
        }


    }

    public IEnumerator volumeFade()
    {
        for (int i = 0; i < 10000; i++)
        {
            soundEffects[0].source.volume -= .005f;
            soundEffects[1].source.volume -= .005f;
            soundEffects[2].source.volume -= .005f;
            soundEffects[3].source.volume -= .005f;
            soundEffects[4].source.volume -= .003f;
            soundEffects[5].source.volume -= .003f;
            soundEffects[6].source.volume -= .003f;
            soundEffects[7].source.volume -= .003f;

            yield return null;
        }
    }
}