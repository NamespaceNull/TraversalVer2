using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject sManager;
    public GameObject dManager;
    bool menuOpen;
    bool jumpBool = false;
    bool glideLetGo = false;

    // Update is called once per frame
    void Update()
    {
        menuOpen = sManager.GetComponent<SettingsManager>().GetBoolVis();

        // Volume uicrease
        if (Input.GetKeyDown("t"))
        {
            float vol = PlayerPrefs.GetFloat("volume") + .1f;
            if (vol > 1)
            {
                vol = 1;
            }
            AudioListener.volume = vol;
            PlayerPrefs.SetFloat("volume", vol);
        }
        // Volume decrease
        else if (Input.GetKeyDown("y"))
        {
            float vol = PlayerPrefs.GetFloat("volume") - .1f;
            if (vol < 0)
            {
                vol = 0;
            }
            AudioListener.volume = vol;
            PlayerPrefs.SetFloat("volume", vol);
        }
        else if (Input.GetKeyDown("p"))
        {
            GameObject settingsButton = GameObject.Find("Settings Button");
            settingsButton.GetComponent<S_SettingsButton>().BasicFunction();
        }
        if (Input.GetKeyUp("w"))
        {
            glideLetGo = true;
        }
        else
        {
            glideLetGo = false;
        }

        if (!menuOpen)
        {
            if (Input.GetKeyDown("j"))
            {
                StartCoroutine(dManager.GetComponent<darknessManager>().fadeToDark());
            }
            else if (Input.GetKeyDown("k"))
            {
                StartCoroutine(dManager.GetComponent<darknessManager>().fadeToLight());
            }
            else if (Input.GetKeyDown("space"))
            {
                jumpBool = true;
            }
            else
            {
                jumpBool = false;
            }
        }
        else
        {
            jumpBool = false;
        }
    }
    public bool GetGlidingKey()
    {
        return Input.GetKey("w");
    }
    public bool GetGlidingUp()
    {
        return glideLetGo;
    }
    public bool GetJumpKey()
    {
        return jumpBool;
    }

}
