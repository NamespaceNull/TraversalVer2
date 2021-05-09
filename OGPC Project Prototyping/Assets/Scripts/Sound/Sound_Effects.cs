using UnityEngine.Audio;
using System;
using UnityEngine;

public class Sound_Effects : MonoBehaviour
{

    // ArrayList of all non-colliion sound effects
    // Set the size to 8
    // Set the audio clips as follows: 0 is Footsteps, 1 is Start Glide, 2 is Gliding, 3 is Glide End, 4 is Jump 1
    // 5 is Jump 2, 6 is Jump 3, 7 is Jump 4
    public Sound[] soundEffects;
    private GameObject player;

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
        soundEffects[0].source.volume = 0;
        soundEffects[0].source.loop = true;
        // gliding
        soundEffects[2].source.volume = 0;
        soundEffects[2].source.loop = true;
        // Glide End
        soundEffects[3].source.volume = .5F;
    }

    void Start()
    {
        player = GameObject.Find("Player");
        soundEffects[0].source.Play();
        soundEffects[2].source.Play();
    }

    void Update()
    {
        // Footsteps
        // Replace true with !(conditional for when gliding)
        if ((Mathf.Abs(player.GetComponent<PlayerRigidbodyController2Dver2>().rb.velocity.x) > 0) && player.GetComponent<PlayerRigidbodyController2Dver2>().isGrounded)
        {
            soundEffects[0].source.volume = 1;

        } else
        {
            soundEffects[0].source.volume = 0;

        }

        // Start Gliding
        if (Input.GetKeyDown(KeyCode.W) && !(player.GetComponent<PlayerRigidbodyController2Dver2>().isGrounded)) soundEffects[1].source.Play();

        // Gliding
        if ((Input.GetKey(KeyCode.W)) && !(player.GetComponent<PlayerRigidbodyController2Dver2>().isGrounded))
        {
            soundEffects[2].source.volume = 1;

        }
        else
        {
            soundEffects[2].source.volume = 0;
        }

        //Glide end
        if (Input.GetKeyUp(KeyCode.W) && !(player.GetComponent<PlayerRigidbodyController2Dver2>().isGrounded)) soundEffects[3].source.Play();

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && player.GetComponent<PlayerRigidbodyController2Dver2>().isGrounded)
        {
            int i = UnityEngine.Random.Range(4, 8);
            soundEffects[i].source.Play();
            
        }


    }
}