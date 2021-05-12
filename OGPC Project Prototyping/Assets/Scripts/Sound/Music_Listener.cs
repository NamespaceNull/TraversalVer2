
using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;



public class Music_Listener : MonoBehaviour
{
    // Establish constants for y levels of zones (NEEDS TO BE SET TO REAL VALUES)
    public const int ANXIETY = 1;
    public const int DESTRUCTION = 2;
    public const int MASTERY = 3;
    public const int FINALE = 36;


    // Creat ArrayList of each of the 4 tracks
    public Sound[] sounds;

    /*
    // Testing feature to change sounds with W and S
    [HideInInspector]
    public int counter = 0;
    */

    // end of game is finale bool
    [HideInInspector]
    public int finaleCount;

    //Timer for end chord prog
    float timer;
    bool timerStarter;
    bool chordProg;
    bool chordProgEnd;

    // Code will run when the game is started
    void Awake()
    {
        // Loop through each sound and assign it values
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = .1f;
            s.source.pitch = 1;
            s.source.loop = true;
            s.source.playOnAwake = true;
            

        }
        // All of the volumes are currently set to 0 and isolation needs to play in the beginning

        // end sounds need to be non-looped and have volume
        sounds[4].source.loop = false;
        sounds[4].source.volume = 1;
        sounds[5].source.loop = false;
        sounds[5].source.volume = 1;

        timerStarter = true;
        chordProg = true;
        chordProgEnd = true;

       
    }

    // Code will run when this object is created
    void Start()
    {
        // All of the tracks will play, but only Isolation has Volume at this point
        sounds[0].source.Play();
        sounds[1].source.Play();
        sounds[2].source.Play();
        sounds[3].source.Play();


    }

    // Code will run every frame
    void Update()
    {


        // Dictates what music is playing based on the y level of the camera
        if (transform.position.y >= ANXIETY) sounds[1].source.mute = false;
        if (transform.position.y >= DESTRUCTION) sounds[2].source.mute = false;
        if (transform.position.y >= MASTERY) sounds[3].source.mute = false;

        if (transform.position.y < ANXIETY) sounds[1].source.mute = true;
        if (transform.position.y < DESTRUCTION) sounds[2].source.mute = true;
        if (transform.position.y < MASTERY) sounds[3].source.mute = true;


        /*
        // Testing feature to change sounds with W and S
        if (Input.GetKeyDown(KeyCode.W)) counter += 1;
        if (Input.GetKeyDown(KeyCode.S)) counter -= 1;

        if (counter >= ANXIETY) sounds[1].source.volume = 1;
        if (counter >= DESTRUCTION) sounds[2].source.volume = 1;
        if (counter >= MASTERY) sounds[3].source.volume = 1;

        if (counter < ANXIETY) sounds[1].source.volume = 0;
        if (counter < DESTRUCTION) sounds[2].source.volume = 0;
        if (counter < MASTERY) sounds[3].source.volume = 0;
        */

        /* // TEMORARILY COMMENTED OUT
        if (transform.position.x >= (FINALE - 1) && transform.position.x <= (FINALE + 1)) finaleCount++;

        if (finaleCount >= 5 && timerStarter)
        {
            StartCoroutine("volumeFade");
            timer = Time.realtimeSinceStartup;
            
            timerStarter = false;
        }

        if (finaleCount >= 5 && chordProg && timer + 13 <= Time.realtimeSinceStartup)
        {
            sounds[4].source.Play();
            chordProg = false;
        } 
        if (finaleCount >= 5 && chordProgEnd && timer + 36 <= Time.realtimeSinceStartup)
        {
            sounds[5].source.Play();
            chordProgEnd = false;
        }
        */
    }

    public IEnumerator volumeFade()
    {
        for (int i = 0; i < 10000; i++)
        {
            sounds[0].source.volume -= .0001f;
            sounds[1].source.volume -= .0001f;
            sounds[2].source.volume -= .0001f;
            sounds[3].source.volume -= .0001f;

            yield return null;
        }
    }
    
}
