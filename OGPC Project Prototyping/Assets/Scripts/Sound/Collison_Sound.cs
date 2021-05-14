
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collison_Sound : MonoBehaviour
{

    public Sound Enter_Sound;
    public float enterVolume;

    public Sound Exit_Sound;
    public float exitVolume;

    public Sound Inside_Sound;
    public float insideVolume;

    void Start()
    {
        if (enterVolume == 0) enterVolume = 1;
        if (exitVolume == 0) exitVolume = 1;
        if (insideVolume == 0) insideVolume = 1;


        AudioSource enterSource = gameObject.AddComponent<AudioSource>();
        AudioClip enterClip = Enter_Sound.clip;
        Enter_Sound = new Sound(enterSource, enterClip, enterVolume);

        AudioSource exitSource = gameObject.AddComponent<AudioSource>();
        AudioClip exitClip = Exit_Sound.clip;
        Exit_Sound = new Sound(exitSource, exitClip, exitVolume);

        AudioSource insideSource = gameObject.AddComponent<AudioSource>();
        AudioClip insideClip = Inside_Sound.clip;
        Inside_Sound = new Sound(insideSource, insideClip, insideVolume);
        Inside_Sound.source.loop = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Enter_Sound.source.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Exit_Sound.source.Play();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Inside_Sound.source.Play();
        }
    }


}
