using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject sManager;
    public GameObject self;
    GameObject objToExit;
    public void GetObject(GameObject obj)
    {
        objToExit = obj;
        self.SetActive(true);
    }
    public void Exit()
    {
        objToExit.SetActive(false);
        sManager.GetComponent<SettingsManager>().SetVis("opened");
    }
}
