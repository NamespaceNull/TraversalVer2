using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    public GameObject sManager;
    public GameObject backButton;
    public GameObject creditTxtObj;


    // Start is called before the first frame update
    void Start()
    {
        string vis = sManager.GetComponent<SettingsManager>().GetVis();
        sManager.GetComponent<SettingsManager>().SetVis(vis);
    }

    public void Opened()
    {
        sManager.GetComponent<SettingsManager>().SetVis("partclosed");
        creditTxtObj.SetActive(true);
        backButton.GetComponent<BackButton>().GetObject(creditTxtObj);
    }
}
