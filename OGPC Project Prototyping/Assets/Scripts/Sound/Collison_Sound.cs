
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collison_Sound : MonoBehaviour
{

    public Sound Enter_Sound;
    public Sound Exit_Sound;
    public Sound Inside_Sound;


    void Start()
    {
        AudioSource enterSource = gameObject.AddComponent<AudioSource>();
        AudioClip enterClip = Enter_Sound.clip;
        Enter_Sound = new Sound(enterSource, enterClip, 1);

        AudioSource exitSource = gameObject.AddComponent<AudioSource>();
        AudioClip exitClip = Exit_Sound.clip;
        Exit_Sound = new Sound(exitSource, exitClip, 1);

        AudioSource insideSource = gameObject.AddComponent<AudioSource>();
        AudioClip insideClip = Inside_Sound.clip;
        Inside_Sound = new Sound(insideSource, insideClip, 1);
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
