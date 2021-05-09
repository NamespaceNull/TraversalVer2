
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumen : MonoBehaviour
{

    public Sound s;
    public int maxDistance;
    
    void Start()
    {

        if (maxDistance < 10) maxDistance = 10;

        AudioSource source = gameObject.AddComponent<AudioSource>();
        AudioClip clip = s.clip;
        s = new Sound(source, clip, 2);

        s.source.loop = true;
        s.source.spatialBlend = 1;
        s.source.maxDistance = maxDistance;
        s.source.minDistance = 1;
        s.source.rolloffMode = AudioRolloffMode.Linear;
       

        s.source.Play();
    }
}
