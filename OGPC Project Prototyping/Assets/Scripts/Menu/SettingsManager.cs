using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public string settingsVis;
    float timeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        settingsVis = "closed";
        timeSpeed = Time.timeScale;
        SetVis(settingsVis);
    }
    public void SetVis(string vis)
    {
        timeSpeed = (Time.timeScale != 0) ? Time.timeScale : timeSpeed;
        settingsVis = vis;

        foreach (Transform child in transform)
        {
            GameObject obj = child.gameObject;
            bool boolVis = GetBoolVis();
            obj.SetActive(boolVis);
            if (!(vis == "startOpened"))
            {
                if (obj.CompareTag("UIPermanent"))
                { obj.SetActive(true); }
                else if (obj.CompareTag("UISituational"))
                { obj.SetActive(false); }
            }
        }

        if (vis == "opened" || vis == "partclosed")
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = timeSpeed;
        }


    }
    public string GetVis()
    {
        return settingsVis;
    }
    public bool GetBoolVis()
    {
        bool boolVis;
        switch (settingsVis)
        {
            case "closed":
                boolVis = false;
                break;
            case "partclosed":
                boolVis = false;
                break;
            case "opened":
                boolVis = true;
                break;
            case "startOpened":
                boolVis = true;
                break;
            default:
                Debug.Log("vis (SettingsManager) assigned improper value");
                boolVis = false;
                break;
        }
        return boolVis;
    }
    public string CreateStringVis(bool boolval)
    //changes boolean input to "opened"/"closed". Cannot be used to create "partclosed".
    {
        return boolval ? "opened" : "closed";
    }
}
